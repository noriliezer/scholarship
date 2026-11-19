using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace scholarship
{
    public class StudentInfo
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Email { get; set; }
    }

    public class ScholarshipInfo
    {
        public int ScholarshipId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Deadline { get; set; }
        public int Slots { get; set; }
        public int Remaining { get; set; }
        public string Status { get; set; }
    }

    public class StudentApplication
    {
        public int ApplicationId { get; set; }
        public int ScholarshipId { get; set; }
        public string ScholarshipName { get; set; }
        public DateTime DateApplied { get; set; }
        public string Status { get; set; }
    }

    public class StudentMessage
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public static class Db
    {
        // FIXED: Connected to LocalDB
        private const string ConnStr =
            "Server=(localdb)\\MSSQLLocalDB;Database=scholarship_db;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection Open()
        {
            var c = new SqlConnection(ConnStr);
            c.Open();
            return c;
        }

        public static int Execute(string sql, params (string Name, object Value)[] ps)
        {
            using var c = Open();
            using var cmd = new SqlCommand(sql, c);
            foreach (var p in ps) cmd.Parameters.AddWithValue(p.Name, p.Value ?? DBNull.Value);
            return cmd.ExecuteNonQuery();
        }

        public static object Scalar(string sql, params (string Name, object Value)[] ps)
        {
            using var c = Open();
            using var cmd = new SqlCommand(sql, c);
            foreach (var p in ps) cmd.Parameters.AddWithValue(p.Name, p.Value ?? DBNull.Value);
            return cmd.ExecuteScalar();
        }

        public static string Str(SqlDataReader r, int i) =>
            r.IsDBNull(i) ? null : r.GetValue(i)?.ToString();

        public static object NullIfEmpty(string s) =>
            string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : s;

        public static string Friendly(SqlException ex) => "Database error: " + ex.Message;

        // ================= STUDENT: AUTH =================
        public static StudentInfo AuthenticateStudent(string loginInput, string plainPassword)
        {
            using var c = Open();
            using var cmd = new SqlCommand(
                "SELECT student_id, full_name, course, year_level, email, password_hash " +
                "FROM students WHERE student_id = @input OR email = @input", c);
            cmd.Parameters.AddWithValue("@input", loginInput);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            var hash = Str(r, 5);

            // TEMPORARY BYPASS: If the DB has no password saved, we let them in.
            if (!string.IsNullOrEmpty(hash))
            {
                if (!BCrypt.Net.BCrypt.Verify(plainPassword, hash)) return null;
            }

            return new StudentInfo
            {
                StudentId = Str(r, 0),
                FullName = Str(r, 1),
                Course = Str(r, 2),
                YearLevel = Str(r, 3),
                Email = Str(r, 4)
            };
        }

        public static void UpdateStudentPassword(string studentId, string plainPassword)
        {
            Execute("UPDATE students SET password_hash = @p WHERE student_id = @id",
                ("@p", BCrypt.Net.BCrypt.HashPassword(plainPassword)), ("@id", studentId));
        }

        public static bool VerifyStudentPassword(string studentId, string plainPassword)
        {
            var hash = Scalar("SELECT password_hash FROM students WHERE student_id = @id",
                ("@id", studentId)) as string;
            return !string.IsNullOrEmpty(hash) && BCrypt.Net.BCrypt.Verify(plainPassword, hash);
        }

        public static void UpdateStudentProfile(StudentInfo s)
        {
            Execute(
                "UPDATE students SET full_name = @n, course = @c, year_level = @y, email = @e " +
                "WHERE student_id = @id",
                ("@n", s.FullName), ("@c", NullIfEmpty(s.Course)),
                ("@y", s.YearLevel), ("@e", NullIfEmpty(s.Email)), ("@id", s.StudentId));
        }

        public static StudentInfo GetStudentById(string studentId)
        {
            using var c = Open();
            using var cmd = new SqlCommand(
                "SELECT student_id, full_name, course, year_level, email " +
                "FROM students WHERE student_id = @id", c);
            cmd.Parameters.AddWithValue("@id", studentId);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new StudentInfo
            {
                StudentId = Str(r, 0),
                FullName = Str(r, 1),
                Course = Str(r, 2),
                YearLevel = Str(r, 3),
                Email = Str(r, 4)
            };
        }

        // ================= SCHOLARSHIPS =================
        public static List<ScholarshipInfo> GetAvailableScholarships(string keyword = null)
        {
            var list = new List<ScholarshipInfo>();
            using var c = Open();

            var sql = @"SELECT s.scholarship_id, s.name, s.amount, s.deadline, s.slots, s.status,
                               s.slots - (SELECT COUNT(*) FROM applications a
                                          WHERE a.scholarship_id = s.scholarship_id
                                            AND a.status = 'Accepted') AS remaining
                        FROM scholarships s WHERE s.status = 'Available'";
            if (!string.IsNullOrWhiteSpace(keyword)) sql += " AND s.name LIKE @kw";
            sql += " ORDER BY s.deadline ASC";

            using var cmd = new SqlCommand(sql, c);
            if (!string.IsNullOrWhiteSpace(keyword))
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new ScholarshipInfo
                {
                    ScholarshipId = r.GetInt32(0),
                    Name = r.GetString(1),
                    Amount = r.GetDecimal(2),
                    Deadline = r.GetDateTime(3),
                    Slots = r.GetInt32(4),
                    Status = r.GetString(5),
                    Remaining = r.GetInt32(6)
                });
            }
            return list;
        }

        public static ScholarshipInfo GetScholarshipById(int id)
        {
            using var c = Open();
            using var cmd = new SqlCommand(
                @"SELECT s.scholarship_id, s.name, s.amount, s.deadline, s.slots, s.status,
                         s.slots - (SELECT COUNT(*) FROM applications a
                                    WHERE a.scholarship_id = s.scholarship_id
                                      AND a.status = 'Accepted') AS remaining
                  FROM scholarships s WHERE s.scholarship_id = @id", c);
            cmd.Parameters.AddWithValue("@id", id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new ScholarshipInfo
            {
                ScholarshipId = r.GetInt32(0),
                Name = r.GetString(1),
                Amount = r.GetDecimal(2),
                Deadline = r.GetDateTime(3),
                Slots = r.GetInt32(4),
                Status = r.GetString(5),
                Remaining = r.GetInt32(6)
            };
        }

        // ================= APPLICATIONS =================
        public static List<StudentApplication> GetApplicationsByStudent(string studentId)
        {
            var list = new List<StudentApplication>();
            using var c = Open();
            using var cmd = new SqlCommand(
                @"SELECT a.application_id, a.scholarship_id, sc.name, a.date_applied, a.status
                  FROM applications a
                  JOIN scholarships sc ON sc.scholarship_id = a.scholarship_id
                  WHERE a.student_id = @id ORDER BY a.date_applied DESC", c);
            cmd.Parameters.AddWithValue("@id", studentId);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new StudentApplication
                {
                    ApplicationId = r.GetInt32(0),
                    ScholarshipId = r.GetInt32(1),
                    ScholarshipName = r.GetString(2),
                    DateApplied = r.GetDateTime(3),
                    Status = r.GetString(4)
                });
            }
            return list;
        }

        public static bool HasApplied(string studentId, int scholarshipId)
        {
            var count = Convert.ToInt32(Scalar(
                "SELECT COUNT(*) FROM applications WHERE student_id = @s AND scholarship_id = @sc AND status <> 'Withdrawn'",
                ("@s", studentId), ("@sc", scholarshipId)));
            return count > 0;
        }

        public static int SubmitApplication(string studentId, int scholarshipId)
        {
            var result = Scalar(
                @"INSERT INTO applications (student_id, scholarship_id, date_applied, status)
                  OUTPUT INSERTED.application_id
                  VALUES (@s, @sc, SYSUTCDATETIME(), 'Pending')",
                ("@s", studentId), ("@sc", scholarshipId));
            return Convert.ToInt32(result);
        }

        public static void WithdrawApplication(int applicationId, string studentId)
        {
            Execute(
                "UPDATE applications SET status = 'Withdrawn' WHERE application_id = @id AND student_id = @s AND status = 'Pending'",
                ("@id", applicationId), ("@s", studentId));
        }

        // ================= MESSAGES =================
        public static List<StudentMessage> GetMessagesByStudent(string studentId)
        {
            var list = new List<StudentMessage>();
            using var c = Open();
            using var cmd = new SqlCommand(
                @"SELECT message_id, title, body, is_read, created_at
                  FROM student_messages WHERE student_id = @id ORDER BY created_at DESC", c);
            cmd.Parameters.AddWithValue("@id", studentId);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new StudentMessage
                {
                    MessageId = r.GetInt32(0),
                    Title = r.GetString(1),
                    Body = r.IsDBNull(2) ? "" : r.GetString(2),
                    IsRead = r.GetBoolean(3),
                    CreatedAt = r.GetDateTime(4)
                });
            }
            return list;
        }

        public static void MarkMessageRead(int messageId) =>
            Execute("UPDATE student_messages SET is_read = 1 WHERE message_id = @id", ("@id", messageId));

        public static void MarkAllMessagesRead(string studentId) =>
            Execute("UPDATE student_messages SET is_read = 1 WHERE student_id = @id", ("@id", studentId));

        // ================= DASHBOARD STATS =================
        public static (int openCount, int myCount, int acceptedCount)
            GetStudentDashboardStats(string studentId)
        {
            int open = Convert.ToInt32(Scalar("SELECT COUNT(*) FROM scholarships WHERE status = 'Available'"));
            int mine = Convert.ToInt32(Scalar("SELECT COUNT(*) FROM applications WHERE student_id = @id", ("@id", studentId)));
            int accepted = Convert.ToInt32(Scalar("SELECT COUNT(*) FROM applications WHERE student_id = @id AND status = 'Accepted'", ("@id", studentId)));
            return (open, mine, accepted);
        }
    }
}
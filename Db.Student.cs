using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ScholarshipApp
{
    // --- Model classes used only by the student side ---
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

    public partial class Db
    {
        // ---------- Authentication ----------
        public static StudentInfo AuthenticateStudent(string studentId, string plainPassword)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "SELECT student_id, full_name, course, year_level, email, password_hash " +
                "FROM students WHERE student_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", studentId);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            var hash = Str(r, 5);
            if (string.IsNullOrEmpty(hash)) return null;
            if (!BCrypt.Net.BCrypt.Verify(plainPassword, hash)) return null;

            return new StudentInfo
            {
                StudentId = Str(r, 0),
                FullName = Str(r, 1),
                Course = Str(r, 2),
                YearLevel = Str(r, 3),
                Email = Str(r, 4)
            };
        }

        // ---------- Profile ----------
        public static StudentInfo GetStudentById(string studentId)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "SELECT student_id, full_name, course, year_level, email " +
                "FROM students WHERE student_id = @id", conn);
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

        public static void UpdateStudentProfile(StudentInfo s)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "UPDATE students SET full_name = @n, course = @c, year_level = @y, email = @e " +
                "WHERE student_id = @id", conn);
            cmd.Parameters.AddWithValue("@n", s.FullName);
            cmd.Parameters.AddWithValue("@c", NullIfEmpty(s.Course));
            cmd.Parameters.AddWithValue("@y", s.YearLevel);
            cmd.Parameters.AddWithValue("@e", NullIfEmpty(s.Email));
            cmd.Parameters.AddWithValue("@id", s.StudentId);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateStudentPassword(string studentId, string plainPassword)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "UPDATE students SET password_hash = @p WHERE student_id = @id", conn);
            cmd.Parameters.AddWithValue("@p", BCrypt.Net.BCrypt.HashPassword(plainPassword));
            cmd.Parameters.AddWithValue("@id", studentId);
            cmd.ExecuteNonQuery();
        }

        public static bool VerifyStudentPassword(string studentId, string plainPassword)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "SELECT password_hash FROM students WHERE student_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", studentId);

            var hash = cmd.ExecuteScalar() as string;
            return !string.IsNullOrEmpty(hash) && BCrypt.Net.BCrypt.Verify(plainPassword, hash);
        }

        // ---------- Scholarships (read-only for students) ----------
        public static List<ScholarshipInfo> GetAvailableScholarships(string keyword = null)
        {
            var list = new List<ScholarshipInfo>();
            using var conn = Open();

            var sql = @"SELECT s.scholarship_id, s.name, s.amount, s.deadline, s.slots, s.status,
                               s.slots - (SELECT COUNT(*) FROM applications a
                                          WHERE a.scholarship_id = s.scholarship_id
                                            AND a.status = 'Accepted') AS remaining
                        FROM scholarships s
                        WHERE s.status = 'Available'";
            if (!string.IsNullOrWhiteSpace(keyword))
                sql += " AND s.name LIKE @kw";
            sql += " ORDER BY s.deadline ASC";

            using var cmd = new SqlCommand(sql, conn);
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
            using var conn = Open();
            using var cmd = new SqlCommand(
                @"SELECT s.scholarship_id, s.name, s.amount, s.deadline, s.slots, s.status,
                         s.slots - (SELECT COUNT(*) FROM applications a
                                    WHERE a.scholarship_id = s.scholarship_id
                                      AND a.status = 'Accepted') AS remaining
                  FROM scholarships s
                  WHERE s.scholarship_id = @id", conn);
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

        // ---------- Applications ----------
        public static List<StudentApplication> GetApplicationsByStudent(string studentId)
        {
            var list = new List<StudentApplication>();
            using var conn = Open();
            using var cmd = new SqlCommand(
                @"SELECT a.application_id, a.scholarship_id, sc.name, a.date_applied, a.status
                  FROM applications a
                  JOIN scholarships sc ON sc.scholarship_id = a.scholarship_id
                  WHERE a.student_id = @id
                  ORDER BY a.date_applied DESC", conn);
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
            using var conn = Open();
            using var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM applications " +
                "WHERE student_id = @s AND scholarship_id = @sc AND status <> 'Withdrawn'", conn);
            cmd.Parameters.AddWithValue("@s", studentId);
            cmd.Parameters.AddWithValue("@sc", scholarshipId);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public static int SubmitApplication(string studentId, int scholarshipId)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                @"INSERT INTO applications (student_id, scholarship_id, date_applied, status)
                  OUTPUT INSERTED.application_id
                  VALUES (@s, @sc, SYSUTCDATETIME(), 'Pending')", conn);
            cmd.Parameters.AddWithValue("@s", studentId);
            cmd.Parameters.AddWithValue("@sc", scholarshipId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void WithdrawApplication(int applicationId, string studentId)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "UPDATE applications SET status = 'Withdrawn' " +
                "WHERE application_id = @id AND student_id = @s AND status = 'Pending'", conn);
            cmd.Parameters.AddWithValue("@id", applicationId);
            cmd.Parameters.AddWithValue("@s", studentId);
            cmd.ExecuteNonQuery();
        }

        // ---------- Messages (per-student) ----------
        public static List<StudentMessage> GetMessagesByStudent(string studentId)
        {
            var list = new List<StudentMessage>();
            using var conn = Open();
            using var cmd = new SqlCommand(
                @"SELECT message_id, title, body, is_read, created_at
                  FROM student_messages
                  WHERE student_id = @id
                  ORDER BY created_at DESC", conn);
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

        public static void MarkMessageRead(int messageId)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "UPDATE student_messages SET is_read = 1 WHERE message_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", messageId);
            cmd.ExecuteNonQuery();
        }

        public static void MarkAllMessagesRead(string studentId)
        {
            using var conn = Open();
            using var cmd = new SqlCommand(
                "UPDATE student_messages SET is_read = 1 WHERE student_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", studentId);
            cmd.ExecuteNonQuery();
        }

        // ---------- Dashboard stats ----------
        public static (int openCount, int myCount, int acceptedCount)
            GetStudentDashboardStats(string studentId)
        {
            using var conn = Open();

            using var c1 = new SqlCommand(
                "SELECT COUNT(*) FROM scholarships WHERE status = 'Available'", conn);
            int open = Convert.ToInt32(c1.ExecuteScalar());

            using var c2 = new SqlCommand(
                "SELECT COUNT(*) FROM applications WHERE student_id = @id", conn);
            c2.Parameters.AddWithValue("@id", studentId);
            int mine = Convert.ToInt32(c2.ExecuteScalar());

            using var c3 = new SqlCommand(
                "SELECT COUNT(*) FROM applications WHERE student_id = @id AND status = 'Accepted'", conn);
            c3.Parameters.AddWithValue("@id", studentId);
            int accepted = Convert.ToInt32(c3.ExecuteScalar());

            return (open, mine, accepted);
        }
    }
}
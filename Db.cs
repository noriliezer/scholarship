using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace scholarship
{
    // ----- Add these public model classes (or put in Models.cs) -----
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentNo { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public double Gpa { get; set; }
        public string PhotoPath { get; set; }
    }

    public class Scholarship
    {
        public int ScholarshipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Deadline { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }

    public class Application
    {
        public int ApplicationId { get; set; }
        public int StudentId { get; set; }
        public int ScholarshipId { get; set; }
        public string ScholarshipName { get; set; }
        public string AppliedAt { get; set; }
        public string Status { get; set; }
        public string Essay { get; set; }
        public string AdminComment { get; set; }
    }

    public class Message
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public string CreatedAt { get; set; }
        public int? ApplicationId { get; set; }
    }

    public partial class Db
    {
        // ---------- Student: auth ----------
        public static Student AuthenticateStudent(string studentNo, string passwordHash)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT * FROM Students WHERE StudentNo=@s AND PasswordHash=@p", conn))
                {
                    cmd.Parameters.AddWithValue("@s", studentNo);
                    cmd.Parameters.AddWithValue("@p", passwordHash);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read()) return MapStudent(r);
                    }
                }
            }
            return null;
        }

        public static Student GetStudentById(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Students WHERE StudentId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var r = cmd.ExecuteReader())
                        if (r.Read()) return MapStudent(r);
                }
            }
            return null;
        }

        private static Student MapStudent(SQLiteDataReader r)
        {
            return new Student
            {
                StudentId = Convert.ToInt32(r["StudentId"]),
                StudentNo = r["StudentNo"].ToString(),
                FullName = r["FullName"].ToString(),
                Email = r["Email"].ToString(),
                Course = r["Course"]?.ToString(),
                YearLevel = r["YearLevel"]?.ToString(),
                Gpa = r["Gpa"] == DBNull.Value ? 0 : Convert.ToDouble(r["Gpa"]),
                PhotoPath = r["PhotoPath"]?.ToString()
            };
        }

        public static void UpdateStudentProfile(Student s)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    @"UPDATE Students
                      SET FullName=@n, Email=@e, Course=@c, YearLevel=@y, Gpa=@g, PhotoPath=@ph
                      WHERE StudentId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@n", s.FullName);
                    cmd.Parameters.AddWithValue("@e", s.Email);
                    cmd.Parameters.AddWithValue("@c", (object)s.Course ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@y", (object)s.YearLevel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@g", s.Gpa);
                    cmd.Parameters.AddWithValue("@ph", (object)s.PhotoPath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", s.StudentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateStudentPassword(int studentId, string newPasswordHash)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Students SET PasswordHash=@p WHERE StudentId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@p", newPasswordHash);
                    cmd.Parameters.AddWithValue("@id", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ---------- Scholarships ----------
        public static List<Scholarship> GetOpenScholarships(string keyword = null, string category = null)
        {
            var list = new List<Scholarship>();
            using (var conn = GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM Scholarships WHERE Status='Open'";
                if (!string.IsNullOrWhiteSpace(keyword))
                    sql += " AND (Name LIKE @kw OR Description LIKE @kw)";
                if (!string.IsNullOrWhiteSpace(category) && category != "All")
                    sql += " AND Category=@cat";
                sql += " ORDER BY Deadline ASC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(keyword))
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    if (!string.IsNullOrWhiteSpace(category) && category != "All")
                        cmd.Parameters.AddWithValue("@cat", category);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Scholarship
                            {
                                ScholarshipId = Convert.ToInt32(r["ScholarshipId"]),
                                Name = r["Name"].ToString(),
                                Description = r["Description"]?.ToString(),
                                Amount = r["Amount"] == DBNull.Value ? 0 : Convert.ToDouble(r["Amount"]),
                                Deadline = r["Deadline"]?.ToString(),
                                Category = r["Category"]?.ToString(),
                                Status = r["Status"]?.ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static Scholarship GetScholarshipById(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Scholarships WHERE ScholarshipId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new Scholarship
                            {
                                ScholarshipId = Convert.ToInt32(r["ScholarshipId"]),
                                Name = r["Name"].ToString(),
                                Description = r["Description"]?.ToString(),
                                Amount = r["Amount"] == DBNull.Value ? 0 : Convert.ToDouble(r["Amount"]),
                                Deadline = r["Deadline"]?.ToString(),
                                Category = r["Category"]?.ToString(),
                                Status = r["Status"]?.ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static List<string> GetScholarshipCategories()
        {
            var list = new List<string> { "All" };
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT DISTINCT Category FROM Scholarships WHERE Category IS NOT NULL", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(r[0].ToString());
            }
            return list;
        }

        // ---------- Applications ----------
        public static List<Application> GetApplicationsByStudent(int studentId)
        {
            var list = new List<Application>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    @"SELECT a.*, s.Name AS ScholarshipName
                      FROM Applications a
                      JOIN Scholarships s ON s.ScholarshipId = a.ScholarshipId
                      WHERE a.StudentId=@id ORDER BY a.AppliedAt DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Application
                            {
                                ApplicationId = Convert.ToInt32(r["ApplicationId"]),
                                StudentId = studentId,
                                ScholarshipId = Convert.ToInt32(r["ScholarshipId"]),
                                ScholarshipName = r["ScholarshipName"].ToString(),
                                AppliedAt = r["AppliedAt"].ToString(),
                                Status = r["Status"].ToString(),
                                Essay = r["Essay"]?.ToString(),
                                AdminComment = r["AdminComment"]?.ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static bool HasApplied(int studentId, int scholarshipId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Applications WHERE StudentId=@s AND ScholarshipId=@sc", conn))
                {
                    cmd.Parameters.AddWithValue("@s", studentId);
                    cmd.Parameters.AddWithValue("@sc", scholarshipId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static int SubmitApplication(int studentId, int scholarshipId, string essay)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    @"INSERT INTO Applications (StudentId, ScholarshipId, Essay, Status)
                      VALUES (@s, @sc, @e, 'Pending');
                      SELECT last_insert_rowid();", conn))
                {
                    cmd.Parameters.AddWithValue("@s", studentId);
                    cmd.Parameters.AddWithValue("@sc", scholarshipId);
                    cmd.Parameters.AddWithValue("@e", (object)essay ?? DBNull.Value);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void WithdrawApplication(int applicationId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Applications SET Status='Withdrawn' WHERE ApplicationId=@id AND Status='Pending'", conn))
                {
                    cmd.Parameters.AddWithValue("@id", applicationId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ---------- Messages ----------
        public static List<Message> GetMessagesByStudent(int studentId)
        {
            var list = new List<Message>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT * FROM Messages WHERE StudentId=@id ORDER BY CreatedAt DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Message
                            {
                                MessageId = Convert.ToInt32(r["MessageId"]),
                                Title = r["Title"].ToString(),
                                Body = r["Body"]?.ToString(),
                                IsRead = Convert.ToInt32(r["IsRead"]) == 1,
                                CreatedAt = r["CreatedAt"].ToString(),
                                ApplicationId = r["ApplicationId"] == DBNull.Value
                                    ? (int?)null
                                    : Convert.ToInt32(r["ApplicationId"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static void MarkMessageRead(int messageId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Messages SET IsRead=1 WHERE MessageId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", messageId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void MarkAllMessagesRead(int studentId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Messages SET IsRead=1 WHERE StudentId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetUnreadMessageCount(int studentId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Messages WHERE StudentId=@id AND IsRead=0", conn))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // ---------- Dashboard stats ----------
        public static (int openScholarships, int myApplications, int approved) GetStudentDashboardStats(int studentId)
        {
            int open = 0, mine = 0, approved = 0;
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var c1 = new SQLiteCommand("SELECT COUNT(*) FROM Scholarships WHERE Status='Open'", conn))
                    open = Convert.ToInt32(c1.ExecuteScalar());
                using (var c2 = new SQLiteCommand("SELECT COUNT(*) FROM Applications WHERE StudentId=@id", conn))
                {
                    c2.Parameters.AddWithValue("@id", studentId);
                    mine = Convert.ToInt32(c2.ExecuteScalar());
                }
                using (var c3 = new SQLiteCommand("SELECT COUNT(*) FROM Applications WHERE StudentId=@id AND Status='Approved'", conn))
                {
                    c3.Parameters.AddWithValue("@id", studentId);
                    approved = Convert.ToInt32(c3.ExecuteScalar());
                }
            }
            return (open, mine, approved);
        }
    }
}
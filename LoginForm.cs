using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace scholarship
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // ---------- Admin login ----------
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsernameOrEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Enter your username/email and password.", "Login");
                return;
            }

            try
            {
                using var conn = Db.Open();
                using var cmd = new SqlCommand(
                    "SELECT admin_id, username, password_hash FROM admins " +
                    "WHERE username = @u OR email = @u", conn);
                cmd.Parameters.AddWithValue("@u", txtUsernameOrEmail.Text.Trim());
                using var reader = cmd.ExecuteReader();

                if (!reader.Read() || !BCrypt.Net.BCrypt.Verify(txtPassword.Text, reader.GetString(2)))
                {
                    MessageBox.Show("Invalid admin credentials.", "Login");
                    return;
                }

                Session.AdminId = reader.GetInt32(0);
                Session.Username = reader.GetString(1);
                Session.Role = "Admin";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message, "Error");
                return;
            }

            Ui.Open(this, new DashboardForm());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Ui.Open(this, new LandingForm());
        }

        // ---------- Student login (BYPASSED FOR DEBUGGING) ----------
        private void btnStudentLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Force the app to create the student with a password directly in the DB
                string hash = BCrypt.Net.BCrypt.HashPassword("password123");
                Db.Execute("IF NOT EXISTS (SELECT * FROM students WHERE email = 'mark123@gmail.com') " +
                           "INSERT INTO students (student_id, full_name, course, year_level, email, password_hash) " +
                           "VALUES ('2026-9999', 'Mark Admin', 'BSIT', 1, 'mark123@gmail.com', @h) " +
                           "ELSE " +
                           "UPDATE students SET password_hash = @h WHERE email = 'mark123@gmail.com'",
                           ("@h", hash));

                // 2. Now try to authenticate them
                var student = Db.AuthenticateStudent("mark123@gmail.com", "password123");

                if (student == null)
                {
                    MessageBox.Show("Auth Failed even after forcing the user. Check your connection string in Db.cs.", "Error");
                    return;
                }

                // 3. Success! Log them in.
                Session.StudentId = student.StudentId;
                Session.StudentName = student.FullName;
                Session.Role = "Student";

                MessageBox.Show("It worked! Logging you in now.", "Success");
                Ui.Open(this, new StudentDashboardForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error:\n\n" + ex.Message, "Fatal Error");
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ui.Open(this, new RegisterForm());
        }
    }
}
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using scholarship;

namespace ScholarshipApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // ---------- Admin login (unchanged behaviour) ----------
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsernameOrEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
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
                    MessageBox.Show("Invalid username/email or password.", "Login");
                    return;
                }

                Session.AdminId = reader.GetInt32(0);
                Session.Username = reader.GetString(1);
                Session.Role = "Admin";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Login");
                return;
            }

            Ui.Open(this, new DashboardForm());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Ui.Open(this, new LandingForm());
        }

        // ---------- Student login (new) ----------
        private void btnStudentLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtStudentPassword.Text))
            {
                MessageBox.Show("Enter your Student ID and password.", "Student Login");
                return;
            }

            try
            {
                var student = Db.AuthenticateStudent(
                    txtStudentId.Text.Trim(),
                    txtStudentPassword.Text);

                if (student == null)
                {
                    MessageBox.Show("Invalid Student ID or password.", "Student Login");
                    return;
                }

                Session.StudentId = student.StudentId;
                Session.StudentName = student.FullName;
                Session.Role = "Student";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Student Login");
                return;
            }

            Ui.Open(this, new StudentDashboardForm());
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ui.Open(this, new RegisterForm());
        }
    }
}
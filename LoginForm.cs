using Microsoft.Data.SqlClient;

namespace ScholarshipApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Ui.ApplyGradient(pnlLogin);
        }

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
                using var cmd = new SqlCommand("SELECT admin_id, username, password_hash FROM admins WHERE username = @u OR email = @u", conn);
                cmd.Parameters.AddWithValue("@u", txtUsernameOrEmail.Text.Trim());
                using var reader = cmd.ExecuteReader();

                if (!reader.Read() || !BCrypt.Net.BCrypt.Verify(txtPassword.Text, reader.GetString(2)))
                {
                    MessageBox.Show("Invalid username/email or password.", "Login");
                    return;
                }

                Session.AdminId = reader.GetInt32(0);
                Session.Username = reader.GetString(1);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Login");
                return;
            }

            Ui.Open(this, new DashboardForm());
        }
    }
}
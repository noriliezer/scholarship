using Microsoft.Data.SqlClient;

namespace scholarship
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            Ui.ApplyGradient(pnlRegister);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Registration");
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Registration");
                return;
            }
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.", "Registration");
                return;
            }

            try
            {
                Db.Execute("INSERT INTO admins (username, email, password_hash) VALUES (@u, @e, @h)",
                    ("@u", txtUsername.Text.Trim()),
                    ("@e", txtEmail.Text.Trim()),
                    ("@h", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text)));
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Registration");
                return;
            }

            MessageBox.Show("Account created!", "Registration");
            Ui.Open(this, new LoginForm());
        }
    }
}
using Microsoft.Data.SqlClient;

namespace scholarship
{
    public partial class SettingsPage : UserControl
    {
        public event EventHandler LogoutRequested;

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmNewPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Settings");
                return;
            }
            if (txtNewPassword.Text != txtConfirmNewPassword.Text)
            {
                MessageBox.Show("New passwords do not match.", "Settings");
                return;
            }
            if (txtNewPassword.Text.Length < 8)
            {
                MessageBox.Show("New password must be at least 8 characters.", "Settings");
                return;
            }
            if (Session.AdminId == 0)
            {
                MessageBox.Show("Your session has expired. Please log in again.", "Settings");
                return;
            }

            try
            {
                var hash = Db.Scalar("SELECT password_hash FROM admins WHERE admin_id = @id", ("@id", Session.AdminId)) as string;
                if (hash == null || !BCrypt.Net.BCrypt.Verify(txtCurrentPassword.Text, hash))
                {
                    MessageBox.Show("Current password is incorrect.", "Settings");
                    return;
                }

                Db.Execute("UPDATE admins SET password_hash = @h WHERE admin_id = @id",
                    ("@h", BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text)),
                    ("@id", Session.AdminId));
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Settings");
                return;
            }

            MessageBox.Show("Password updated.", "Settings");
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmNewPassword.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
using Microsoft.Data.SqlClient;

namespace ScholarshipApp
{
    public partial class CommunicationsPage : UserControl
    {
        public CommunicationsPage()
        {
            InitializeComponent();
            cmbRecipients.Items.AddRange(new object[] { "All Students", "All Applicants" });
            cmbRecipients.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text) || string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Enter a subject and a message.", "Communications");
                return;
            }
            if (Session.AdminId == 0)
            {
                MessageBox.Show("Your session has expired. Please log in again.", "Communications");
                return;
            }

            string group = cmbRecipients.SelectedItem.ToString();
            try
            {
                Db.Execute("INSERT INTO messages (admin_id, recipient_group, subject, body) VALUES (@a, @r, @s, @b)",
                    ("@a", Session.AdminId),
                    ("@r", group),
                    ("@s", txtSubject.Text.Trim()),
                    ("@b", txtMessage.Text.Trim()));
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Communications");
                return;
            }

            MessageBox.Show("Message saved for " + group + ". Email delivery is not connected yet.", "Communications");
            txtSubject.Clear();
            txtMessage.Clear();
        }
    }
}
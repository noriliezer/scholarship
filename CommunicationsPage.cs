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

            // Setup the history grid columns
            dgvHistory.Columns.Add("Date", "Date Sent");
            dgvHistory.Columns.Add("Recipient", "Recipient Group");
            dgvHistory.Columns.Add("Subject", "Subject");
            dgvHistory.Columns.Add("Message", "Message Body");

            foreach (DataGridViewColumn col in dgvHistory.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvHistory.Columns["Date"].FillWeight = 60;
            dgvHistory.Columns["Recipient"].FillWeight = 60;
            dgvHistory.Columns["Subject"].FillWeight = 80;
            dgvHistory.Columns["Message"].FillWeight = 150;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible) LoadHistory();
        }

        private void LoadHistory()
        {
            dgvHistory.Rows.Clear();
            try
            {
                using var conn = Db.Open();
                using var cmd = new SqlCommand("SELECT sent_at, recipient_group, subject, body FROM messages ORDER BY sent_at DESC", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvHistory.Rows.Add(
                        reader.GetDateTime(0).ToString("MMM dd, yyyy hh:mm tt"),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    );
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Communications");
            }
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

            MessageBox.Show("Message saved successfully!", "Communications");
            txtSubject.Clear();
            txtMessage.Clear();

            // Reload the grid to show the new message immediately
            LoadHistory();
        }
    }
}
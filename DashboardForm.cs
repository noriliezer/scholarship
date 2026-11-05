using Microsoft.Data.SqlClient;

namespace ScholarshipApp
{
    public partial class DashboardForm : Form
    {
        private const int SidebarWidth = 260;
        private const int NavWidth = 220;
        private const int Pad = 16;
        private const int Gap = 12;

        private readonly Panel pnlHome = new Panel();
        private readonly ScholarshipsPage scholarshipsPage = new ScholarshipsPage();
        private readonly StudentsPage studentsPage = new StudentsPage();
        private readonly ApplicationsPage applicationsPage = new ApplicationsPage();
        private readonly CommunicationsPage communicationsPage = new CommunicationsPage();
        private readonly SettingsPage settingsPage = new SettingsPage();
        private readonly UserControl[] pages;

        public DashboardForm()
        {
            InitializeComponent();

            Ui.ApplyGradient(pnlSidebar);
            Ui.LoadLogo(picLogo);

            pnlContent.Controls.Clear();

            pnlHome.Dock = DockStyle.Fill;
            pnlHome.BackColor = Color.FromArgb(228, 226, 204);
            pnlHome.BorderStyle = BorderStyle.FixedSingle;
            pnlHome.Padding = new Padding(10);

            pnlHome.Controls.Add(pnlHeader);
            pnlHome.Controls.Add(pnlTotal);
            pnlHome.Controls.Add(pnlAvailable);
            pnlHome.Controls.Add(pnlAccepted);
            pnlHome.Controls.Add(pnlRejected);
            pnlHome.Controls.Add(dgvApplications);

            pnlHeader.SendToBack();

            pnlContent.Controls.Add(pnlHome);

            pnlHome.Resize += (s, e) => LayoutHome();

            pages = new UserControl[] { scholarshipsPage, studentsPage, applicationsPage, communicationsPage, settingsPage };
            foreach (UserControl page in pages)
            {
                page.Dock = DockStyle.Fill;
                page.Visible = false;
                page.BorderStyle = BorderStyle.FixedSingle;
                page.Padding = new Padding(15);
                pnlContent.Controls.Add(page);
            }

            pnlContent.Resize += (s, e) => { LayoutHome(); StretchPages(); };
            pnlSidebar.Resize += (s, e) => LayoutSidebar();

            settingsPage.LogoutRequested += (s, e) => Logout();

            LayoutSidebar();
            SetupApplicationsGrid();
            LoadDashboard();
            LayoutHome();
        }

        private void LayoutSidebar()
        {
            int x = (pnlSidebar.Width - NavWidth) / 2;

            int currentY = 160;
            foreach (Button b in new[] { btnHome, btnScholarships, btnStudents, btnApplications, btnCommunications })
            {
                b.Width = NavWidth;
                b.Height = 44;
                b.Font = new Font("Arial", 14F, FontStyle.Bold);
                b.Left = x;
                b.Top = currentY;
                currentY += 52;
            }

            int halfWidth = (NavWidth - 10) / 2;
            btnSupport.Width = halfWidth;
            btnSettings.Width = halfWidth;
            btnSupport.Left = x;
            btnSettings.Left = x + NavWidth - halfWidth;

            btnSupport.Top = pnlSidebar.Height - 65;
            btnSettings.Top = pnlSidebar.Height - 65;
        }

        private void LayoutHome()
        {
            int w = pnlHome.ClientSize.Width - (Pad * 2);
            if (w < 300) return;

            pnlHeader.SetBounds(Pad, 24, w, 44);

            int cardWidth = (w - (Gap * 3)) / 4;
            Panel[] cards = { pnlTotal, pnlAvailable, pnlAccepted, pnlRejected };
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].SetBounds(Pad + i * (cardWidth + Gap), 80, cardWidth, 88);
            }

            int gridTop = 184;
            dgvApplications.SetBounds(Pad, gridTop, w, Math.Max(100, pnlHome.ClientSize.Height - gridTop - (Pad * 2)));
        }

        private void StretchPages()
        {
            foreach (UserControl page in pages)
            {
                Panel header = null;
                DataGridView grid = null;
                TextBox messageBox = null;
                Button sendButton = null;
                Control comboBox = null;
                Control subjectTextBox = null;
                Label lblSubject = null;

                foreach (Control c in page.Controls)
                {
                    if (c is Panel p && p.Name == "pnlHeader") header = p;
                    else if (c is DataGridView g) grid = g;
                    else if (c is Button b && b.Text == "Send") sendButton = b;
                    else if (c is TextBox tb && tb.Multiline) messageBox = tb;
                    else if (c is ComboBox cb) comboBox = cb;
                    else if (c is TextBox sb && !sb.Multiline) subjectTextBox = sb;
                    else if (c is Label lbl && lbl.Text == "Subject") lblSubject = lbl;
                }

                if (header == null) continue;

                header.Dock = DockStyle.Top;
                header.Height = 50;

                int w = page.ClientSize.Width - 24;
                int h = page.ClientSize.Height;

                if (grid != null) // Table pages
                {
                    foreach (Control c in page.Controls)
                        if (c is Button btn) btn.Top = 68;

                    int gridTop = 118;
                    grid.Left = 12;
                    grid.Top = gridTop;
                    grid.Width = w;
                    grid.Height = Math.Max(100, h - gridTop - 12);
                    grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                }
                else if (sendButton != null && comboBox != null && subjectTextBox != null) // Communications Page
                {
                    // Split the width in half (minus padding/gap)
                    int halfWidth = (w - Gap) / 2;

                    // 1. Recipients (Left Side)
                    comboBox.Left = 12;
                    comboBox.Top = 102;
                    comboBox.Width = halfWidth;

                    foreach (Control c in page.Controls)
                        if (c is Label l && l.Text == "Recipients") { l.Left = 12; l.Top = 68; }

                    // 2. Subject (Right Side)
                    int rightX = 12 + halfWidth + Gap;
                    if (lblSubject != null) { lblSubject.Left = rightX; lblSubject.Top = 68; }

                    subjectTextBox.Left = rightX;
                    subjectTextBox.Top = 102;
                    subjectTextBox.Width = halfWidth;

                    // 3. Message Box (Full width below them)
                    if (messageBox != null)
                    {
                        messageBox.Left = 12;
                        messageBox.Top = 190; // pushed down to accommodate the new 2-column row
                        messageBox.Width = w;
                    }

                    // 4. Send Button (Bottom Right)
                    sendButton.Top = h - 70;
                    sendButton.Left = w + 12 - sendButton.Width;
                    sendButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                    if (messageBox != null)
                    {
                        messageBox.Height = Math.Max(100, sendButton.Top - messageBox.Top - 20);
                        messageBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    }

                    foreach (Control c in page.Controls)
                        if (c is Label l && l.Text == "Message") { l.Left = 12; l.Top = 156; }
                }
            }
        }

        private void SetupApplicationsGrid()
        {
            dgvApplications.Columns.Clear();
            foreach (string header in new[] { "Applicant", "Scholarship", "Date Applied", "Status" })
            {
                dgvApplications.Columns.Add(header, header);
            }
            foreach (DataGridViewColumn column in dgvApplications.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.ReadOnly = true;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadDashboard()
        {
            try
            {
                using var conn = Db.Open();

                lblTotalCount.Text = Scalar(conn, "SELECT COUNT(*) FROM applications").ToString();
                lblAvailableCount.Text = Scalar(conn, "SELECT COUNT(*) FROM scholarships WHERE status = 'Available'").ToString();
                lblAcceptedCount.Text = Scalar(conn, "SELECT COUNT(*) FROM applications WHERE status = 'Accepted'").ToString();
                lblRejectedCount.Text = Scalar(conn, "SELECT COUNT(*) FROM applications WHERE status = 'Rejected'").ToString();

                dgvApplications.Rows.Clear();
                const string sql = @"SELECT TOP 20 s.full_name, sc.name, a.date_applied, a.status
                                     FROM applications a
                                     JOIN students s ON s.student_id = a.student_id
                                     JOIN scholarships sc ON sc.scholarship_id = a.scholarship_id
                                     ORDER BY a.date_applied DESC";
                using var cmd = new SqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvApplications.Rows.Add(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetDateTime(2).ToString("MMM dd, yyyy"),
                        reader.GetString(3));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Could not load dashboard data: " + ex.Message, "Dashboard");
            }
        }

        private static int Scalar(SqlConnection conn, string sql)
        {
            using var cmd = new SqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void ShowPage(UserControl page)
        {
            pnlHome.Visible = false;
            foreach (UserControl p in pages)
            {
                p.Visible = p == page;
            }
        }

        private void ShowHome()
        {
            foreach (UserControl p in pages)
            {
                p.Visible = false;
            }
            pnlHome.Visible = true;
            LoadDashboard();
        }

        private void Logout()
        {
            new LandingForm().Show();
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e) { ShowHome(); }
        private void btnScholarships_Click(object sender, EventArgs e) { ShowPage(scholarshipsPage); }
        private void btnStudents_Click(object sender, EventArgs e) { ShowPage(studentsPage); }
        private void btnApplications_Click(object sender, EventArgs e) { ShowPage(applicationsPage); }
        private void btnCommunications_Click(object sender, EventArgs e) { ShowPage(communicationsPage); }
        private void btnSettings_Click(object sender, EventArgs e) { ShowPage(settingsPage); }
        private void btnSupport_Click(object sender, EventArgs e) { new SupportForm().Show(); }
    }
}
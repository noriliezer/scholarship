using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using scholarship;

namespace scholarship
{
    public partial class StudentDashboardForm : Form
    {
        public StudentDashboardForm()
        {
            InitializeComponent();
            WireEvents();
            LoadDashboard();
        }

        private void WireEvents()
        {
            navBrowse.MouseEnter += HoverOn; navBrowse.MouseLeave += HoverOff;
            navApplications.MouseEnter += HoverOn; navApplications.MouseLeave += HoverOff;
            navMessages.MouseEnter += HoverOn; navMessages.MouseLeave += HoverOff;
            navProfile.MouseEnter += HoverOn; navProfile.MouseLeave += HoverOff;
            navSettings.MouseEnter += HoverOn; navSettings.MouseLeave += HoverOff;

            navBrowse.Click += (s, e) => new BrowseScholarshipsPage().ShowDialog(this);
            navApplications.Click += (s, e) => new StudentApplicationsPage().ShowDialog(this);
            navMessages.Click += (s, e) => new StudentMessagesPage().ShowDialog(this);
            navProfile.Click += (s, e) => new StudentProfilePage().ShowDialog(this);
            navSettings.Click += (s, e) => new StudentSettingsPage().ShowDialog(this);
        }

        private void HoverOn(object sender, EventArgs e) => ((Label)sender).BackColor = Color.FromArgb(52, 58, 64);
        private void HoverOff(object sender, EventArgs e) => ((Label)sender).BackColor = Color.FromArgb(33, 37, 41);

        private void LoadDashboard()
        {
            lblWelcome.Text = $"Welcome back, {Session.StudentName}!";

            try
            {
                var (open, mine, accepted) = Db.GetStudentDashboardStats(Session.StudentId);

                cardsPanel.Controls.Clear();
                cardsPanel.Controls.Add(Ui.Card("Open Scholarships", open.ToString(), Ui.StudentPrimary));
                cardsPanel.Controls.Add(Ui.Card("My Applications", mine.ToString(), Ui.StudentWarning));
                cardsPanel.Controls.Add(Ui.Card("Accepted", accepted.ToString(), Ui.StudentSuccess));

                lstDeadlines.Items.Clear();
                foreach (var s in Db.GetAvailableScholarships().Take(6))
                    lstDeadlines.Items.Add($"{s.Deadline:yyyy-MM-dd}  —  {s.Name}  ({s.Remaining} slots left)");

                lstUpdates.Items.Clear();
                foreach (var m in Db.GetMessagesByStudent(Session.StudentId).Take(6))
                    lstUpdates.Items.Add((m.IsRead ? "○ " : "● ") + m.Title);

                recommendedPanel.Controls.Clear();
                foreach (var s in Db.GetAvailableScholarships().Take(6))
                    recommendedPanel.Controls.Add(MakeCard(s));
            }
            catch (Exception ex)
            {
                Ui.Error("Could not load dashboard: " + ex.Message);
            }
        }

        private Panel MakeCard(ScholarshipInfo s)
        {
            var p = new Panel { BackColor = Color.White, Cursor = Cursors.Hand, Margin = new Padding(8), Size = new Size(270, 130) };
            p.Paint += (o, e) =>
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(225, 225, 225)), 0, 0, p.Width - 1, p.Height - 1);

            p.Controls.Add(new Label
            {
                Text = s.Name,
                Font = new Font("Segoe UI Semibold", 11f),
                Location = new Point(12, 10),
                Size = new Size(245, 44)
            });
            p.Controls.Add(new Label
            {
                Text = $"₱{s.Amount:N2}  •  {s.Remaining} slots left",
                ForeColor = Color.Gray,
                Location = new Point(12, 58),
                AutoSize = true
            });
            p.Controls.Add(new Label
            {
                Text = $"Deadline: {s.Deadline:yyyy-MM-dd}",
                ForeColor = Ui.StudentDanger,
                Location = new Point(12, 78),
                AutoSize = true
            });

            var view = Ui.PrimaryBtn("View");
            view.Size = new Size(100, 28);
            view.Location = new Point(12, 98);
            view.Click += (o, e) => new ScholarshipDetailDialog(s).ShowDialog(this);
            p.Controls.Add(view);

            p.DoubleClick += (o, e) => new ScholarshipDetailDialog(s).ShowDialog(this);
            return p;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (Ui.Ask("Log out?"))
            {
                Session.Clear();
                Ui.Open(this, new LandingForm());
            }
        }
    }
}
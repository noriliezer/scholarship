using System;
using System.Drawing;
using System.Windows.Forms;

namespace scholarship
{
    public partial class BrowseScholarshipsPage : Form
    {
        public BrowseScholarshipsPage()
        {
            InitializeComponent();
            LoadScholarships();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadScholarships();

        private void LoadScholarships()
        {
            listPanel.SuspendLayout();
            listPanel.Controls.Clear();

            try
            {
                var items = Db.GetAvailableScholarships(txtSearch.Text);
                foreach (var s in items) listPanel.Controls.Add(MakeCard(s));
                if (items.Count == 0)
                    listPanel.Controls.Add(new Label
                    { Text = "No scholarships found.", AutoSize = true, Padding = new Padding(20) });
            }
            catch (Exception ex)
            {
                Ui.Error("Could not load scholarships: " + ex.Message);
            }
            listPanel.ResumeLayout();
        }

        private Panel MakeCard(ScholarshipInfo s)
        {
            var p = new Panel { BackColor = Color.White, Margin = new Padding(10), Size = new Size(300, 170) };
            p.Paint += (o, e) =>
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220)), 0, 0, p.Width - 1, p.Height - 1);

            p.Controls.Add(new Label
            {
                Text = s.Name,
                Font = new Font("Segoe UI Semibold", 12f),
                Location = new Point(14, 12),
                Size = new Size(270, 44)
            });
            p.Controls.Add(new Label
            {
                Text = $"₱{s.Amount:N2}",
                ForeColor = Color.Gray,
                Location = new Point(14, 60),
                AutoSize = true
            });
            p.Controls.Add(new Label
            {
                Text = $"{s.Remaining} slot(s) left",
                Location = new Point(14, 85),
                AutoSize = true
            });
            p.Controls.Add(new Label
            {
                Text = $"Deadline: {s.Deadline:yyyy-MM-dd}",
                ForeColor = Ui.StudentDanger,
                Location = new Point(14, 110),
                AutoSize = true
            });

            var btn = Ui.PrimaryBtn("View details");
            btn.Size = new Size(120, 30);
            btn.Location = new Point(150, 130);
            btn.Click += (o, e) => new ScholarshipDetailDialog(s).ShowDialog(this);
            p.Controls.Add(btn);

            return p;
        }
    }
}
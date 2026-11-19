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
            cmbCategory.Items.AddRange(Db.GetScholarshipCategories().ToArray());
            cmbCategory.SelectedIndex = 0;
            LoadScholarships();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadScholarships();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => LoadScholarships();

        private void LoadScholarships()
        {
            listPanel.SuspendLayout();
            listPanel.Controls.Clear();
            var items = Db.GetOpenScholarships(txtSearch.Text, cmbCategory.SelectedItem?.ToString());
            foreach (var s in items) listPanel.Controls.Add(MakeCard(s));
            if (items.Count == 0)
                listPanel.Controls.Add(new Label { Text = "No scholarships found.", AutoSize = true, Padding = new Padding(20) });
            listPanel.ResumeLayout();
        }

        private Panel MakeCard(Scholarship s)
        {
            var p = new Panel { BackColor = Color.White, Margin = new Padding(10), Size = new Size(300, 170) };
            p.Paint += (o, e) => e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220)), 0, 0, p.Width - 1, p.Height - 1);

            p.Controls.Add(new Label { Text = s.Name, Font = new Font("Segoe UI Semibold", 12f), Location = new Point(14, 12), Size = new Size(270, 44) });
            p.Controls.Add(new Label { Text = s.Description, ForeColor = Color.Gray, Location = new Point(14, 60), Size = new Size(270, 40) });
            p.Controls.Add(new Label { Text = $"₱{s.Amount:N0}/sem   •   {s.Category}", Location = new Point(14, 105), AutoSize = true });
            p.Controls.Add(new Label { Text = $"Deadline: {s.Deadline:yyyy-MM-dd}", ForeColor = Ui.Danger, Location = new Point(14, 125), AutoSize = true });

            var btn = Ui.PrimaryButton("View details");
            btn.Size = new Size(120, 30);
            btn.Location = new Point(150, 120);
            btn.Click += (o, e) => new ScholarshipDetailDialog(s).ShowDialog(this);
            p.Controls.Add(btn);

            return p;
        }
    }
}
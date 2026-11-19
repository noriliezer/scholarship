using System;
using System.Windows.Forms;

namespace scholarship
{
    public partial class ScholarshipDetailDialog : Form
    {
        private readonly Scholarship _s;

        public ScholarshipDetailDialog(Scholarship s)
        {
            _s = s;
            InitializeComponent();
            Text = s.Name;
            lblName.Text = s.Name;
            lblMeta.Text = $"₱{s.Amount:N0}   •   {s.Category}   •   Deadline: {s.Deadline:yyyy-MM-dd}";
            txtDescription.Text = s.Description ?? "(No description)";

            bool already = Db.HasApplied(Session.StudentId, s.ScholarshipId);
            btnApply.Enabled = !already;
            btnApply.Text = already ? "Already applied" : "Apply now";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            using var dlg = new ApplyDialog(_s);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Ui.ShowInfo("Application submitted!");
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
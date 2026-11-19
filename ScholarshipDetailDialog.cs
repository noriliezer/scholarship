using System;
using System.Windows.Forms;

namespace scholarship
{
    public partial class ScholarshipDetailDialog : Form
    {
        private readonly ScholarshipInfo _s;

        public ScholarshipDetailDialog(ScholarshipInfo s)
        {
            _s = s;
            InitializeComponent();
            Text = s.Name;
            lblName.Text = s.Name;
            lblMeta.Text = $"₱{s.Amount:N2}   •   Deadline: {s.Deadline:yyyy-MM-dd}   •   {s.Status}";
            lblSlots.Text = $"Slots: {s.Slots} total — {s.Remaining} remaining";

            bool already = Db.HasApplied(Session.StudentId, s.ScholarshipId);
            btnApply.Enabled = !already && s.Remaining > 0 && s.Status == "Available";
            btnApply.Text = already ? "Already applied"
                          : s.Remaining <= 0 ? "No slots left"
                          : "Apply now";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!Ui.Ask($"Apply to \"{_s.Name}\"?")) return;
            try
            {
                // Calls your 2-argument method!
                Db.SubmitApplication(Session.StudentId, _s.ScholarshipId);
                Ui.Info("Application submitted. Await admin approval.");
                Close();
            }
            catch (Exception ex)
            {
                Ui.Error("Submission failed: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
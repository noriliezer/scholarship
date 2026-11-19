using System;
using System.Windows.Forms;

namespace scholarship
{
    public partial class ApplyDialog : Form
    {
        private readonly Scholarship _s;

        public ApplyDialog(Scholarship s)
        {
            _s = s;
            InitializeComponent();
            Text = "Apply — " + s.Name;
            lblHeader.Text = $"Applying for: {s.Name}";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEssay.Text))
            {
                Ui.ShowError("Please write an essay before submitting.");
                return;
            }
            try
            {
                Db.SubmitApplication(Session.StudentId, _s.ScholarshipId, txtEssay.Text.Trim());
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Ui.ShowError("Submission failed:\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
using System;
using System.Windows.Forms;
using scholarship;

namespace scholarship
{
    public partial class ChangePasswordDialog : Form
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNew.Text.Length < 8)
            {
                Ui.Error("Password must be at least 8 characters.");
                return;
            }
            if (txtNew.Text != txtConfirm.Text)
            {
                Ui.Error("Passwords do not match.");
                return;
            }

            try
            {
                if (!Db.VerifyStudentPassword(Session.StudentId, txtOld.Text))
                {
                    Ui.Error("Current password is incorrect.");
                    return;
                }
                Db.UpdateStudentPassword(Session.StudentId, txtNew.Text);
                Ui.Info("Password updated.");
                Close();
            }
            catch (Exception ex)
            {
                Ui.Error("Could not update password: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
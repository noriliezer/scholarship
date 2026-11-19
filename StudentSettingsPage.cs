using System;
using System.Windows.Forms;
using ScholarshipApp;

namespace scholarship
{
    public partial class StudentSettingsPage : Form
    {
        public StudentSettingsPage()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e) =>
            new ChangePasswordDialog().ShowDialog(this);

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (Ui.Confirm("Log out?"))
            {
                Session.Clear();
                new LandingForm().Show();
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
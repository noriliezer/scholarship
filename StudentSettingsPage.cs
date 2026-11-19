using System;
using System.Windows.Forms;
using scholarship;

namespace ScholarshipApp
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
            if (Ui.Ask("Log out?"))
            {
                Session.Clear();
                Ui.Open(this, new LandingForm());
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
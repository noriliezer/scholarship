using System;
using System.Windows.Forms;
using scholarship;

namespace ScholarshipApp
{
    public partial class StudentProfilePage : Form
    {
        private StudentInfo _s;

        public StudentProfilePage()
        {
            InitializeComponent();
            _s = Db.GetStudentById(Session.StudentId);
            if (_s == null) { Close(); return; }

            txtName.Text = _s.FullName;
            txtEmail.Text = _s.Email;
            txtCourse.Text = _s.Course;
            txtYear.Text = _s.YearLevel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Ui.Error("Full name is required.");
                return;
            }

            _s.FullName = txtName.Text.Trim();
            _s.Email = txtEmail.Text.Trim();
            _s.Course = txtCourse.Text.Trim();
            _s.YearLevel = txtYear.Text.Trim();

            try
            {
                Db.UpdateStudentProfile(_s);
                Session.StudentName = _s.FullName;
                Ui.Info("Profile updated.");
            }
            catch (Exception ex)
            {
                Ui.Error("Could not update profile: " + ex.Message);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e) =>
            new ChangePasswordDialog().ShowDialog(this);
    }
}
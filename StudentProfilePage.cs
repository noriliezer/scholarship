using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace scholarship
{
    public partial class StudentProfilePage : Form
    {
        private Student _s;

        public StudentProfilePage()
        {
            InitializeComponent();
            _s = Db.GetStudentById(Session.StudentId);
            if (_s == null) { Close(); return; }

            txtName.Text = _s.FullName;
            txtEmail.Text = _s.Email;
            txtCourse.Text = _s.Course;
            txtYear.Text = _s.YearLevel;
            txtGpa.Text = _s.Gpa.ToString("0.00");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                Ui.ShowError("Name and Email are required.");
                return;
            }
            if (!double.TryParse(txtGpa.Text, out var gpa))
            {
                Ui.ShowError("GPA must be a number.");
                return;
            }

            _s.FullName = txtName.Text.Trim();
            _s.Email = txtEmail.Text.Trim();
            _s.Course = txtCourse.Text.Trim();
            _s.YearLevel = txtYear.Text.Trim();
            _s.Gpa = gpa;

            Db.UpdateStudentProfile(_s);
            Session.FullName = _s.FullName;
            Ui.ShowInfo("Profile updated.");
        }

        private void btnChangePassword_Click(object sender, EventArgs e) =>
            new ChangePasswordDialog().ShowDialog(this);
    }
}
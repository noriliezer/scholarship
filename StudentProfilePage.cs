using System;
using System.Drawing;
using System.Windows.Forms;
using scholarship;

namespace scholarship
{
    public partial class StudentProfilePage : Form
    {
        private TextBox _name, _email, _course, _year;
        private StudentInfo _s;

        public StudentProfilePage()
        {
            Text = "My Profile";
            Width = 640; Height = 450;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            _s = Db.GetStudentById(Session.StudentId);

            if (_s == null) { Close(); return; }

            int y = 60, lx = 20, ix = 160, w = 440;
            Controls.Add(new Label { Text = "My Profile", Font = Ui.TitleFont, Location = new Point(20, 15), AutoSize = true });

            _name = AddField("Full Name", ref y, lx, ix, w, _s.FullName);
            _email = AddField("Email", ref y, lx, ix, w, _s.Email);
            _course = AddField("Course", ref y, lx, ix, w, _s.Course);
            _year = AddField("Year Level", ref y, lx, ix, w, _s.YearLevel);

            var save = Ui.PrimaryButton("Save Changes");
            save.Location = new Point(20, y + 20);
            save.Click += Save_Click;
            Controls.Add(save);

            var changePw = Ui.GhostButton("Change Password");
            changePw.Location = new Point(170, y + 20);
            changePw.Click += (s, e) => new ChangePasswordDialog().ShowDialog(this);
            Controls.Add(changePw);
        }

        private TextBox AddField(string label, ref int y, int lx, int ix, int w, string value)
        {
            Controls.Add(new Label { Text = label, Location = new Point(lx, y + 4), AutoSize = true });
            var tb = new TextBox { Location = new Point(ix, y), Width = w, Text = value ?? "" };
            Controls.Add(tb);
            y += 40;
            return tb;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_name.Text) || string.IsNullOrWhiteSpace(_email.Text))
            {
                Ui.Error("Name and Email are required.");
                return;
            }

            _s.FullName = _name.Text.Trim();
            _s.Email = _email.Text.Trim();
            _s.Course = _course.Text.Trim();
            _s.YearLevel = _year.Text.Trim();

            Db.UpdateStudentProfile(_s);
            Session.StudentName = _s.FullName;
            Ui.Info("Profile updated.");
        }
    }
}
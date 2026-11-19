using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace scholarship
{
    public class ChangePasswordDialog : Form
    {
        private TextBox _old, _new, _confirm;

        public ChangePasswordDialog()
        {
            Text = "Change Password";
            Width = 400; Height = 280;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Font = Ui.BodyFont;
            BuildUi();
        }

        private void BuildUi()
        {
            int y = 20;
            _old = Add("Current password", ref y);
            _new = Add("New password", ref y);
            _confirm = Add("Confirm new", ref y);

            var ok = Ui.PrimaryButton("Update");
            ok.Location = new Point(20, y + 10);
            ok.Click += Ok_Click;
            Controls.Add(ok);

            var cancel = Ui.GhostButton("Cancel");
            cancel.Location = new Point(170, y + 10);
            cancel.Click += (s, e) => Close();
            Controls.Add(cancel);
        }

        private TextBox Add(string label, ref int y)
        {
            Controls.Add(new Label { Text = label, Location = new Point(20, y), AutoSize = true });
            y += 22;
            var tb = new TextBox { Location = new Point(20, y), Width = 340, UseSystemPasswordChar = true };
            Controls.Add(tb);
            y += 36;
            return tb;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (_new.Text.Length < 6) { Ui.ShowError("Password must be at least 6 characters."); return; }
            if (_new.Text != _confirm.Text) { Ui.ShowError("Passwords do not match."); return; }

            var verify = Db.AuthenticateStudent(
                Db.GetStudentById(Session.StudentId).StudentNo,
                Hash(_old.Text));
            if (verify == null) { Ui.ShowError("Current password is incorrect."); return; }

            Db.UpdateStudentPassword(Session.StudentId, Hash(_new.Text));
            Ui.ShowInfo("Password updated.");
            Close();
        }

        // Use the SAME hash function as your existing login/registration code.
        private static string Hash(string input)
        {
            using var sha = SHA256.Create();
            return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }
}
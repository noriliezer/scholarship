using System;
using System.Drawing;
using System.Windows.Forms;
using scholarship;

namespace scholarship
{
    public partial class StudentSettingsPage : Form
    {
        public StudentSettingsPage()
        {
            Text = "Settings";
            Width = 500; Height = 320;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            Controls.Add(new Label { Text = "Settings", Font = Ui.TitleFont, Location = new Point(20, 18), AutoSize = true });

            var changePw = Ui.PrimaryButton("Change password");
            changePw.Location = new Point(20, 70);
            changePw.Click += (s, e) => new ChangePasswordDialog().ShowDialog(this);
            Controls.Add(changePw);

            var logout = Ui.GhostButton("Log out");
            logout.Location = new Point(20, 120);
            logout.Click += (s, e) =>
            {
                if (Ui.Ask("Log out?"))
                {
                    Session.Clear();
                    Ui.Open(this, new LandingForm());
                }
            };
            Controls.Add(logout);

            var close = Ui.GhostButton("Close");
            close.Location = new Point(20, 220);
            close.Click += (s, e) => Close();
            Controls.Add(close);
        }
    }
}
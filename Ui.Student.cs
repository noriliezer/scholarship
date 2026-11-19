using System.Drawing;
using System.Windows.Forms;

namespace ScholarshipApp
{
    public static partial class Ui
    {
        public static readonly Color StudentPrimary = Color.FromArgb(0, 120, 215);
        public static readonly Color StudentSuccess = Color.FromArgb(40, 167, 69);
        public static readonly Color StudentDanger = Color.FromArgb(220, 53, 69);
        public static readonly Color StudentWarning = Color.FromArgb(255, 193, 7);

        public static void Info(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static void Error(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public static bool Ask(string msg) => MessageBox.Show(msg, "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static Button PrimaryBtn(string text)
        {
            var b = new Button
            {
                Text = text,
                BackColor = StudentPrimary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5f),
                Size = new Size(140, 34),
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        public static Button GhostBtn(string text)
        {
            var b = new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5f),
                Size = new Size(140, 34),
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderColor = Color.LightGray;
            return b;
        }

        public static Panel Card(string title, string value, Color accent)
        {
            var p = new Panel
            {
                BackColor = Color.White,
                Size = new Size(220, 100),
                Margin = new Padding(8)
            };
            p.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(230, 230, 230)), 0, 0, p.Width - 1, p.Height - 1);
                using var br = new SolidBrush(accent);
                e.Graphics.FillRectangle(br, 0, 0, 6, p.Height);
            };
            p.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.Gray,
                Location = new Point(18, 15),
                AutoSize = true
            });
            p.Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI Semibold", 20f),
                ForeColor = Color.FromArgb(40, 40, 40),
                Location = new Point(18, 38),
                AutoSize = true
            });
            return p;
        }
    }
}
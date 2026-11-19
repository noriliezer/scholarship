using System;
using System.Drawing;
using System.Windows.Forms;

namespace scholarship
{
    public static class Ui
    {
        public static readonly Color Primary = Color.FromArgb(0, 120, 215);
        public static readonly Color Success = Color.FromArgb(40, 167, 69);
        public static readonly Color Danger = Color.FromArgb(220, 53, 69);
        public static readonly Color Warning = Color.FromArgb(255, 193, 7);
        public static readonly Color Surface = Color.WhiteSmoke;

        public static readonly Color StudentPrimary = Primary;
        public static readonly Color StudentSuccess = Success;
        public static readonly Color StudentDanger = Danger;
        public static readonly Color StudentWarning = Warning;

        public static readonly Font BodyFont = new Font("Segoe UI", 9.5f);
        public static readonly Font TitleFont = new Font("Segoe UI Semibold", 15f);

        public static void ShowInfo(string msg) => MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public static void Info(string msg) => ShowInfo(msg);
        public static void Error(string msg) => ShowError(msg);

        public static bool Confirm(string msg) =>
            MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static bool Ask(string msg) => Confirm(msg);

        public static void Open(Form current, Form next)
        {
            next.Show();
            current.Hide();
        }

        public static Button PrimaryButton(string text)
        {
            var b = new Button
            {
                Text = text,
                BackColor = Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = BodyFont,
                Height = 34,
                Width = 140,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        public static Button PrimaryBtn(string text) => PrimaryButton(text);

        public static Button GhostButton(string text)
        {
            var b = new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                Font = BodyFont,
                Height = 34,
                Width = 140,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderColor = Color.LightGray;
            return b;
        }

        public static Button GhostBtn(string text) => GhostButton(text);

        public static Panel SummaryCard(string title, string value, Color accent)
        {
            var p = new Panel { BackColor = Color.White, Height = 100, Width = 220, Margin = new Padding(8) };
            p.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.DrawRectangle(new Pen(Color.FromArgb(230, 230, 230)), 0, 0, p.Width - 1, p.Height - 1);
                using var br = new SolidBrush(accent);
                g.FillRectangle(br, 0, 0, 6, p.Height);
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

        public static Panel Card(string title, string value, Color accent) => SummaryCard(title, value, accent);

        public static void ApplyGradient(Panel panel)
        {
            ApplyGradient(panel, Color.FromArgb(140, 205, 205), Color.FromArgb(150, 220, 230));
        }

        public static void ApplyGradient(Panel panel, Color c1, Color c2)
        {
            panel.Paint += (s, e) =>
            {
                using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(panel.ClientRectangle, c1, c2, 90F);
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            };
        }

        public static void LoadLogo(PictureBox pic)
        {
            // Placeholder
        }
    }
}
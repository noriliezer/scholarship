using System.Drawing.Drawing2D;
using System.Reflection;

namespace ScholarshipApp
{
    public static class Ui
    {
        public static void ApplyGradient(Panel panel, Color? top = null, Color? bottom = null)
        {
            Color c1 = top ?? Color.FromArgb(92, 184, 168);
            Color c2 = bottom ?? Color.FromArgb(205, 237, 240);

            typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                         ?.SetValue(panel, true);

            panel.Paint += (s, e) =>
            {
                if (panel.ClientRectangle.Width <= 0 || panel.ClientRectangle.Height <= 0) return;
                using var br = new LinearGradientBrush(panel.ClientRectangle, c1, c2, 90f);
                e.Graphics.FillRectangle(br, panel.ClientRectangle);
            };
            panel.Resize += (s, e) => panel.Invalidate();
        }

        public static void Open(Form from, Form to)
        {
            to.FormClosed += (s, e) => from.Close();
            to.Show();
            from.Hide();
        }

        public static void LoadLogo(PictureBox pic)
        {
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly();

                // 1. Look for it inside the Database folder
                using Stream stream = asm.GetManifestResourceStream("scholarship.Database.logoSchool.jpg");

                if (stream != null)
                {
                    pic.Image = Image.FromStream(stream);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }

                // 2. Fallback: Look for it in the root folder (in case you move it later)
                using Stream fallbackStream = asm.GetManifestResourceStream("scholarship.logoSchool.jpg");
                if (fallbackStream != null)
                {
                    pic.Image = Image.FromStream(fallbackStream);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                // Fails silently
            }
        }
    }
}
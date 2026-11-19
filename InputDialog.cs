using System.Linq;

namespace scholarship
{
    public class InputDialog : Form
    {
        private readonly List<TextBox> boxes = new List<TextBox>();

        private InputDialog(string title, (string Label, string Value, bool ReadOnly)[] fields)
        {
            Text = title;
            Font = new Font("Arial", 11F);
            BackColor = Color.FromArgb(228, 226, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            int y = 16;
            foreach (var field in fields)
            {
                Controls.Add(new Label
                {
                    Text = field.Label,
                    AutoSize = true,
                    Font = new Font("Arial", 11F, FontStyle.Bold),
                    Location = new Point(20, y)
                });

                var box = new TextBox
                {
                    Text = field.Value,
                    ReadOnly = field.ReadOnly,
                    BackColor = field.ReadOnly ? Color.LightGray : Color.FromArgb(238, 244, 240),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(20, y + 24),
                    Size = new Size(440, 30)
                };
                boxes.Add(box);
                Controls.Add(box);
                y += 72;
            }

            var save = new Button
            {
                Text = "Save",
                DialogResult = DialogResult.OK,
                Location = new Point(250, y),
                Size = new Size(100, 36),
                BackColor = Color.FromArgb(150, 226, 236),
                FlatStyle = FlatStyle.Flat
            };
            var cancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(360, y),
                Size = new Size(100, 36),
                BackColor = Color.FromArgb(226, 230, 226),
                FlatStyle = FlatStyle.Flat
            };

            Controls.Add(save);
            Controls.Add(cancel);
            AcceptButton = save;
            CancelButton = cancel;
            ClientSize = new Size(480, y + 60);
        }

        public static string[] Ask(string title, (string Label, string Value, bool ReadOnly)[] fields)
        {
            using var dialog = new InputDialog(title, fields);
            if (dialog.ShowDialog() != DialogResult.OK) return null;
            return dialog.boxes.Select(b => b.Text.Trim()).ToArray();
        }
    }
}
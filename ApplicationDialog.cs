using Microsoft.Data.SqlClient;

namespace ScholarshipApp
{
    public class ApplicationDialog : Form
    {
        private readonly ComboBox cmbStudent = new ComboBox();
        private readonly ComboBox cmbScholarship = new ComboBox();
        private readonly Func<string, int, string> validate;

        public string StudentId { get; private set; }
        public int ScholarshipId { get; private set; }

        public ApplicationDialog(Func<string, int, string> validate)
        {
            this.validate = validate;

            Text = "Add Application";
            Font = new Font("Arial", 11F);
            BackColor = Color.FromArgb(228, 226, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(480, 240);

            Controls.Add(new Label
            {
                Text = "Student",
                AutoSize = true,
                Font = new Font("Arial", 11F, FontStyle.Bold),
                Location = new Point(20, 16)
            });

            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.Location = new Point(20, 44);
            cmbStudent.Size = new Size(440, 30);
            Controls.Add(cmbStudent);

            Controls.Add(new Label
            {
                Text = "Scholarship (slots left)",
                AutoSize = true,
                Font = new Font("Arial", 11F, FontStyle.Bold),
                Location = new Point(20, 96)
            });

            cmbScholarship.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbScholarship.Location = new Point(20, 124);
            cmbScholarship.Size = new Size(440, 30);
            Controls.Add(cmbScholarship);

            var save = new Button
            {
                Text = "Save",
                Location = new Point(250, 180),
                Size = new Size(100, 36),
                BackColor = Color.FromArgb(150, 226, 236),
                FlatStyle = FlatStyle.Flat
            };
            var cancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(360, 180),
                Size = new Size(100, 36),
                BackColor = Color.FromArgb(226, 230, 226),
                FlatStyle = FlatStyle.Flat
            };

            save.Click += (s, e) => Save();
            Controls.Add(save);
            Controls.Add(cancel);
            CancelButton = cancel;

            LoadStudents();
            LoadScholarships();
        }

        private void LoadStudents()
        {
            try
            {
                using var conn = Db.Open();
                using var cmd = new SqlCommand("SELECT student_id, full_name FROM students ORDER BY full_name", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    cmbStudent.Items.Add(new Option { Id = id, Text = reader.GetString(1) + " (" + id + ")" });
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Applications");
            }
        }

        private void LoadScholarships()
        {
            const string sql = @"SELECT s.scholarship_id, s.name,
                                        s.slots - (SELECT COUNT(*) FROM applications a
                                                   WHERE a.scholarship_id = s.scholarship_id AND a.status = 'Accepted') AS remaining
                                 FROM scholarships s
                                 WHERE s.status = 'Available'
                                   AND s.slots - (SELECT COUNT(*) FROM applications a
                                                  WHERE a.scholarship_id = s.scholarship_id AND a.status = 'Accepted') > 0
                                 ORDER BY s.name";
            try
            {
                using var conn = Db.Open();
                using var cmd = new SqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbScholarship.Items.Add(new Option
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1) + " (" + reader.GetInt32(2) + " slots left)"
                    });
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(Db.Friendly(ex), "Applications");
            }
        }

        private void Save()
        {
            if (cmbStudent.SelectedItem is not Option student || cmbScholarship.SelectedItem is not Option scholarship)
            {
                MessageBox.Show("Choose a student and a scholarship.", "Applications");
                return;
            }

            string error = validate((string)student.Id, (int)scholarship.Id);
            if (error != null)
            {
                MessageBox.Show(error, "Applications");
                return;
            }

            StudentId = (string)student.Id;
            ScholarshipId = (int)scholarship.Id;
            DialogResult = DialogResult.OK;
        }

        private sealed class Option
        {
            public object Id { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
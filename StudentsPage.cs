using System.Globalization;
using Microsoft.Data.SqlClient;

namespace ScholarshipApp
{
    public partial class StudentsPage : UserControl
    {
        public StudentsPage()
        {
            InitializeComponent();
            foreach (string header in new[] { "Student ID", "Name", "Course", "Year Level", "Email" })
            {
                dgvStudents.Columns.Add(header, header);
            }
            foreach (DataGridViewColumn column in dgvStudents.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            btnAdd.Click += (s, e) => AddStudent();
            btnEdit.Click += (s, e) => EditStudent();
            btnDelete.Click += (s, e) => DeleteStudent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible) LoadData();
        }

        private void LoadData()
        {
            dgvStudents.Rows.Clear();
            try
            {
                using var conn = Db.Open();
                using var cmd = new SqlCommand("SELECT student_id, full_name, course, year_level, email FROM students ORDER BY full_name", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvStudents.Rows.Add(
                        Db.Str(reader, 0),
                        Db.Str(reader, 1),
                        Db.Str(reader, 2),
                        Db.Str(reader, 3),
                        Db.Str(reader, 4));
                }
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void AddStudent()
        {
            string[] v = InputDialog.Ask("Add Student", new[]
            {
                ("Student ID", "", false),
                ("Full Name", "", false),
                ("Course", "", false),
                ("Year Level (1-6)", "1", false),
                ("Email (optional)", "", false)
            });
            if (v == null) return;

            string error = Validate(v);
            if (error != null)
            {
                Notify(error);
                return;
            }

            try
            {
                Db.Execute("INSERT INTO students (student_id, full_name, course, year_level, email) VALUES (@id, @n, @c, @y, @e)",
                    ("@id", v[0]), ("@n", v[1]), ("@c", Db.NullIfEmpty(v[2])), ("@y", v[3]), ("@e", Db.NullIfEmpty(v[4])));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void EditStudent()
        {
            if (dgvStudents.CurrentRow == null)
            {
                Notify("Select a student first.");
                return;
            }

            var row = dgvStudents.CurrentRow;
            string id = Cell(row, 0);

            string[] v = InputDialog.Ask("Edit Student", new[]
            {
                ("Student ID", id, true),
                ("Full Name", Cell(row, 1), false),
                ("Course", Cell(row, 2), false),
                ("Year Level (1-6)", Cell(row, 3), false),
                ("Email (optional)", Cell(row, 4), false)
            });
            if (v == null) return;

            v[0] = id;
            string error = Validate(v);
            if (error != null)
            {
                Notify(error);
                return;
            }

            try
            {
                Db.Execute("UPDATE students SET full_name = @n, course = @c, year_level = @y, email = @e WHERE student_id = @id",
                    ("@n", v[1]), ("@c", Db.NullIfEmpty(v[2])), ("@y", v[3]), ("@e", Db.NullIfEmpty(v[4])), ("@id", id));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void DeleteStudent()
        {
            if (dgvStudents.CurrentRow == null)
            {
                Notify("Select a student first.");
                return;
            }
            string id = Cell(dgvStudents.CurrentRow, 0);
            if (MessageBox.Show($"Delete student {id}?", "Students", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Db.Execute("DELETE FROM students WHERE student_id = @id", ("@id", id));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private static string Validate(string[] v)
        {
            if (string.IsNullOrWhiteSpace(v[0]) || v[0].Length > 20) return "Student ID is required (up to 20 characters).";
            if (string.IsNullOrWhiteSpace(v[1])) return "Full name is required.";
            if (!int.TryParse(v[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int year) || year < 1 || year > 6)
                return "Year level must be a number from 1 to 6.";
            if (v[4].Length > 0 && !v[4].Contains('@')) return "Email must contain @.";

            v[3] = year.ToString(CultureInfo.InvariantCulture);
            return null;
        }

        private static string Cell(DataGridViewRow row, int index)
        {
            return row.Cells[index].Value?.ToString() ?? "";
        }

        private static void Notify(string message)
        {
            MessageBox.Show(message, "Students");
        }
    }
}
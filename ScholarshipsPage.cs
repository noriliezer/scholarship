using System.Globalization;
using Microsoft.Data.SqlClient;

namespace scholarship
{
    public partial class ScholarshipsPage : UserControl
    {
        public ScholarshipsPage()
        {
            InitializeComponent();
            foreach (string header in new[] { "Name", "Amount", "Deadline", "Slots", "Status" })
            {
                dgvScholarships.Columns.Add(header, header);
            }
            foreach (DataGridViewColumn column in dgvScholarships.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            btnAdd.Click += (s, e) => AddScholarship();
            btnEdit.Click += (s, e) => EditScholarship();
            btnDelete.Click += (s, e) => DeleteScholarship();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible) LoadData();
        }

        private void LoadData()
        {
            dgvScholarships.Rows.Clear();
            try
            {
                using var conn = Db.Open();
                using var cmd = new SqlCommand("SELECT scholarship_id, name, amount, deadline, slots, status FROM scholarships ORDER BY name", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int row = dgvScholarships.Rows.Add(
                        reader.GetString(1),
                        reader.GetDecimal(2).ToString("N2"),
                        reader.GetDateTime(3).ToString("yyyy-MM-dd"),
                        reader.GetInt32(4),
                        reader.GetString(5));
                    dgvScholarships.Rows[row].Tag = reader.GetInt32(0);
                }
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void AddScholarship()
        {
            string[] v = InputDialog.Ask("Add Scholarship", new[]
            {
                ("Name", "", false),
                ("Amount", "0.00", false),
                ("Deadline (yyyy-mm-dd)", DateTime.Today.AddMonths(1).ToString("yyyy-MM-dd"), false),
                ("Slots", "1", false),
                ("Status (Available or Closed)", "Available", false)
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
                Db.Execute("INSERT INTO scholarships (name, amount, deadline, slots, status) VALUES (@n, @a, @d, @s, @st)",
                    ("@n", v[0]), ("@a", v[1]), ("@d", v[2]), ("@s", v[3]), ("@st", v[4]));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void EditScholarship()
        {
            if (dgvScholarships.CurrentRow == null)
            {
                Notify("Select a scholarship first.");
                return;
            }

            var row = dgvScholarships.CurrentRow;
            int id = (int)row.Tag;

            string[] v = InputDialog.Ask("Edit Scholarship", new[]
            {
                ("Name", Cell(row, 0), false),
                ("Amount", Cell(row, 1), false),
                ("Deadline (yyyy-mm-dd)", Cell(row, 2), false),
                ("Slots", Cell(row, 3), false),
                ("Status (Available or Closed)", Cell(row, 4), false)
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
                Db.Execute("UPDATE scholarships SET name = @n, amount = @a, deadline = @d, slots = @s, status = @st WHERE scholarship_id = @id",
                    ("@n", v[0]), ("@a", v[1]), ("@d", v[2]), ("@s", v[3]), ("@st", v[4]), ("@id", id));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void DeleteScholarship()
        {
            if (dgvScholarships.CurrentRow == null)
            {
                Notify("Select a scholarship first.");
                return;
            }
            if (MessageBox.Show("Delete this scholarship?", "Scholarships", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Db.Execute("DELETE FROM scholarships WHERE scholarship_id = @id", ("@id", (int)dgvScholarships.CurrentRow.Tag));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private static string Validate(string[] v)
        {
            if (string.IsNullOrWhiteSpace(v[0])) return "Name is required.";
            if (!decimal.TryParse(v[1], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount) || amount < 0)
                return "Amount must be a number, 0 or more.";
            if (!DateTime.TryParseExact(v[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deadline))
                return "Deadline must be in yyyy-mm-dd format.";
            if (!int.TryParse(v[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int slots) || slots < 0)
                return "Slots must be a whole number, 0 or more.";
            if (v[4] != "Available" && v[4] != "Closed") return "Status must be Available or Closed.";

            v[1] = amount.ToString("F2", CultureInfo.InvariantCulture);
            v[2] = deadline.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            v[3] = slots.ToString(CultureInfo.InvariantCulture);
            return null;
        }

        private static string Cell(DataGridViewRow row, int index)
        {
            return row.Cells[index].Value?.ToString() ?? "";
        }

        private static void Notify(string message)
        {
            MessageBox.Show(message, "Scholarships");
        }
    }
}
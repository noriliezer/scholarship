using Microsoft.Data.SqlClient;

namespace scholarship
{
    public partial class ApplicationsPage : UserControl
    {
        public ApplicationsPage()
        {
            InitializeComponent();

            foreach (string header in new[] { "Applicant", "Scholarship", "Date Applied", "Status" })
            {
                dgvApplications.Columns.Add(header, header);
            }
            foreach (DataGridViewColumn column in dgvApplications.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.FillWeight = 100;
            }
            dgvApplications.Columns["Applicant"].FillWeight = 150;
            dgvApplications.Columns["Scholarship"].FillWeight = 150;
            dgvApplications.Columns["Date Applied"].DefaultCellStyle.Format = "MMM dd, yyyy";

            // Wire up events (Buttons are now created in the Designer, not dynamically here)
            btnAddApplication.Click += (s, e) => AddApplication();
            btnApprove.Click += (s, e) => SetStatus("Accepted");
            btnReject.Click += (s, e) => SetStatus("Rejected");
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible) LoadData();
        }

        private void LoadData()
        {
            dgvApplications.Rows.Clear();
            try
            {
                using var conn = Db.Open();
                using var cmd = new SqlCommand(@"SELECT a.application_id, s.full_name, sc.name, a.date_applied, a.status
                                                 FROM applications a
                                                 JOIN students s ON s.student_id = a.student_id
                                                 JOIN scholarships sc ON sc.scholarship_id = a.scholarship_id
                                                 ORDER BY a.date_applied DESC", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int row = dgvApplications.Rows.Add(
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDateTime(3),
                        reader.GetString(4));
                    dgvApplications.Rows[row].Tag = reader.GetInt32(0);
                }
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void AddApplication()
        {
            using var dialog = new ApplicationDialog(ValidateNew);
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                Db.Execute("INSERT INTO applications (student_id, scholarship_id, status) VALUES (@s, @c, 'Pending')",
                    ("@s", dialog.StudentId), ("@c", dialog.ScholarshipId));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private void SetStatus(string status)
        {
            var row = dgvApplications.CurrentRow;
            if (row == null)
            {
                Notify("Select an application first.");
                return;
            }

            int id = (int)row.Tag;
            try
            {
                if (status == "Accepted")
                {
                    if (Cell(row, 3) == "Accepted") return;

                    int scholarshipId = Convert.ToInt32(Db.Scalar(
                        "SELECT scholarship_id FROM applications WHERE application_id = @id", ("@id", id)));
                    if (Remaining(scholarshipId) <= 0)
                    {
                        Notify("No slots left for this scholarship.");
                        return;
                    }
                }

                Db.Execute("UPDATE applications SET status = @s WHERE application_id = @id",
                    ("@s", status), ("@id", id));
                LoadData();
            }
            catch (SqlException ex)
            {
                Notify(Db.Friendly(ex));
            }
        }

        private static string ValidateNew(string studentId, int scholarshipId)
        {
            try
            {
                int duplicates = Convert.ToInt32(Db.Scalar(
                    "SELECT COUNT(*) FROM applications WHERE student_id = @s AND scholarship_id = @c",
                    ("@s", studentId), ("@c", scholarshipId)));
                if (duplicates > 0) return "This student has already applied to this scholarship.";

                if (Remaining(scholarshipId) <= 0) return "This scholarship has no slots left.";

                return null;
            }
            catch (SqlException ex)
            {
                return Db.Friendly(ex);
            }
        }

        private static int Remaining(int scholarshipId)
        {
            return Convert.ToInt32(Db.Scalar(
                "SELECT slots - (SELECT COUNT(*) FROM applications WHERE scholarship_id = @id AND status = 'Accepted') FROM scholarships WHERE scholarship_id = @id",
                ("@id", scholarshipId)));
        }

        private static string Cell(DataGridViewRow row, int index)
        {
            return row.Cells[index].Value?.ToString() ?? "";
        }

        private static void Notify(string message)
        {
            MessageBox.Show(message, "Applications");
        }
    }
}
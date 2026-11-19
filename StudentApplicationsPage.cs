using System;
using System.Drawing;
using System.Windows.Forms;

namespace scholarship
{
    public partial class StudentApplicationsPage : Form
    {
        public StudentApplicationsPage()
        {
            InitializeComponent();
            LoadApps();
        }

        private void LoadApps()
        {
            dgvApps.Rows.Clear();
            try
            {
                var apps = Db.GetApplicationsByStudent(Session.StudentId);
                foreach (var a in apps)
                {
                    int idx = dgvApps.Rows.Add(
                        "A-" + a.ApplicationId,
                        a.ScholarshipName,
                        a.DateApplied.ToString("yyyy-MM-dd"),
                        a.Status);
                    dgvApps.Rows[idx].Tag = a;
                }
                if (apps.Count == 0)
                    dgvApps.Rows.Add("—", "No applications yet.", "", "");
            }
            catch (Exception ex)
            {
                Ui.Error("Could not load applications: " + ex.Message);
            }
        }

        private void dgvApps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 3 || e.Value == null) return;
            var s = e.Value.ToString();
            e.CellStyle.Font = new Font("Segoe UI Semibold", 9.5f);
            switch (s)
            {
                case "Pending": e.CellStyle.ForeColor = Ui.StudentWarning; break;
                case "Accepted": e.CellStyle.ForeColor = Ui.StudentSuccess; break;
                case "Rejected": e.CellStyle.ForeColor = Ui.StudentDanger; break;
                case "Withdrawn": e.CellStyle.ForeColor = Color.Gray; break;
            }
        }

        private void dgvApps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var a = dgvApps.Rows[e.RowIndex].Tag as StudentApplication;
            if (a == null) return;

            if (a.Status == "Pending")
            {
                if (Ui.Ask($"Withdraw application for \"{a.ScholarshipName}\"?"))
                {
                    try
                    {
                        Db.WithdrawApplication(a.ApplicationId, Session.StudentId);
                        LoadApps();
                    }
                    catch (Exception ex) { Ui.Error(ex.Message); }
                }
            }
            else
            {
                Ui.Info(
                    $"Application: A-{a.ApplicationId}\n" +
                    $"Scholarship: {a.ScholarshipName}\n" +
                    $"Status: {a.Status}\n" +
                    $"Applied: {a.DateApplied:yyyy-MM-dd}");
            }
        }
    }
}
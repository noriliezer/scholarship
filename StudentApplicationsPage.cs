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
            LoadApplications();
        }

        private void LoadApplications()
        {
            dgvApplications.Rows.Clear();
            var apps = Db.GetApplicationsByStudent(Session.StudentId);
            foreach (var a in apps)
            {
                var idx = dgvApplications.Rows.Add(
                    "A-" + a.ApplicationId,
                    a.ScholarshipName,
                    a.AppliedAt.ToString("yyyy-MM-dd"),
                    a.Status,
                    a.Status == "Pending" ? "Withdraw" : "View");
                dgvApplications.Rows[idx].Tag = a;
            }
            if (apps.Count == 0)
                dgvApplications.Rows.Add("—", "No applications yet.", "", "", "");
        }

        private void dgvApplications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 3 || e.Value == null) return;
            var status = e.Value.ToString();
            e.CellStyle.Font = new Font("Segoe UI Semibold", 9.5f);
            switch (status)
            {
                case "Pending": e.CellStyle.ForeColor = Ui.Warning; break;
                case "Approved": e.CellStyle.ForeColor = Ui.Success; break;
                case "Rejected": e.CellStyle.ForeColor = Ui.Danger; break;
                case "Withdrawn": e.CellStyle.ForeColor = Color.Gray; break;
            }
        }

        private void dgvApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 4) return;
            var app = dgvApplications.Rows[e.RowIndex].Tag as Application;
            if (app == null) return;

            if (app.Status == "Pending")
            {
                if (Ui.Confirm($"Withdraw application for \"{app.ScholarshipName}\"?"))
                {
                    Db.WithdrawApplication(app.ApplicationId);
                    LoadApplications();
                }
            }
            else
            {
                Ui.ShowInfo(
                    $"Application: A-{app.ApplicationId}\n" +
                    $"Scholarship: {app.ScholarshipName}\n" +
                    $"Status:      {app.Status}\n" +
                    $"Applied:     {app.AppliedAt:yyyy-MM-dd}\n\n" +
                    $"Essay:\n{(string.IsNullOrEmpty(app.Essay) ? "(none)" : app.Essay)}\n\n" +
                    $"Admin comment:\n{(string.IsNullOrEmpty(app.AdminComment) ? "(none)" : app.AdminComment)}");
            }
        }
    }
}
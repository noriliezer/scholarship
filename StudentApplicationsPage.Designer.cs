namespace scholarship
{
    partial class StudentApplicationsPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvApps;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvApps = new System.Windows.Forms.DataGridView();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Text = "My Applications";

            this.dgvApps.AllowUserToAddRows = false;
            this.dgvApps.AllowUserToDeleteRows = false;
            this.dgvApps.Anchor = System.Windows.Forms.AnchorStyles.Top
                                               | System.Windows.Forms.AnchorStyles.Left
                                               | System.Windows.Forms.AnchorStyles.Right
                                               | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApps.BackgroundColor = System.Drawing.Color.White;
            this.dgvApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApps.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvApps.Location = new System.Drawing.Point(20, 60);
            this.dgvApps.MultiSelect = false;
            this.dgvApps.ReadOnly = true;
            this.dgvApps.RowHeadersVisible = false;
            this.dgvApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApps.Size = new System.Drawing.Size(940, 500);
            this.dgvApps.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApps_CellDoubleClick);
            this.dgvApps.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvApps_CellFormatting);

            this.dgvApps.Columns.Add("colId", "ID");
            this.dgvApps.Columns.Add("colSch", "Scholarship");
            this.dgvApps.Columns.Add("colApplied", "Date Applied");
            this.dgvApps.Columns.Add("colStatus", "Status");

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "StudentApplicationsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Applications";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvApps);
        }
    }
}
namespace scholarship
{
    partial class StudentApplicationsPage
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScholarship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplied;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScholarship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Text = "My Applications";

            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.Anchor = System.Windows.Forms.AnchorStyles.Top
                                                       | System.Windows.Forms.AnchorStyles.Left
                                                       | System.Windows.Forms.AnchorStyles.Right
                                                       | System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colScholarship, this.colApplied, this.colStatus, this.colAction });
            this.dgvApplications.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvApplications.Location = new System.Drawing.Point(20, 60);
            this.dgvApplications.MultiSelect = false;
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersVisible = false;
            this.dgvApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplications.Size = new System.Drawing.Size(940, 500);
            this.dgvApplications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplications_CellClick);
            this.dgvApplications.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvApplications_CellFormatting);

            this.colId.HeaderText = "ID"; this.colId.Name = "colId";
            this.colScholarship.HeaderText = "Scholarship"; this.colScholarship.Name = "colScholarship";
            this.colApplied.HeaderText = "Date Applied"; this.colApplied.Name = "colApplied";
            this.colStatus.HeaderText = "Status"; this.colStatus.Name = "colStatus";
            this.colAction.HeaderText = "Action"; this.colAction.Name = "colAction";
            this.colAction.UseColumnTextForButtonValue = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "StudentApplicationsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Applications";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvApplications);
        }
    }
}
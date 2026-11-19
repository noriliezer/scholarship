namespace scholarship
{
    partial class ApplicationsPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnAddApplication = new Button();
            btnApprove = new Button();
            btnReject = new Button();
            dgvApplications = new DataGridView();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(100, 190, 180);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(696, 50);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(236, 240, 232);
            lblTitle.Font = new Font("Arial", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "APPLICATIONS";

            // btnAddApplication
            btnAddApplication.BackColor = Color.FromArgb(226, 230, 226);
            btnAddApplication.Cursor = Cursors.Hand;
            btnAddApplication.FlatAppearance.BorderColor = Color.Gray;
            btnAddApplication.FlatStyle = FlatStyle.Flat;
            btnAddApplication.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnAddApplication.Location = new Point(12, 68);
            btnAddApplication.Name = "btnAddApplication";
            btnAddApplication.Size = new Size(120, 36);
            btnAddApplication.TabIndex = 1;
            btnAddApplication.Text = "Add";
            btnAddApplication.UseVisualStyleBackColor = false;

            // btnApprove
            btnApprove.BackColor = Color.FromArgb(226, 230, 226);
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.FlatAppearance.BorderColor = Color.Gray;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnApprove.Location = new Point(144, 68);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(120, 36);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;

            // btnReject
            btnReject.BackColor = Color.FromArgb(226, 230, 226);
            btnReject.Cursor = Cursors.Hand;
            btnReject.FlatAppearance.BorderColor = Color.Gray;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnReject.Location = new Point(276, 68);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(120, 36);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = false;

            // dgvApplications
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.BackgroundColor = Color.FromArgb(212, 212, 205);
            dgvApplications.BorderStyle = BorderStyle.FixedSingle;
            dgvApplications.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvApplications.ColumnHeadersHeight = 34;
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvApplications.DefaultCellStyle = cellStyle;
            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.Location = new Point(12, 118);
            dgvApplications.MultiSelect = false;
            dgvApplications.Name = "dgvApplications";
            dgvApplications.ReadOnly = true;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.Size = new Size(672, 452);
            dgvApplications.TabIndex = 4;

            headerStyle.BackColor = Color.FromArgb(236, 240, 232);
            headerStyle.Font = new Font("Arial", 12F);
            headerStyle.ForeColor = Color.Black;
            cellStyle.BackColor = Color.FromArgb(236, 240, 232);

            // ApplicationsPage
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            Controls.Add(dgvApplications);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(btnAddApplication);
            Controls.Add(pnlHeader);
            Font = new Font("Arial", 12F);
            Name = "ApplicationsPage";
            Size = new Size(696, 582);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnAddApplication;
        private Button btnApprove;
        private Button btnReject;
        private DataGridView dgvApplications;
    }
}
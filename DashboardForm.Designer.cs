namespace scholarship
{
    partial class DashboardForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

            pnlSidebar = new Panel();
            btnSettings = new Button();
            btnSupport = new Button();
            btnCommunications = new Button();
            btnApplications = new Button();
            btnStudents = new Button();
            btnScholarships = new Button();
            btnHome = new Button();
            lblAppName4 = new Label();
            lblAppName3 = new Label();
            lblAppName2 = new Label();
            lblAppName1 = new Label();
            picLogo = new PictureBox();
            pnlHeader = new Panel();
            lblDashboard = new Label();
            pnlTotal = new Panel();
            lblTotalCount = new Label();
            lblTotalTitle = new Label();
            pnlAvailable = new Panel();
            lblAvailableCount = new Label();
            lblAvailableTitle = new Label();
            pnlAccepted = new Panel();
            lblAcceptedCount = new Label();
            lblAcceptedTitle = new Label();
            pnlRejected = new Panel();
            lblRejectedCount = new Label();
            lblRejectedTitle = new Label();
            dgvApplications = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            pnlContent = new Panel();

            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlHeader.SuspendLayout();
            pnlTotal.SuspendLayout();
            pnlAvailable.SuspendLayout();
            pnlAccepted.SuspendLayout();
            pnlRejected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();

            // pnlSidebar
            pnlSidebar.BackColor = Color.FromArgb(140, 205, 205);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnSupport);
            pnlSidebar.Controls.Add(btnCommunications);
            pnlSidebar.Controls.Add(btnApplications);
            pnlSidebar.Controls.Add(btnStudents);
            pnlSidebar.Controls.Add(btnScholarships);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Controls.Add(lblAppName4);
            pnlSidebar.Controls.Add(lblAppName3);
            pnlSidebar.Controls.Add(lblAppName2);
            pnlSidebar.Controls.Add(lblAppName1);
            pnlSidebar.Controls.Add(picLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 640);
            pnlSidebar.TabIndex = 0;

            // btnSettings
            btnSettings.BackColor = Color.FromArgb(226, 230, 226);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnSettings.Location = new Point(135, 592);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(105, 36);
            btnSettings.TabIndex = 8;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;

            // btnSupport
            btnSupport.BackColor = Color.FromArgb(226, 230, 226);
            btnSupport.Cursor = Cursors.Hand;
            btnSupport.FlatAppearance.BorderSize = 0;
            btnSupport.FlatStyle = FlatStyle.Flat;
            btnSupport.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnSupport.Location = new Point(20, 592);
            btnSupport.Name = "btnSupport";
            btnSupport.Size = new Size(105, 36);
            btnSupport.TabIndex = 7;
            btnSupport.Text = "Support";
            btnSupport.UseVisualStyleBackColor = false;
            btnSupport.Click += btnSupport_Click;

            // btnCommunications
            btnCommunications.BackColor = Color.FromArgb(226, 230, 226);
            btnCommunications.Cursor = Cursors.Hand;
            btnCommunications.FlatAppearance.BorderColor = Color.Gray;
            btnCommunications.FlatStyle = FlatStyle.Flat;
            btnCommunications.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnCommunications.Location = new Point(20, 306);
            btnCommunications.Name = "btnCommunications";
            btnCommunications.Size = new Size(220, 36);
            btnCommunications.TabIndex = 6;
            btnCommunications.Text = "Communications";
            btnCommunications.UseVisualStyleBackColor = false;
            btnCommunications.Click += btnCommunications_Click;

            // btnApplications
            btnApplications.BackColor = Color.FromArgb(226, 230, 226);
            btnApplications.Cursor = Cursors.Hand;
            btnApplications.FlatAppearance.BorderColor = Color.Gray;
            btnApplications.FlatStyle = FlatStyle.Flat;
            btnApplications.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnApplications.Location = new Point(20, 264);
            btnApplications.Name = "btnApplications";
            btnApplications.Size = new Size(220, 36);
            btnApplications.TabIndex = 5;
            btnApplications.Text = "Applications";
            btnApplications.UseVisualStyleBackColor = false;
            btnApplications.Click += btnApplications_Click;

            // btnStudents
            btnStudents.BackColor = Color.FromArgb(226, 230, 226);
            btnStudents.Cursor = Cursors.Hand;
            btnStudents.FlatAppearance.BorderColor = Color.Gray;
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnStudents.Location = new Point(20, 222);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(220, 36);
            btnStudents.TabIndex = 4;
            btnStudents.Text = "Students";
            btnStudents.UseVisualStyleBackColor = false;
            btnStudents.Click += btnStudents_Click;

            // btnScholarships
            btnScholarships.BackColor = Color.FromArgb(226, 230, 226);
            btnScholarships.Cursor = Cursors.Hand;
            btnScholarships.FlatAppearance.BorderColor = Color.Gray;
            btnScholarships.FlatStyle = FlatStyle.Flat;
            btnScholarships.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnScholarships.Location = new Point(20, 180);
            btnScholarships.Name = "btnScholarships";
            btnScholarships.Size = new Size(220, 36);
            btnScholarships.TabIndex = 3;
            btnScholarships.Text = "Scholarships";
            btnScholarships.UseVisualStyleBackColor = false;
            btnScholarships.Click += btnScholarships_Click;

            // btnHome
            btnHome.BackColor = Color.FromArgb(226, 230, 226);
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderColor = Color.Gray;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnHome.Location = new Point(20, 138);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(220, 36);
            btnHome.TabIndex = 2;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;

            // Labels
            lblAppName4.AutoSize = true; lblAppName4.BackColor = Color.Transparent; lblAppName4.Font = new Font("Arial", 11F, FontStyle.Bold); lblAppName4.Location = new Point(120, 90); lblAppName4.Text = "System";
            lblAppName3.AutoSize = true; lblAppName3.BackColor = Color.Transparent; lblAppName3.Font = new Font("Arial", 11F, FontStyle.Bold); lblAppName3.Location = new Point(120, 66); lblAppName3.Text = "Management";
            lblAppName2.AutoSize = true; lblAppName2.BackColor = Color.Transparent; lblAppName2.Font = new Font("Arial", 11F, FontStyle.Bold); lblAppName2.Location = new Point(120, 42); lblAppName2.Text = "Application";
            lblAppName1.AutoSize = true; lblAppName1.BackColor = Color.Transparent; lblAppName1.Font = new Font("Arial", 11F, FontStyle.Bold); lblAppName1.Location = new Point(120, 18); lblAppName1.Text = "Scholarship";

            // picLogo
            picLogo.BackColor = Color.White;
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(14, 18);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 96);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabStop = false;

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(100, 190, 180);
            pnlHeader.Controls.Add(lblDashboard);
            pnlHeader.Name = "pnlHeader";
            lblDashboard.AutoSize = true; lblDashboard.BackColor = Color.Transparent; lblDashboard.Font = new Font("Arial", 13F, FontStyle.Bold); lblDashboard.Location = new Point(10, 10); lblDashboard.Text = "DASHBOARD";

            // Stat Cards
            pnlTotal.BackColor = Color.FromArgb(236, 238, 232); pnlTotal.Controls.Add(lblTotalCount); pnlTotal.Controls.Add(lblTotalTitle);
            lblTotalCount.AutoSize = true; lblTotalCount.Font = new Font("Arial", 19F, FontStyle.Bold); lblTotalCount.Location = new Point(5, 53); lblTotalCount.Text = "0";
            lblTotalTitle.Font = new Font("Arial", 12F, FontStyle.Bold); lblTotalTitle.Location = new Point(5, 5); lblTotalTitle.Size = new Size(154, 43); lblTotalTitle.Text = "Total Application";

            pnlAvailable.BackColor = Color.FromArgb(236, 238, 232); pnlAvailable.Controls.Add(lblAvailableCount); pnlAvailable.Controls.Add(lblAvailableTitle);
            lblAvailableCount.AutoSize = true; lblAvailableCount.Font = new Font("Arial", 19F, FontStyle.Bold); lblAvailableCount.Location = new Point(5, 53); lblAvailableCount.Text = "0";
            lblAvailableTitle.Font = new Font("Arial", 12F, FontStyle.Bold); lblAvailableTitle.Location = new Point(5, 5); lblAvailableTitle.Size = new Size(154, 43); lblAvailableTitle.Text = "Available Scholarships";

            pnlAccepted.BackColor = Color.FromArgb(236, 238, 232); pnlAccepted.Controls.Add(lblAcceptedCount); pnlAccepted.Controls.Add(lblAcceptedTitle);
            lblAcceptedCount.AutoSize = true; lblAcceptedCount.Font = new Font("Arial", 19F, FontStyle.Bold); lblAcceptedCount.Location = new Point(5, 53); lblAcceptedCount.Text = "0";
            lblAcceptedTitle.Font = new Font("Arial", 12F, FontStyle.Bold); lblAcceptedTitle.Location = new Point(5, 5); lblAcceptedTitle.Size = new Size(154, 43); lblAcceptedTitle.Text = "Accepted";

            pnlRejected.BackColor = Color.FromArgb(236, 238, 232); pnlRejected.Controls.Add(lblRejectedCount); pnlRejected.Controls.Add(lblRejectedTitle);
            lblRejectedCount.AutoSize = true; lblRejectedCount.Font = new Font("Arial", 19F, FontStyle.Bold); lblRejectedCount.Location = new Point(5, 53); lblRejectedCount.Text = "0";
            lblRejectedTitle.Font = new Font("Arial", 12F, FontStyle.Bold); lblRejectedTitle.Location = new Point(5, 5); lblRejectedTitle.Size = new Size(154, 43); lblRejectedTitle.Text = "Rejected";

            // dgvApplications
            dgvApplications.BackgroundColor = Color.FromArgb(212, 212, 205);
            headerStyle.BackColor = Color.FromArgb(236, 240, 232);
            headerStyle.Font = new Font("Arial", 12F);
            dgvApplications.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvApplications.ColumnHeadersHeight = 34;
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvApplications.Columns.AddRange(new DataGridViewColumn[] { Column1, Column6, Column2, Column3, Column4, Column5 });
            cellStyle.BackColor = Color.FromArgb(236, 240, 232);
            cellStyle.Font = new Font("Arial", 12F);
            cellStyle.WrapMode = DataGridViewTriState.False;
            dgvApplications.DefaultCellStyle = cellStyle;
            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.Name = "dgvApplications";

            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; Column1.HeaderText = "Applicant";
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; Column6.HeaderText = "Scholarship";
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; Column2.HeaderText = "Date Applied";
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; Column3.HeaderText = "Status";

            // pnlContent (Added a visible border)
            pnlContent.BackColor = Color.FromArgb(228, 226, 204);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(10);
            pnlContent.BorderStyle = BorderStyle.FixedSingle; // <--- VISUAL BOUNDARY

            // DashboardForm
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            ClientSize = new Size(1000, 640);
            Controls.Add(pnlContent); // Fill must be added first
            Controls.Add(pnlSidebar); // Left must be added last to dock correctly
            Font = new Font("Arial", 12F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";

            pnlSidebar.ResumeLayout(false); pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlHeader.ResumeLayout(false); pnlHeader.PerformLayout();
            pnlTotal.ResumeLayout(false); pnlTotal.PerformLayout();
            pnlAvailable.ResumeLayout(false); pnlAvailable.PerformLayout();
            pnlAccepted.ResumeLayout(false); pnlAccepted.PerformLayout();
            pnlRejected.ResumeLayout(false); pnlRejected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private PictureBox picLogo;
        private Label lblAppName1, lblAppName2, lblAppName3, lblAppName4;
        private Button btnHome, btnScholarships, btnStudents, btnApplications, btnCommunications, btnSupport, btnSettings;
        private Panel pnlHeader;
        private Label lblDashboard;
        private Panel pnlTotal, pnlAvailable, pnlAccepted, pnlRejected;
        private Label lblTotalTitle, lblTotalCount, lblAvailableTitle, lblAvailableCount, lblAcceptedTitle, lblAcceptedCount, lblRejectedTitle, lblRejectedCount;
        private DataGridView dgvApplications;
        private DataGridViewTextBoxColumn Column1, Column6, Column2, Column3, Column4, Column5;
        private Panel pnlContent;
    }
}
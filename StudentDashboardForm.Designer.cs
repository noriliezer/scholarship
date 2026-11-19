namespace scholarship
{
    partial class StudentDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblSubBrand;
        private System.Windows.Forms.Label navDashboard;
        private System.Windows.Forms.Label navBrowse;
        private System.Windows.Forms.Label navApplications;
        private System.Windows.Forms.Label navMessages;
        private System.Windows.Forms.Label navProfile;
        private System.Windows.Forms.Label navSettings;
        private System.Windows.Forms.Button btnLogout;

        // Main
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.FlowLayoutPanel cardsPanel;
        private System.Windows.Forms.Label lblDeadlinesTitle;
        private System.Windows.Forms.ListBox lstDeadlines;
        private System.Windows.Forms.Label lblUpdatesTitle;
        private System.Windows.Forms.ListBox lstUpdates;
        private System.Windows.Forms.Label lblRecommendedTitle;
        private System.Windows.Forms.FlowLayoutPanel recommendedPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblSubBrand = new System.Windows.Forms.Label();
            this.navDashboard = new System.Windows.Forms.Label();
            this.navBrowse = new System.Windows.Forms.Label();
            this.navApplications = new System.Windows.Forms.Label();
            this.navMessages = new System.Windows.Forms.Label();
            this.navProfile = new System.Windows.Forms.Label();
            this.navSettings = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.cardsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDeadlinesTitle = new System.Windows.Forms.Label();
            this.lstDeadlines = new System.Windows.Forms.ListBox();
            this.lblUpdatesTitle = new System.Windows.Forms.Label();
            this.lstUpdates = new System.Windows.Forms.ListBox();
            this.lblRecommendedTitle = new System.Windows.Forms.Label();
            this.recommendedPanel = new System.Windows.Forms.FlowLayoutPanel();

            // ---------- Sidebar ----------
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Width = 220;
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Controls.Add(this.lblBrand);
            this.sidebarPanel.Controls.Add(this.lblSubBrand);
            this.sidebarPanel.Controls.Add(this.navDashboard);
            this.sidebarPanel.Controls.Add(this.navBrowse);
            this.sidebarPanel.Controls.Add(this.navApplications);
            this.sidebarPanel.Controls.Add(this.navMessages);
            this.sidebarPanel.Controls.Add(this.navProfile);
            this.sidebarPanel.Controls.Add(this.navSettings);
            this.sidebarPanel.Controls.Add(this.btnLogout);

            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(20, 20);
            this.lblBrand.Text = "Scholarship";

            this.lblSubBrand.AutoSize = true;
            this.lblSubBrand.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSubBrand.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubBrand.Location = new System.Drawing.Point(22, 48);
            this.lblSubBrand.Text = "STUDENT PORTAL";

            ConfigureNav(this.navDashboard, "Dashboard", 100);
            ConfigureNav(this.navBrowse, "Browse Scholarships", 142);
            ConfigureNav(this.navApplications, "My Applications", 184);
            ConfigureNav(this.navMessages, "Messages", 226);
            ConfigureNav(this.navProfile, "My Profile", 268);
            ConfigureNav(this.navSettings, "Settings", 310);

            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.LightGray;
            this.btnLogout.Location = new System.Drawing.Point(15, 680);
            this.btnLogout.Size = new System.Drawing.Size(190, 36);
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.FlatAppearance.BorderSize = 0;

            // ---------- Main ----------
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Controls.Add(this.lblWelcome);
            this.mainPanel.Controls.Add(this.cardsPanel);
            this.mainPanel.Controls.Add(this.lblDeadlinesTitle);
            this.mainPanel.Controls.Add(this.lstDeadlines);
            this.mainPanel.Controls.Add(this.lblUpdatesTitle);
            this.mainPanel.Controls.Add(this.lstUpdates);
            this.mainPanel.Controls.Add(this.lblRecommendedTitle);
            this.mainPanel.Controls.Add(this.recommendedPanel);

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Text = "Welcome back!";

            this.cardsPanel.AutoSize = true;
            this.cardsPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.cardsPanel.Location = new System.Drawing.Point(20, 65);
            this.cardsPanel.WrapContents = false;
            this.cardsPanel.Name = "cardsPanel";

            this.lblDeadlinesTitle.AutoSize = true;
            this.lblDeadlinesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblDeadlinesTitle.Location = new System.Drawing.Point(20, 190);
            this.lblDeadlinesTitle.Text = "Upcoming Deadlines";

            this.lstDeadlines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDeadlines.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstDeadlines.Location = new System.Drawing.Point(20, 220);
            this.lstDeadlines.Size = new System.Drawing.Size(420, 160);

            this.lblUpdatesTitle.AutoSize = true;
            this.lblUpdatesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblUpdatesTitle.Location = new System.Drawing.Point(480, 190);
            this.lblUpdatesTitle.Text = "Recent Updates";

            this.lstUpdates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstUpdates.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstUpdates.Location = new System.Drawing.Point(480, 220);
            this.lstUpdates.Size = new System.Drawing.Size(420, 160);

            this.lblRecommendedTitle.AutoSize = true;
            this.lblRecommendedTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblRecommendedTitle.Location = new System.Drawing.Point(20, 405);
            this.lblRecommendedTitle.Text = "Recommended for You";

            this.recommendedPanel.AutoScroll = true;
            this.recommendedPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.recommendedPanel.Location = new System.Drawing.Point(20, 435);
            this.recommendedPanel.Size = new System.Drawing.Size(880, 240);
            this.recommendedPanel.WrapContents = true;
            this.recommendedPanel.Name = "recommendedPanel";

            // ---------- Form ----------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "StudentDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scholarship Portal — Student";
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebarPanel);
        }

        private void ConfigureNav(System.Windows.Forms.Label lbl, string text, int y)
        {
            lbl.BackColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            lbl.ForeColor = System.Drawing.Color.Gainsboro;
            lbl.Location = new System.Drawing.Point(0, y);
            lbl.Size = new System.Drawing.Size(220, 38);
            lbl.Text = "   " + text;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }
    }
}
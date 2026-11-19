namespace scholarship
{
    partial class BrowseScholarshipsPage
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.FlowLayoutPanel listPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.listPanel = new System.Windows.Forms.FlowLayoutPanel();

            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 100;
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.txtSearch);
            this.headerPanel.Controls.Add(this.cmbCategory);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Browse Scholarships";

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(20, 60);
            this.txtSearch.Size = new System.Drawing.Size(320, 30);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategory.Location = new System.Drawing.Point(360, 60);
            this.cmbCategory.Size = new System.Drawing.Size(200, 30);
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);

            this.listPanel.AutoScroll = true;
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.listPanel.Padding = new System.Windows.Forms.Padding(15);
            this.listPanel.WrapContents = true;
            this.listPanel.Name = "listPanel";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "BrowseScholarshipsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browse Scholarships";
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.headerPanel);
        }
    }
}
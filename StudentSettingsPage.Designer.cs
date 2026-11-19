namespace ScholarshipApp
{
    partial class StudentSettingsPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Text = "Settings";

            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(20, 70);
            this.btnChangePassword.Size = new System.Drawing.Size(180, 36);
            this.btnChangePassword.Text = "Change password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);

            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(20, 120);
            this.btnLogout.Size = new System.Drawing.Size(180, 36);
            this.btnLogout.Text = "Log out";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(20, 220);
            this.btnClose.Size = new System.Drawing.Size(180, 36);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 320);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "StudentSettingsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnClose);
        }
    }
}
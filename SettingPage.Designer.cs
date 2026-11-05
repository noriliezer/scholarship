namespace ScholarshipApp
{
    partial class SettingsPage
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmNewPassword = new Label();
            txtConfirmNewPassword = new TextBox();
            btnChangePassword = new Button();
            btnLogout = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();

            pnlHeader.BackColor = Color.FromArgb(100, 190, 180);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(696, 50);
            pnlHeader.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(236, 240, 232);
            lblTitle.Font = new Font("Arial", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SETTINGS";

            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.BackColor = Color.Transparent;
            lblCurrentPassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblCurrentPassword.Location = new Point(12, 68);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.TabIndex = 1;
            lblCurrentPassword.Text = "Current Password";

            txtCurrentPassword.BackColor = Color.FromArgb(238, 244, 240);
            txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPassword.Font = new Font("Arial", 14F);
            txtCurrentPassword.Location = new Point(12, 102);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(672, 30);
            txtCurrentPassword.TabIndex = 2;
            txtCurrentPassword.UseSystemPasswordChar = true;

            lblNewPassword.AutoSize = true;
            lblNewPassword.BackColor = Color.Transparent;
            lblNewPassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblNewPassword.Location = new Point(12, 152);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "New Password";

            txtNewPassword.BackColor = Color.FromArgb(238, 244, 240);
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Arial", 14F);
            txtNewPassword.Location = new Point(12, 186);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(672, 30);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.UseSystemPasswordChar = true;

            lblConfirmNewPassword.AutoSize = true;
            lblConfirmNewPassword.BackColor = Color.Transparent;
            lblConfirmNewPassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblConfirmNewPassword.Location = new Point(12, 236);
            lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            lblConfirmNewPassword.TabIndex = 5;
            lblConfirmNewPassword.Text = "Confirm New Password";

            txtConfirmNewPassword.BackColor = Color.FromArgb(238, 244, 240);
            txtConfirmNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmNewPassword.Font = new Font("Arial", 14F);
            txtConfirmNewPassword.Location = new Point(12, 270);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.Size = new Size(672, 30);
            txtConfirmNewPassword.TabIndex = 6;
            txtConfirmNewPassword.UseSystemPasswordChar = true;

            btnChangePassword.BackColor = Color.FromArgb(150, 226, 236);
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.FromArgb(10, 30, 60);
            btnChangePassword.Location = new Point(12, 324);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(220, 42);
            btnChangePassword.TabIndex = 7;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;

            btnLogout.BackColor = Color.FromArgb(226, 230, 226);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderColor = Color.Gray;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnLogout.Location = new Point(12, 520);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(160, 40);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            Controls.Add(btnLogout);
            Controls.Add(btnChangePassword);
            Controls.Add(txtConfirmNewPassword);
            Controls.Add(lblConfirmNewPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrentPassword);
            Controls.Add(pnlHeader);
            Font = new Font("Arial", 12F);
            Name = "SettingsPage";
            Size = new Size(696, 582);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmNewPassword;
        private TextBox txtConfirmNewPassword;
        private Button btnChangePassword;
        private Button btnLogout;
    }
}
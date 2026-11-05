namespace ScholarshipApp
{
    partial class LoginForm
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
            pnlLogin = new Panel();
            lblUsernameOrEmail = new Label();
            txtUsernameOrEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            pnlLogin.SuspendLayout();
            SuspendLayout();

            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(txtUsernameOrEmail);
            pnlLogin.Controls.Add(lblUsernameOrEmail);
            pnlLogin.Location = new Point(132, 72);
            pnlLogin.BackColor = Color.FromArgb(140, 205, 205);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(684, 456);
            pnlLogin.TabIndex = 0;

            lblUsernameOrEmail.AutoSize = true;
            lblUsernameOrEmail.BackColor = Color.Transparent;
            lblUsernameOrEmail.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblUsernameOrEmail.Location = new Point(102, 134);
            lblUsernameOrEmail.Name = "lblUsernameOrEmail";
            lblUsernameOrEmail.TabIndex = 0;
            lblUsernameOrEmail.Text = "Username/Email";

            txtUsernameOrEmail.BackColor = Color.FromArgb(238, 244, 240);
            txtUsernameOrEmail.BorderStyle = BorderStyle.FixedSingle;
            txtUsernameOrEmail.Font = new Font("Arial", 19F);
            txtUsernameOrEmail.Location = new Point(102, 168);
            txtUsernameOrEmail.Name = "txtUsernameOrEmail";
            txtUsernameOrEmail.Size = new Size(480, 40);
            txtUsernameOrEmail.TabIndex = 1;

            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblPassword.Location = new Point(102, 254);
            lblPassword.Name = "lblPassword";
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";

            txtPassword.BackColor = Color.FromArgb(238, 244, 240);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Arial", 19F);
            txtPassword.Location = new Point(102, 288);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(480, 40);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;

            btnLogin.BackColor = Color.FromArgb(150, 226, 236);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.FromArgb(10, 30, 60);
            btnLogin.Location = new Point(270, 360);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(144, 43);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            ClientSize = new Size(960, 600);
            Controls.Add(pnlLogin);
            Font = new Font("Arial", 12F);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogin;
        private Label lblUsernameOrEmail;
        private TextBox txtUsernameOrEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}
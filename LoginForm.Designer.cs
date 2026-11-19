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
            btnBack = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsernameOrEmail = new TextBox();
            lblUsernameOrEmail = new Label();
            pnlLogin.SuspendLayout();
            SuspendLayout();

            pnlLogin.Controls.Add(btnBack);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(txtUsernameOrEmail);
            pnlLogin.Controls.Add(lblUsernameOrEmail);

            pnlLogin.Location = new Point(138, 72);
            pnlLogin.BackColor = Color.FromArgb(140, 205, 205);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(684, 456);
            pnlLogin.TabIndex = 0;

            // --- USERNAME SECTION ---
            lblUsernameOrEmail.AutoSize = true;
            lblUsernameOrEmail.BackColor = Color.Transparent;
            lblUsernameOrEmail.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblUsernameOrEmail.Location = new Point(102, 100);
            lblUsernameOrEmail.Name = "lblUsernameOrEmail";
            lblUsernameOrEmail.TabIndex = 0;
            lblUsernameOrEmail.Text = "Username/Email";

            txtUsernameOrEmail.BackColor = Color.FromArgb(238, 244, 240);
            txtUsernameOrEmail.BorderStyle = BorderStyle.FixedSingle;
            txtUsernameOrEmail.Font = new Font("Arial", 19F);
            txtUsernameOrEmail.Location = new Point(102, 134);
            txtUsernameOrEmail.Name = "txtUsernameOrEmail";
            txtUsernameOrEmail.Size = new Size(480, 40); // Width 480, Height 40
            txtUsernameOrEmail.TabIndex = 1;

            // --- PASSWORD SECTION ---
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblPassword.Location = new Point(102, 224);
            lblPassword.Name = "lblPassword";
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";

            txtPassword.BackColor = Color.FromArgb(238, 244, 240);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Arial", 19F);
            txtPassword.Location = new Point(102, 258);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(480, 40); // Width 480, Height 40
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;

            // --- BUTTONS SECTION ---
            // Login Button
            btnLogin.BackColor = Color.FromArgb(150, 226, 236);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.FromArgb(10, 30, 60);
            btnLogin.Location = new Point(102, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(230, 43);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            // Back Button
            btnBack.BackColor = Color.FromArgb(150, 226, 236);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnBack.ForeColor = Color.FromArgb(10, 30, 60);
            btnBack.Location = new Point(352, 340);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(230, 43);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;

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
        private Button btnBack;
    }
}
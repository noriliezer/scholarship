namespace scholarship
{
    partial class RegisterForm
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
            pnlRegister = new Panel();
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnSignUp = new Button();
            pnlRegister.SuspendLayout();
            SuspendLayout();

            pnlRegister.Controls.Add(btnSignUp);
            pnlRegister.Controls.Add(txtConfirmPassword);
            pnlRegister.Controls.Add(lblConfirmPassword);
            pnlRegister.Controls.Add(txtPassword);
            pnlRegister.Controls.Add(lblPassword);
            pnlRegister.Controls.Add(txtEmail);
            pnlRegister.Controls.Add(lblEmail);
            pnlRegister.Controls.Add(txtUsername);
            pnlRegister.Controls.Add(lblUsername);
            pnlRegister.Controls.Add(lblTitle);
            pnlRegister.Location = new Point(156, 48);
            pnlRegister.BackColor = Color.FromArgb(140, 205, 205);
            pnlRegister.Name = "pnlRegister";
            pnlRegister.Size = new Size(648, 504);
            pnlRegister.TabIndex = 0;

            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Arial", 19F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(648, 40);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Registration";

            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblUsername.Location = new Point(42, 91);
            lblUsername.Name = "lblUsername";
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";

            txtUsername.BackColor = Color.FromArgb(238, 244, 240);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Arial", 19F);
            txtUsername.Location = new Point(42, 120);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(564, 40);
            txtUsername.TabIndex = 2;

            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblEmail.Location = new Point(42, 181);
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 3;
            lblEmail.Text = "E-Mail";

            txtEmail.BackColor = Color.FromArgb(238, 244, 240);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Arial", 19F);
            txtEmail.Location = new Point(42, 210);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(564, 40);
            txtEmail.TabIndex = 4;

            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblPassword.Location = new Point(42, 271);
            lblPassword.Name = "lblPassword";
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";

            txtPassword.BackColor = Color.FromArgb(238, 244, 240);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Arial", 19F);
            txtPassword.Location = new Point(42, 300);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(564, 40);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;

            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(42, 361);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.TabIndex = 7;
            lblConfirmPassword.Text = "Confirm Password";

            txtConfirmPassword.BackColor = Color.FromArgb(238, 244, 240);
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Arial", 19F);
            txtConfirmPassword.Location = new Point(42, 390);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(564, 40);
            txtConfirmPassword.TabIndex = 8;
            txtConfirmPassword.UseSystemPasswordChar = true;

            btnSignUp.BackColor = Color.FromArgb(150, 226, 236);
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnSignUp.ForeColor = Color.FromArgb(10, 30, 60);
            btnSignUp.Location = new Point(252, 450);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(144, 43);
            btnSignUp.TabIndex = 9;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            ClientSize = new Size(960, 600);
            Controls.Add(pnlRegister);
            Font = new Font("Arial", 12F);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            pnlRegister.ResumeLayout(false);
            pnlRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRegister;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnSignUp;
    }
}
namespace ScholarshipApp
{
    partial class LandingForm
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
            pnlLeft = new Panel();
            picLogo = new PictureBox();
            lblTitle = new Label();
            btnRegister = new Button();
            btnLogin = new Button();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();

            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.BackColor = Color.FromArgb(140, 205, 205);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(348, 576);
            pnlLeft.TabIndex = 0;

            picLogo.BackColor = Color.White;
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(66, 66);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(210, 210);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;

            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Arial", 20.5F, FontStyle.Bold | FontStyle.Italic);
            lblTitle.Location = new Point(372, 84);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(564, 84);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Scholarship Application Management System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            btnRegister.BackColor = Color.FromArgb(150, 226, 236);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnRegister.ForeColor = Color.FromArgb(10, 30, 60);
            btnRegister.Location = new Point(432, 444);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(144, 46);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;

            btnLogin.BackColor = Color.FromArgb(150, 226, 236);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.FromArgb(10, 30, 60);
            btnLogin.Location = new Point(720, 444);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(144, 46);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            ClientSize = new Size(960, 576);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(lblTitle);
            Controls.Add(pnlLeft);
            Font = new Font("Arial", 12F);
            Name = "LandingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Scholarship Application Management System";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private PictureBox picLogo;
        private Label lblTitle;
        private Button btnRegister;
        private Button btnLogin;
    }
}
namespace scholarship
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.TabPage tabStudent;

        private System.Windows.Forms.Label lblAdminUsername;
        private System.Windows.Forms.TextBox txtAdminUsername;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.CheckBox chkAdminShow;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.Label lblAdminError;

        private System.Windows.Forms.Label lblStudentNo;
        private System.Windows.Forms.TextBox txtStudentNo;
        private System.Windows.Forms.Label lblStudentPassword;
        private System.Windows.Forms.TextBox txtStudentPassword;
        private System.Windows.Forms.CheckBox chkStudentShow;
        private System.Windows.Forms.Button btnStudentLogin;
        private System.Windows.Forms.Label lblStudentError;
        private System.Windows.Forms.LinkLabel lnkRegister;

        private System.Windows.Forms.LinkLabel lnkBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components         = new System.ComponentModel.Container();
            this.headerPanel        = new System.Windows.Forms.Panel();
            this.lblTitle           = new System.Windows.Forms.Label();
            this.lblSubtitle        = new System.Windows.Forms.Label();
            this.tabControl         = new System.Windows.Forms.TabControl();
            this.tabAdmin           = new System.Windows.Forms.TabPage();
            this.tabStudent         = new System.Windows.Forms.TabPage();
            this.lblAdminUsername   = new System.Windows.Forms.Label();
            this.txtAdminUsername   = new System.Windows.Forms.TextBox();
            this.lblAdminPassword   = new System.Windows.Forms.Label();
            this.txtAdminPassword   = new System.Windows.Forms.TextBox();
            this.chkAdminShow       = new System.Windows.Forms.CheckBox();
            this.btnAdminLogin      = new System.Windows.Forms.Button();
            this.lblAdminError      = new System.Windows.Forms.Label();
            this.lblStudentNo       = new System.Windows.Forms.Label();
            this.txtStudentNo       = new System.Windows.Forms.TextBox();
            this.lblStudentPassword = new System.Windows.Forms.Label();
            this.txtStudentPassword = new System.Windows.Forms.TextBox();
            this.chkStudentShow     = new System.Windows.Forms.CheckBox();
            this.btnStudentLogin    = new System.Windows.Forms.Button();
            this.lblStudentError    = new System.Windows.Forms.Label();
            this.lnkRegister        = new System.Windows.Forms.LinkLabel();
            this.lnkBack            = new System.Windows.Forms.LinkLabel();

            // ---------- Header ----------
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.headerPanel.Dock      = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height    = 90;
            this.headerPanel.Name      = "headerPanel";
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);

            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(25, 18);
            this.lblTitle.Text      = "Sign in";

            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitle.Location  = new System.Drawing.Point(27, 55);
            this.lblSubtitle.Text      = "Scholarship Management System";

            // ---------- TabControl ----------
            this.tabControl.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl.Location = new System.Drawing.Point(20, 105);
            this.tabControl.Size     = new System.Drawing.Size(420, 300);
            this.tabControl.Name     = "tabControl";
            this.tabControl.Controls.Add(this.tabAdmin);
            this.tabControl.Controls.Add(this.tabStudent);

            // ---------- Admin tab ----------
            this.tabAdmin.BackColor = System.Drawing.Color.White;
            this.tabAdmin.Padding   = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Text      = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            this.tabAdmin.Controls.Add(this.lblAdminUsername);
            this.tabAdmin.Controls.Add(this.txtAdminUsername);
            this.tabAdmin.Controls.Add(this.lblAdminPassword);
            this.tabAdmin.Controls.Add(this.txtAdminPassword);
            this.tabAdmin.Controls.Add(this.chkAdminShow);
            this.tabAdmin.Controls.Add(this.btnAdminLogin);
            this.tabAdmin.Controls.Add(this.lblAdminError);

            this.lblAdminUsername.AutoSize = true;
            this.lblAdminUsername.Location = new System.Drawing.Point(25, 30);
            this.lblAdminUsername.Text     = "Username";

            this.txtAdminUsername.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdminUsername.Location = new System.Drawing.Point(25, 52);
            this.txtAdminUsername.Size     = new System.Drawing.Size(350, 28);

            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.Location = new System.Drawing.Point(25, 95);
            this.lblAdminPassword.Text     = "Password";

            this.txtAdminPassword.Font                   = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdminPassword.Location               = new System.Drawing.Point(25, 117);
            this.txtAdminPassword.Size                   = new System.Drawing.Size(350, 28);
            this.txtAdminPassword.UseSystemPasswordChar  = true;

            this.chkAdminShow.AutoSize = true;
            this.chkAdminShow.Location = new System.Drawing.Point(25, 155);
            this.chkAdminShow.Text     = "Show password";
            this.chkAdminShow.CheckedChanged += new System.EventHandler(this.chkAdminShow_CheckedChanged);

            this.btnAdminLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnAdminLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminLogin.ForeColor = System.Drawing.Color.White;
            this.btnAdminLogin.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAdminLogin.Location  = new System.Drawing.Point(25, 190);
            this.btnAdminLogin.Size      = new System.Drawing.Size(350, 40);
            this.btnAdminLogin.Text      = "Login as Admin";
            this.btnAdminLogin.UseVisualStyleBackColor = false;
            this.btnAdminLogin.FlatAppearance.BorderSize = 0;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);

            this.lblAdminError.AutoSize  = true;
            this.lblAdminError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdminError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAdminError.Location  = new System.Drawing.Point(25, 240);
            this.lblAdminError.Visible   = false;

            // ---------- Student tab ----------
            this.tabStudent.BackColor = System.Drawing.Color.White;
            this.tabStudent.Padding   = new System.Windows.Forms.Padding(3);
            this.tabStudent.Text      = "Student";
            this.tabStudent.UseVisualStyleBackColor = true;
            this.tabStudent.Controls.Add(this.lblStudentNo);
            this.tabStudent.Controls.Add(this.txtStudentNo);
            this.tabStudent.Controls.Add(this.lblStudentPassword);
            this.tabStudent.Controls.Add(this.txtStudentPassword);
            this.tabStudent.Controls.Add(this.chkStudentShow);
            this.tabStudent.Controls.Add(this.btnStudentLogin);
            this.tabStudent.Controls.Add(this.lblStudentError);
            this.tabStudent.Controls.Add(this.lnkRegister);

            this.lblStudentNo.AutoSize = true;
            this.lblStudentNo.Location = new System.Drawing.Point(25, 30);
            this.lblStudentNo.Text     = "Student No.";

            this.txtStudentNo.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStudentNo.Location = new System.Drawing.Point(25, 52);
            this.txtStudentNo.Size     = new System.Drawing.Size(350, 28);

            this.lblStudentPassword.AutoSize = true;
            this.lblStudentPassword.Location = new System.Drawing.Point(25, 95);
            this.lblStudentPassword.Text     = "Password";

            this.txtStudentPassword.Font                  = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStudentPassword.Location              = new System.Drawing.Point(25, 117);
            this.txtStudentPassword.Size                  = new System.Drawing.Size(350, 28);
            this.txtStudentPassword.UseSystemPasswordChar = true;

            this.chkStudentShow.AutoSize = true;
            this.chkStudentShow.Location = new System.Drawing.Point(25, 155);
            this.chkStudentShow.Text     = "Show password";
            this.chkStudentShow.CheckedChanged += new System.EventHandler(this.chkStudentShow_CheckedChanged);

            this.btnStudentLogin.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnStudentLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentLogin.ForeColor = System.Drawing.Color.White;
            this.btnStudentLogin.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnStudentLogin.Location  = new System.Drawing.Point(25, 190);
            this.btnStudentLogin.Size      = new System.Drawing.Size(350, 40);
            this.btnStudentLogin.Text      = "Login as Student";
            this.btnStudentLogin.UseVisualStyleBackColor = false;
            this.btnStudentLogin.FlatAppearance.BorderSize = 0;
            this.btnStudentLogin.Click += new System.EventHandler(this.btnStudentLogin_Click);

            this.lblStudentError.AutoSize  = true;
            this.lblStudentError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudentError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStudentError.Location  = new System.Drawing.Point(25, 240);
            this.lblStudentError.Visible   = false;

            this.lnkRegister.AutoSize = true;
            this.lnkRegister.Location = new System.Drawing.Point(25, 265);
            this.lnkRegister.Text     = "No account? Register here";
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);

            // ---------- Footer ----------
            this.lnkBack.AutoSize = true;
            this.lnkBack.Location = new System.Drawing.Point(20, 420);
            this.lnkBack.Text     = "← Back to home";
            this.lnkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBack_LinkClicked);

            // ---------- Form ----------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize          = new System.Drawing.Size(460, 460);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "LoginForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Login — Scholarship Management";
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lnkBack);
        }
    }
}
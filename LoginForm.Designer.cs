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

		// ---- Admin tab ----
		private System.Windows.Forms.Label lblAdminTitle;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.TextBox txtUsernameOrEmail;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnBack;

		// ---- Student tab ----
		private System.Windows.Forms.Label lblStudentTitle;
		private System.Windows.Forms.Label lblStudentId;
		private System.Windows.Forms.TextBox txtStudentId;
		private System.Windows.Forms.Label lblStudentPassword;
		private System.Windows.Forms.TextBox txtStudentPassword;
		private System.Windows.Forms.Button btnStudentLogin;
		private System.Windows.Forms.LinkLabel lnkRegister;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblSubtitle = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabAdmin = new System.Windows.Forms.TabPage();
			this.tabStudent = new System.Windows.Forms.TabPage();

			// Admin
			this.lblAdminTitle = new System.Windows.Forms.Label();
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtUsernameOrEmail = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();

			// Student
			this.lblStudentTitle = new System.Windows.Forms.Label();
			this.lblStudentId = new System.Windows.Forms.Label();
			this.txtStudentId = new System.Windows.Forms.TextBox();
			this.lblStudentPassword = new System.Windows.Forms.Label();
			this.txtStudentPassword = new System.Windows.Forms.TextBox();
			this.btnStudentLogin = new System.Windows.Forms.Button();
			this.lnkRegister = new System.Windows.Forms.LinkLabel();

			// ---------- Header ----------
			this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Height = 90;
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Controls.Add(this.lblTitle);
			this.headerPanel.Controls.Add(this.lblSubtitle);

			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(25, 18);
			this.lblTitle.Text = "Sign in";

			this.lblSubtitle.AutoSize = true;
			this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblSubtitle.Location = new System.Drawing.Point(27, 55);
			this.lblSubtitle.Text = "Scholarship Management System";

			// ---------- TabControl ----------
			this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			this.tabControl.Location = new System.Drawing.Point(20, 105);
			this.tabControl.Size = new System.Drawing.Size(420, 320);
			this.tabControl.Name = "tabControl";
			this.tabControl.Controls.Add(this.tabAdmin);
			this.tabControl.Controls.Add(this.tabStudent);

			// ---------- Admin tab ----------
			this.tabAdmin.BackColor = System.Drawing.Color.White;
			this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
			this.tabAdmin.Text = "Admin";
			this.tabAdmin.UseVisualStyleBackColor = true;
			this.tabAdmin.Controls.Add(this.lblAdminTitle);
			this.tabAdmin.Controls.Add(this.lblUsername);
			this.tabAdmin.Controls.Add(this.txtUsernameOrEmail);
			this.tabAdmin.Controls.Add(this.lblPassword);
			this.tabAdmin.Controls.Add(this.txtPassword);
			this.tabAdmin.Controls.Add(this.btnLogin);
			this.tabAdmin.Controls.Add(this.btnBack);

			this.lblAdminTitle.AutoSize = true;
			this.lblAdminTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
			this.lblAdminTitle.Location = new System.Drawing.Point(25, 15);
			this.lblAdminTitle.Text = "Admin Login";

			this.lblUsername.AutoSize = true;
			this.lblUsername.Location = new System.Drawing.Point(25, 55);
			this.lblUsername.Text = "Username or Email";

			this.txtUsernameOrEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtUsernameOrEmail.Location = new System.Drawing.Point(25, 78);
			this.txtUsernameOrEmail.Size = new System.Drawing.Size(350, 28);
			this.txtUsernameOrEmail.Name = "txtUsernameOrEmail";

			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(25, 120);
			this.lblPassword.Text = "Password";

			this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtPassword.Location = new System.Drawing.Point(25, 143);
			this.txtPassword.Size = new System.Drawing.Size(350, 28);
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtPassword.Name = "txtPassword";

			this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
			this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLogin.ForeColor = System.Drawing.Color.White;
			this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
			this.btnLogin.Location = new System.Drawing.Point(25, 190);
			this.btnLogin.Size = new System.Drawing.Size(165, 40);
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.FlatAppearance.BorderSize = 0;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBack.Location = new System.Drawing.Point(210, 190);
			this.btnBack.Size = new System.Drawing.Size(165, 40);
			this.btnBack.Text = "Back";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

			// ---------- Student tab ----------
			this.tabStudent.BackColor = System.Drawing.Color.White;
			this.tabStudent.Padding = new System.Windows.Forms.Padding(3);
			this.tabStudent.Text = "Student";
			this.tabStudent.UseVisualStyleBackColor = true;
			this.tabStudent.Controls.Add(this.lblStudentTitle);
			this.tabStudent.Controls.Add(this.lblStudentId);
			this.tabStudent.Controls.Add(this.txtStudentId);
			this.tabStudent.Controls.Add(this.lblStudentPassword);
			this.tabStudent.Controls.Add(this.txtStudentPassword);
			this.tabStudent.Controls.Add(this.btnStudentLogin);
			this.tabStudent.Controls.Add(this.lnkRegister);

			this.lblStudentTitle.AutoSize = true;
			this.lblStudentTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
			this.lblStudentTitle.Location = new System.Drawing.Point(25, 15);
			this.lblStudentTitle.Text = "Student Login";

			this.lblStudentId.AutoSize = true;
			this.lblStudentId.Location = new System.Drawing.Point(25, 55);
			this.lblStudentId.Text = "Student ID or Email";

			this.txtStudentId.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtStudentId.Location = new System.Drawing.Point(25, 78);
			this.txtStudentId.Size = new System.Drawing.Size(350, 28);
			this.txtStudentId.Name = "txtStudentId";

			this.lblStudentPassword.AutoSize = true;
			this.lblStudentPassword.Location = new System.Drawing.Point(25, 120);
			this.lblStudentPassword.Text = "Password";

			this.txtStudentPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtStudentPassword.Location = new System.Drawing.Point(25, 143);
			this.txtStudentPassword.Size = new System.Drawing.Size(350, 28);
			this.txtStudentPassword.UseSystemPasswordChar = true;
			this.txtStudentPassword.Name = "txtStudentPassword";

			this.btnStudentLogin.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
			this.btnStudentLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStudentLogin.ForeColor = System.Drawing.Color.White;
			this.btnStudentLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
			this.btnStudentLogin.Location = new System.Drawing.Point(25, 190);
			this.btnStudentLogin.Size = new System.Drawing.Size(350, 40);
			this.btnStudentLogin.Text = "Login as Student";
			this.btnStudentLogin.UseVisualStyleBackColor = false;
			this.btnStudentLogin.FlatAppearance.BorderSize = 0;
			this.btnStudentLogin.Click += new System.EventHandler(this.btnStudentLogin_Click);

			this.lnkRegister.AutoSize = true;
			this.lnkRegister.Location = new System.Drawing.Point(25, 245);
			this.lnkRegister.Text = "Don't have an account? Register";
			this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);

			// Form
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
			this.ClientSize = new System.Drawing.Size(460, 470);
			this.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login — Scholarship Management";
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.tabControl);
		}
	}
}
namespace ScholarshipApp
{
    partial class StudentProfilePage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChangePassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();

            int y = 60, lx = 20, ix = 160, w = 440, gap = 40;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "My Profile";

            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(lx, y + 4);
            this.lblName.Text = "Full Name";
            this.txtName.Location = new System.Drawing.Point(ix, y);
            this.txtName.Size = new System.Drawing.Size(w, 28);
            y += gap;

            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(lx, y + 4);
            this.lblEmail.Text = "Email";
            this.txtEmail.Location = new System.Drawing.Point(ix, y);
            this.txtEmail.Size = new System.Drawing.Size(w, 28);
            y += gap;

            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(lx, y + 4);
            this.lblCourse.Text = "Course";
            this.txtCourse.Location = new System.Drawing.Point(ix, y);
            this.txtCourse.Size = new System.Drawing.Size(w, 28);
            y += gap;

            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(lx, y + 4);
            this.lblYear.Text = "Year Level";
            this.txtYear.Location = new System.Drawing.Point(ix, y);
            this.txtYear.Size = new System.Drawing.Size(w, 28);
            y += gap;

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, y + 20);
            this.btnSave.Size = new System.Drawing.Size(140, 34);
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Location = new System.Drawing.Point(170, y + 20);
            this.btnChangePassword.Size = new System.Drawing.Size(160, 34);
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, y + 80);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "StudentProfilePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Profile";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName); this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail); this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblCourse); this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.lblYear); this.Controls.Add(this.txtYear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChangePassword);
        }
    }
}
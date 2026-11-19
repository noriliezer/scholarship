namespace ScholarshipApp
{
    partial class ChangePasswordDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOld;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblOld = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            int y = 20;
            this.lblOld.AutoSize = true; this.lblOld.Location = new System.Drawing.Point(20, y); this.lblOld.Text = "Current password";
            y += 22;
            this.txtOld.Location = new System.Drawing.Point(20, y); this.txtOld.Size = new System.Drawing.Size(340, 28); this.txtOld.UseSystemPasswordChar = true;
            y += 36;

            this.lblNew.AutoSize = true; this.lblNew.Location = new System.Drawing.Point(20, y); this.lblNew.Text = "New password";
            y += 22;
            this.txtNew.Location = new System.Drawing.Point(20, y); this.txtNew.Size = new System.Drawing.Size(340, 28); this.txtNew.UseSystemPasswordChar = true;
            y += 36;

            this.lblConfirm.AutoSize = true; this.lblConfirm.Location = new System.Drawing.Point(20, y); this.lblConfirm.Text = "Confirm new password";
            y += 22;
            this.txtConfirm.Location = new System.Drawing.Point(20, y); this.txtConfirm.Size = new System.Drawing.Size(340, 28); this.txtConfirm.UseSystemPasswordChar = true;
            y += 36;

            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(20, y + 10);
            this.btnUpdate.Size = new System.Drawing.Size(140, 34);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(170, y + 10);
            this.btnCancel.Size = new System.Drawing.Size(120, 34);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AcceptButton = this.btnUpdate;
            this.CancelButton = this.btnCancel;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, y + 70);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.Controls.Add(this.lblOld); this.Controls.Add(this.txtOld);
            this.Controls.Add(this.lblNew); this.Controls.Add(this.txtNew);
            this.Controls.Add(this.lblConfirm); this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.btnUpdate); this.Controls.Add(this.btnCancel);
        }
    }
}
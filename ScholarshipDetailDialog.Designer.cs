namespace scholarship
{
    partial class ScholarshipDetailDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMeta = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblName.Location = new System.Drawing.Point(20, 18);
            this.lblName.Size = new System.Drawing.Size(510, 60);

            this.lblMeta.AutoSize = true;
            this.lblMeta.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMeta.Location = new System.Drawing.Point(20, 85);

            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(20, 120);
            this.txtDescription.Multiline = true;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(510, 240);

            this.btnApply.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(20, 380);
            this.btnApply.Size = new System.Drawing.Size(140, 34);
            this.btnApply.Text = "Apply now";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(170, 380);
            this.btnClose.Size = new System.Drawing.Size(140, 34);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 520);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "ScholarshipDetailDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scholarship";
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblMeta);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnClose);
        }
    }
}
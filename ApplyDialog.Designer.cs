namespace scholarship
{
    partial class ApplyDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblEssayPrompt;
        private System.Windows.Forms.TextBox txtEssay;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblEssayPrompt = new System.Windows.Forms.Label();
            this.txtEssay = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblHeader.Location = new System.Drawing.Point(20, 20);

            this.lblEssayPrompt.AutoSize = true;
            this.lblEssayPrompt.Location = new System.Drawing.Point(20, 60);
            this.lblEssayPrompt.Text = "Essay / Motivation (required):";

            this.txtEssay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEssay.Location = new System.Drawing.Point(20, 85);
            this.txtEssay.Multiline = true;
            this.txtEssay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEssay.Size = new System.Drawing.Size(500, 320);

            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(20, 425);
            this.btnSubmit.Size = new System.Drawing.Size(150, 34);
            this.btnSubmit.Text = "Submit Application";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(180, 425);
            this.btnCancel.Size = new System.Drawing.Size(120, 34);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 520);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "ApplyDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply";
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblEssayPrompt);
            this.Controls.Add(this.txtEssay);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
        }
    }
}
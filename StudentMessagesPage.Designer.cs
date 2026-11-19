namespace scholarship
{
    partial class StudentMessagesPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMarkAll;
        private System.Windows.Forms.ListBox lstMessages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMarkAll = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListBox();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Text = "Messages / Notifications";

            this.btnMarkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAll.Location = new System.Drawing.Point(600, 20);
            this.btnMarkAll.Size = new System.Drawing.Size(140, 34);
            this.btnMarkAll.Text = "Mark all read";
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);

            this.lstMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMessages.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstMessages.Location = new System.Drawing.Point(20, 70);
            this.lstMessages.Size = new System.Drawing.Size(740, 440);
            this.lstMessages.DoubleClick += new System.EventHandler(this.lstMessages_DoubleClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "StudentMessagesPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Messages";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnMarkAll);
            this.Controls.Add(this.lstMessages);
        }
    }
}
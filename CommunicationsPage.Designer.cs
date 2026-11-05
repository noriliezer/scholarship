using System.Xml.Linq;

namespace ScholarshipApp
{
    partial class CommunicationsPage
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblRecipients = new Label();
            cmbRecipients = new ComboBox();
            lblSubject = new Label();
            txtSubject = new TextBox();
            lblMessage = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();

            pnlHeader.BackColor = Color.FromArgb(100, 190, 180);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(696, 50);
            pnlHeader.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(236, 240, 232);
            lblTitle.Font = new Font("Arial", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "COMMUNICATIONS";

            lblRecipients.AutoSize = true;
            lblRecipients.BackColor = Color.Transparent;
            lblRecipients.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblRecipients.Location = new Point(12, 68);
            lblRecipients.Name = "lblRecipients";
            lblRecipients.TabIndex = 1;
            lblRecipients.Text = "Recipients";

            cmbRecipients.BackColor = Color.FromArgb(238, 244, 240);
            cmbRecipients.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRecipients.Font = new Font("Arial", 14F);
            cmbRecipients.FormattingEnabled = true;
            cmbRecipients.Location = new Point(12, 102);
            cmbRecipients.Name = "cmbRecipients";
            cmbRecipients.Size = new Size(672, 36);
            cmbRecipients.TabIndex = 2;

            lblSubject.AutoSize = true;
            lblSubject.BackColor = Color.Transparent;
            lblSubject.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblSubject.Location = new Point(12, 152);
            lblSubject.Name = "lblSubject";
            lblSubject.TabIndex = 3;
            lblSubject.Text = "Subject";

            txtSubject.BackColor = Color.FromArgb(238, 244, 240);
            txtSubject.BorderStyle = BorderStyle.FixedSingle;
            txtSubject.Font = new Font("Arial", 14F);
            txtSubject.Location = new Point(12, 186);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(672, 30);
            txtSubject.TabIndex = 4;

            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            lblMessage.Location = new Point(12, 236);
            lblMessage.Name = "lblMessage";
            lblMessage.TabIndex = 5;
            lblMessage.Text = "Message";

            txtMessage.BackColor = Color.FromArgb(238, 244, 240);
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Font = new Font("Arial", 14F);
            txtMessage.Location = new Point(12, 270);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(672, 230);
            txtMessage.TabIndex = 6;

            btnSend.BackColor = Color.FromArgb(150, 226, 236);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 110);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Arial", 14.5F, FontStyle.Bold);
            btnSend.ForeColor = Color.FromArgb(10, 30, 60);
            btnSend.Location = new Point(532, 516);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(152, 42);
            btnSend.TabIndex = 7;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(lblMessage);
            Controls.Add(txtSubject);
            Controls.Add(lblSubject);
            Controls.Add(cmbRecipients);
            Controls.Add(lblRecipients);
            Controls.Add(pnlHeader);
            Font = new Font("Arial", 12F);
            Name = "CommunicationsPage";
            Size = new Size(696, 582);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblRecipients;
        private ComboBox cmbRecipients;
        private Label lblSubject;
        private TextBox txtSubject;
        private Label lblMessage;
        private TextBox txtMessage;
        private Button btnSend;
    }
}
namespace ScholarshipApp
{
    partial class SupportForm
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
            pnlTop = new Panel();
            pnlSupport = new Panel();
            lblSupportTitle = new Label();
            lblSocials = new Label();
            lblCampus = new Label();
            lineSupport = new Panel();
            pnlContact = new Panel();
            lblContactTitle = new Label();
            lblEmail1 = new Label();
            lblEmail2 = new Label();
            lblEmail3 = new Label();
            lineContact = new Panel();
            pnlSupport.SuspendLayout();
            pnlContact.SuspendLayout();
            SuspendLayout();

            pnlTop.Location = new Point(0, 0);
            pnlTop.BackColor = Color.FromArgb(140, 205, 205);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1080, 384);
            pnlTop.TabIndex = 0;

            pnlSupport.BackColor = Color.FromArgb(232, 232, 220);
            pnlSupport.Controls.Add(lineSupport);
            pnlSupport.Controls.Add(lblCampus);
            pnlSupport.Controls.Add(lblSocials);
            pnlSupport.Controls.Add(lblSupportTitle);
            pnlSupport.Location = new Point(48, 216);
            pnlSupport.Name = "pnlSupport";
            pnlSupport.Size = new Size(480, 360);
            pnlSupport.TabIndex = 1;

            lblSupportTitle.BackColor = Color.Transparent;
            lblSupportTitle.Font = new Font("Papyrus", 41F);
            lblSupportTitle.Location = new Point(0, 24);
            lblSupportTitle.Name = "lblSupportTitle";
            lblSupportTitle.Size = new Size(480, 84);
            lblSupportTitle.TabIndex = 0;
            lblSupportTitle.Text = "Support";
            lblSupportTitle.TextAlign = ContentAlignment.MiddleCenter;

            lblSocials.AutoSize = true;
            lblSocials.BackColor = Color.Transparent;
            lblSocials.Font = new Font("Papyrus", 13F);
            lblSocials.Location = new Point(180, 156);
            lblSocials.Name = "lblSocials";
            lblSocials.TabIndex = 1;
            lblSocials.Text = "on any socials";

            lblCampus.AutoSize = true;
            lblCampus.BackColor = Color.Transparent;
            lblCampus.Font = new Font("Papyrus", 14.5F);
            lblCampus.Location = new Point(14, 192);
            lblCampus.Name = "lblCampus";
            lblCampus.TabIndex = 2;
            lblCampus.Text = "Bulacan Polytechnic College - Main Campus";

            lineSupport.BackColor = Color.Gray;
            lineSupport.Location = new Point(18, 342);
            lineSupport.Name = "lineSupport";
            lineSupport.Size = new Size(444, 1);
            lineSupport.TabIndex = 3;

            pnlContact.BackColor = Color.FromArgb(232, 232, 220);
            pnlContact.Controls.Add(lineContact);
            pnlContact.Controls.Add(lblEmail3);
            pnlContact.Controls.Add(lblEmail2);
            pnlContact.Controls.Add(lblEmail1);
            pnlContact.Controls.Add(lblContactTitle);
            pnlContact.Location = new Point(564, 218);
            pnlContact.Name = "pnlContact";
            pnlContact.Size = new Size(468, 358);
            pnlContact.TabIndex = 2;

            lblContactTitle.BackColor = Color.Transparent;
            lblContactTitle.Font = new Font("Papyrus", 41F);
            lblContactTitle.Location = new Point(0, 24);
            lblContactTitle.Name = "lblContactTitle";
            lblContactTitle.Size = new Size(468, 84);
            lblContactTitle.TabIndex = 0;
            lblContactTitle.Text = "Contact Us";
            lblContactTitle.TextAlign = ContentAlignment.MiddleCenter;

            lblEmail1.AutoSize = true;
            lblEmail1.BackColor = Color.Transparent;
            lblEmail1.Font = new Font("Papyrus", 15.5F);
            lblEmail1.Location = new Point(24, 156);
            lblEmail1.Name = "lblEmail1";
            lblEmail1.TabIndex = 1;
            lblEmail1.Text = "enertulagannohelp@gmail.com";

            lblEmail2.AutoSize = true;
            lblEmail2.BackColor = Color.Transparent;
            lblEmail2.Font = new Font("Papyrus", 15.5F);
            lblEmail2.Location = new Point(24, 216);
            lblEmail2.Name = "lblEmail2";
            lblEmail2.TabIndex = 2;
            lblEmail2.Text = "estesnoheal@gmail.com";

            lblEmail3.AutoSize = true;
            lblEmail3.BackColor = Color.Transparent;
            lblEmail3.Font = new Font("Papyrus", 15.5F);
            lblEmail3.Location = new Point(24, 276);
            lblEmail3.Name = "lblEmail3";
            lblEmail3.TabIndex = 3;
            lblEmail3.Text = "bpc@gmail.com";

            lineContact.BackColor = Color.Gray;
            lineContact.Location = new Point(0, 342);
            lineContact.Name = "lineContact";
            lineContact.Size = new Size(468, 1);
            lineContact.TabIndex = 4;

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            ClientSize = new Size(1080, 624);
            Controls.Add(pnlContact);
            Controls.Add(pnlSupport);
            Controls.Add(pnlTop);
            Font = new Font("Arial", 12F);
            Name = "SupportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Support";
            pnlSupport.ResumeLayout(false);
            pnlSupport.PerformLayout();
            pnlContact.ResumeLayout(false);
            pnlContact.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlSupport;
        private Label lblSupportTitle;
        private Label lblSocials;
        private Label lblCampus;
        private Panel lineSupport;
        private Panel pnlContact;
        private Label lblContactTitle;
        private Label lblEmail1;
        private Label lblEmail2;
        private Label lblEmail3;
        private Panel lineContact;
    }
}
namespace ScholarshipApp
{
    partial class ScholarshipsPage
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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvScholarships = new DataGridView();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScholarships).BeginInit();
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
            lblTitle.Text = "SCHOLARSHIPS";

            btnAdd.BackColor = Color.FromArgb(226, 230, 226);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderColor = Color.Gray;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnAdd.Location = new Point(12, 68);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 36);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;

            btnEdit.BackColor = Color.FromArgb(226, 230, 226);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderColor = Color.Gray;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnEdit.Location = new Point(144, 68);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 36);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;

            btnDelete.BackColor = Color.FromArgb(226, 230, 226);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderColor = Color.Gray;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnDelete.Location = new Point(276, 68);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;

            dgvScholarships.AllowUserToAddRows = false;
            dgvScholarships.AllowUserToDeleteRows = false;
            dgvScholarships.BackgroundColor = Color.FromArgb(212, 212, 205);
            dgvScholarships.BorderStyle = BorderStyle.FixedSingle;
            dgvScholarships.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvScholarships.ColumnHeadersHeight = 34;
            dgvScholarships.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvScholarships.DefaultCellStyle = cellStyle;
            dgvScholarships.EnableHeadersVisualStyles = false;
            dgvScholarships.Location = new Point(12, 118);
            dgvScholarships.MultiSelect = false;
            dgvScholarships.Name = "dgvScholarships";
            dgvScholarships.ReadOnly = true;
            dgvScholarships.RowHeadersVisible = false;
            dgvScholarships.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScholarships.Size = new Size(672, 452);
            dgvScholarships.TabIndex = 4;

            headerStyle.BackColor = Color.FromArgb(236, 240, 232);
            headerStyle.Font = new Font("Arial", 12F);
            headerStyle.ForeColor = Color.Black;
            cellStyle.BackColor = Color.FromArgb(236, 240, 232);

            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(228, 226, 204);
            Controls.Add(dgvScholarships);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(pnlHeader);
            Font = new Font("Arial", 12F);
            Name = "ScholarshipsPage";
            Size = new Size(696, 582);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScholarships).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvScholarships;
    }
}
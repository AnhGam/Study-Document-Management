namespace study_document_manager
{
    partial class FileIntegrityCheckForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.dgvMissingFiles = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuongDan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kiểm tra file bị thiếu";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(20, 50);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(660, 23);
            this.progressBar.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(20, 80);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(200, 15);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "Nhấn \"Quét\" để bắt đầu kiểm tra...";
            // 
            // dgvMissingFiles
            // 
            this.dgvMissingFiles.AllowUserToAddRows = false;
            this.dgvMissingFiles.AllowUserToDeleteRows = false;
            this.dgvMissingFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMissingFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMissingFiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvMissingFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMissingFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMissingFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTen,
            this.colDuongDan,
            this.colAction});
            this.dgvMissingFiles.Location = new System.Drawing.Point(20, 105);
            this.dgvMissingFiles.MultiSelect = false;
            this.dgvMissingFiles.Name = "dgvMissingFiles";
            this.dgvMissingFiles.ReadOnly = true;
            this.dgvMissingFiles.RowHeadersWidth = 25;
            this.dgvMissingFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMissingFiles.Size = new System.Drawing.Size(660, 300);
            this.dgvMissingFiles.TabIndex = 3;
            this.dgvMissingFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMissingFiles_CellClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            this.colId.FillWeight = 10;
            // 
            // colTen
            // 
            this.colTen.HeaderText = "Tên tài liệu";
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            this.colTen.FillWeight = 30;
            // 
            // colDuongDan
            // 
            this.colDuongDan.HeaderText = "Đường dẫn file";
            this.colDuongDan.Name = "colDuongDan";
            this.colDuongDan.ReadOnly = true;
            this.colDuongDan.FillWeight = 50;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "Hành động";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.Text = "Xử lý";
            this.colAction.UseColumnTextForButtonValue = true;
            this.colAction.FillWeight = 15;
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScan.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnScan.ForeColor = System.Drawing.Color.White;
            this.btnScan.Location = new System.Drawing.Point(20, 420);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(120, 35);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Quét";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDeleteAll.Enabled = false;
            this.btnDeleteAll.FlatAppearance.BorderSize = 0;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAll.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAll.Location = new System.Drawing.Point(150, 420);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(150, 35);
            this.btnDeleteAll.TabIndex = 5;
            this.btnDeleteAll.Text = "Xóa tất cả";
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(560, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(310, 430);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(0, 15);
            this.lblSummary.TabIndex = 7;
            // 
            // FileIntegrityCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(700, 470);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.dgvMissingFiles);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FileIntegrityCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kiểm tra file bị thiếu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.DataGridView dgvMissingFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuongDan;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSummary;
    }
}

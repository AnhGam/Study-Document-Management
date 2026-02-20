using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using study_document_manager.UI;
using study_document_manager.UI.Controls;

namespace study_document_manager.Documents
{
    public class BatchImportForm : Form
    {
        private DataGridView dgvFiles;
        private Button btnSelectFolder;
        private Button btnImport;
        private Button btnClose;
        private Button btnSelectAll;
        private Button btnDeselectAll;
        private ComboBox cboSubject;
        private Label lblFolder;
        private Label lblSubject;
        private Label lblStatus;
        private ProgressBar progressBar;
        private Panel pnlHeader;
        private Panel pnlActions;
        private CheckBox chkRecursive;

        private List<FileEntry> fileEntries = new List<FileEntry>();

        public BatchImportForm()
        {
            InitializeUI();
            ApplyTheme();
            LoadSubjects();
        }

        private void InitializeUI()
        {
            this.Text = "Import tài liệu từ thư mục";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Header Panel
            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 90, Padding = new Padding(16, 8, 16, 8) };

            var lblTitle = new Label
            {
                Text = "Import tài liệu từ thư mục",
                Font = new Font(AppTheme.FontFamily, 14f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 8)
            };

            btnSelectFolder = new Button
            {
                Text = "Chọn thư mục...",
                Size = new Size(140, 32),
                Location = new Point(16, 48)
            };
            btnSelectFolder.Click += BtnSelectFolder_Click;

            lblFolder = new Label
            {
                Text = "Chưa chọn thư mục",
                AutoSize = true,
                Location = new Point(165, 56),
                Font = new Font(AppTheme.FontFamily, 9f, FontStyle.Italic)
            };

            chkRecursive = new CheckBox
            {
                Text = "Bao gồm thư mục con",
                AutoSize = true,
                Location = new Point(600, 56),
                Checked = true
            };

            pnlHeader.Controls.AddRange(new Control[] { lblTitle, btnSelectFolder, lblFolder, chkRecursive });
            this.Controls.Add(pnlHeader);

            // DataGridView
            dgvFiles = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = true,
                ReadOnly = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                BorderStyle = BorderStyle.None
            };
            SetupColumns();
            this.Controls.Add(dgvFiles);

            // Actions Panel
            pnlActions = new Panel { Dock = DockStyle.Bottom, Height = 95, Padding = new Padding(12, 8, 12, 8) };

            // Row 1: Subject + select buttons
            lblSubject = new Label { Text = "Môn học chung:", AutoSize = true, Location = new Point(16, 10) };
            cboSubject = new ComboBox
            {
                Location = new Point(120, 7),
                Size = new Size(200, 28),
                DropDownStyle = ComboBoxStyle.DropDown
            };

            btnSelectAll = new Button { Text = "Chọn tất cả", Size = new Size(100, 30), Location = new Point(340, 6) };
            btnSelectAll.Click += (s, e) => ToggleAll(true);

            btnDeselectAll = new Button { Text = "Bỏ chọn", Size = new Size(90, 30), Location = new Point(448, 6) };
            btnDeselectAll.Click += (s, e) => ToggleAll(false);

            // Row 2: Progress + Import + Close
            progressBar = new ProgressBar { Location = new Point(16, 45), Size = new Size(450, 22), Visible = false };
            lblStatus = new Label { AutoSize = true, Location = new Point(16, 70), Font = new Font(AppTheme.FontFamily, 9f) };

            btnImport = new Button { Text = "Import", Size = new Size(120, 35), Location = new Point(650, 8) };
            btnImport.Click += BtnImport_Click;
            btnImport.Enabled = false;

            btnClose = new Button { Text = "Đóng", Size = new Size(90, 35), Location = new Point(778, 8) };
            btnClose.Click += (s, e) => this.Close();

            pnlActions.Controls.AddRange(new Control[]
            {
                lblSubject, cboSubject, btnSelectAll, btnDeselectAll,
                progressBar, lblStatus, btnImport, btnClose
            });
            this.Controls.Add(pnlActions);

            dgvFiles.BringToFront();
        }

        private void SetupColumns()
        {
            dgvFiles.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Selected",
                HeaderText = "",
                Width = 40
            });

            dgvFiles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FileName", HeaderText = "Tên file", Width = 280, ReadOnly = true
            });

            dgvFiles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FileType", HeaderText = "Loại", Width = 80, ReadOnly = true
            });

            dgvFiles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FileSize", HeaderText = "Kích thước", Width = 100, ReadOnly = true
            });

            dgvFiles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FilePath", HeaderText = "Đường dẫn", Width = 350, ReadOnly = true
            });
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.BackgroundMain;
            pnlHeader.BackColor = AppTheme.BackgroundCard;
            pnlActions.BackColor = AppTheme.BackgroundSoft;
            lblStatus.ForeColor = AppTheme.TextSecondary;

            AppTheme.ApplyButtonPrimary(btnSelectFolder);
            AppTheme.ApplyButtonSuccess(btnImport);
            AppTheme.ApplyButtonSecondary(btnSelectAll);
            AppTheme.ApplyButtonSecondary(btnDeselectAll);
            AppTheme.ApplyButtonDanger(btnClose);
            AppTheme.ApplyDataGridViewStyle(dgvFiles);

            // Fix: allow checkbox clicks after theme sets ReadOnly=true
            dgvFiles.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvFiles.Columns)
                col.ReadOnly = col.Name != "Selected";
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = DatabaseHelper.GetDistinctSubjects();
                cboSubject.Items.Clear();
                cboSubject.Items.Add("");
                foreach (DataRow row in subjects.Rows)
                {
                    cboSubject.Items.Add(row["mon_hoc"].ToString());
                }
            }
            catch { }
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục chứa tài liệu cần import";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ScanFolder(dialog.SelectedPath);
                }
            }
        }

        private void ScanFolder(string folderPath)
        {
            lblFolder.Text = folderPath;
            fileEntries.Clear();
            dgvFiles.Rows.Clear();

            var searchOption = chkRecursive.Checked
                ? SearchOption.AllDirectories
                : SearchOption.TopDirectoryOnly;

            try
            {
                var files = Directory.GetFiles(folderPath, "*.*", searchOption);

                foreach (var filePath in files)
                {
                    var info = new FileInfo(filePath);
                    var entry = new FileEntry
                    {
                        FileName = Path.GetFileNameWithoutExtension(filePath),
                        FileType = DetectFileType(info.Extension),
                        FileSize = info.Length,
                        FilePath = filePath,
                        Extension = info.Extension
                    };
                    fileEntries.Add(entry);

                    int rowIndex = dgvFiles.Rows.Add();
                    var row = dgvFiles.Rows[rowIndex];
                    row.Cells["Selected"].Value = true;
                    row.Cells["FileName"].Value = entry.FileName;
                    row.Cells["FileType"].Value = entry.FileType;
                    row.Cells["FileSize"].Value = FormatFileSize(entry.FileSize);
                    row.Cells["FilePath"].Value = entry.FilePath;
                }

                lblStatus.Text = $"Tìm thấy {fileEntries.Count} file";
                btnImport.Enabled = fileEntries.Count > 0;
            }
            catch (Exception ex)
            {
                ToastNotification.Error("Lỗi quét thư mục: " + ex.Message);
            }
        }

        private void ToggleAll(bool selected)
        {
            foreach (DataGridViewRow row in dgvFiles.Rows)
            {
                row.Cells["Selected"].Value = selected;
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            var selectedIndices = new List<int>();
            for (int i = 0; i < dgvFiles.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvFiles.Rows[i].Cells["Selected"].Value ?? false))
                    selectedIndices.Add(i);
            }

            if (selectedIndices.Count == 0)
            {
                ToastNotification.Warning("Vui lòng chọn ít nhất 1 file để import.");
                return;
            }

            string subject = cboSubject.Text?.Trim() ?? "";

            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = selectedIndices.Count;
            progressBar.Value = 0;

            btnImport.Enabled = false;
            btnSelectFolder.Enabled = false;

            int success = 0;
            int failed = 0;

            foreach (int idx in selectedIndices)
            {
                var entry = fileEntries[idx];
                try
                {
                    bool result = DatabaseHelper.InsertDocument(
                        entry.FileName,
                        string.IsNullOrEmpty(subject) ? "" : subject,
                        entry.FileType,
                        entry.FilePath,
                        "",
                        (double)entry.FileSize / (1024.0 * 1024.0),
                        "",
                        false,
                        "",
                        null
                    );

                    if (result) success++;
                    else failed++;
                }
                catch
                {
                    failed++;
                }

                progressBar.Value++;
                Application.DoEvents();
            }

            progressBar.Visible = false;
            btnImport.Enabled = true;
            btnSelectFolder.Enabled = true;

            lblStatus.Text = $"Hoàn tất: {success}/{selectedIndices.Count} file đã import";

            if (failed > 0)
                ToastNotification.Warning($"Import xong: {success} thành công, {failed} thất bại.");
            else
                ToastNotification.Success($"Đã import thành công {success} tài liệu!");
        }

        private static string DetectFileType(string extension)
        {
            switch (extension.ToLowerInvariant())
            {
                case ".pdf": return "PDF";
                case ".doc": case ".docx": return "Word";
                case ".xls": case ".xlsx": return "Excel";
                case ".ppt": case ".pptx": return "PowerPoint";
                case ".txt": return "Text";
                case ".jpg": case ".jpeg": case ".png": case ".gif": case ".bmp": return "Hình ảnh";
                case ".mp4": case ".avi": case ".mkv": case ".mov": return "Video";
                case ".mp3": case ".wav": case ".flac": return "Audio";
                case ".zip": case ".rar": case ".7z": return "Nén";
                case ".html": case ".htm": return "HTML";
                case ".cs": case ".java": case ".py": case ".js": case ".ts": return "Code";
                default: return extension.TrimStart('.').ToUpper();
            }
        }

        private static string FormatFileSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            return $"{bytes / (1024.0 * 1024.0):F1} MB";
        }

        private class FileEntry
        {
            public string FileName { get; set; }
            public string FileType { get; set; }
            public long FileSize { get; set; }
            public string FilePath { get; set; }
            public string Extension { get; set; }
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using study_document_manager.UI;

namespace study_document_manager.Documents
{
    public class RelatedDocumentsForm : Form
    {
        private int currentDocId;
        private string currentDocName;
        private DataGridView dgvRelated;
        private ComboBox cmbDocuments;
        private ComboBox cmbRelationType;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnClose;
        private Panel pnlHeader;
        private Panel pnlAddRelation;
        private Panel pnlActions;

        public RelatedDocumentsForm(int docId, string docName)
        {
            currentDocId = docId;
            currentDocName = docName;
            InitializeUI();
            ApplyTheme();
            LoadRelatedDocuments();
            LoadAllDocuments();
        }

        private void InitializeUI()
        {
            this.Text = "Tài liệu liên quan - " + currentDocName;
            this.Size = new Size(750, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Header
            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 45, Padding = new Padding(16, 8, 16, 8) };
            var lblTitle = new Label
            {
                Text = "Tài liệu liên quan với: " + currentDocName,
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 12)
            };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            // Add relation panel
            pnlAddRelation = new Panel { Dock = DockStyle.Top, Height = 50, Padding = new Padding(16, 8, 16, 8) };

            var lblDoc = new Label { Text = "Chọn tài liệu:", AutoSize = true, Location = new Point(16, 16), Font = new Font("Segoe UI", 9f) };
            cmbDocuments = new ComboBox
            {
                Location = new Point(120, 12),
                Size = new Size(280, 25),
                DropDownStyle = ComboBoxStyle.DropDown,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.ListItems
            };

            cmbRelationType = new ComboBox
            {
                Location = new Point(410, 12),
                Size = new Size(130, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRelationType.Items.AddRange(new object[] { "Liên quan", "Bài tập", "Bài giảng", "Tham khảo", "Phụ lục" });
            cmbRelationType.SelectedIndex = 0;

            btnAdd = new Button { Text = "Thêm", Size = new Size(80, 28), Location = new Point(550, 11) };
            btnAdd.Click += BtnAdd_Click;

            pnlAddRelation.Controls.AddRange(new Control[] { lblDoc, cmbDocuments, cmbRelationType, btnAdd });
            this.Controls.Add(pnlAddRelation);

            // DataGridView
            dgvRelated = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };

            dgvRelated.Columns.Add(new DataGridViewTextBoxColumn { Name = "DocName", HeaderText = "Tên tài liệu", Width = 250 });
            dgvRelated.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subject", HeaderText = "Môn học", Width = 120 });
            dgvRelated.Columns.Add(new DataGridViewTextBoxColumn { Name = "Type", HeaderText = "Loại", Width = 80 });
            dgvRelated.Columns.Add(new DataGridViewTextBoxColumn { Name = "RelationType", HeaderText = "Quan hệ", Width = 100 });
            dgvRelated.Columns.Add(new DataGridViewTextBoxColumn { Name = "RelationId", Visible = false });
            dgvRelated.Columns.Add(new DataGridViewTextBoxColumn { Name = "DocId", Visible = false });

            this.Controls.Add(dgvRelated);

            // Bottom actions
            pnlActions = new Panel { Dock = DockStyle.Bottom, Height = 50, Padding = new Padding(12, 8, 12, 8) };

            btnRemove = new Button { Text = "Xóa liên kết", Size = new Size(120, 35), Location = new Point(12, 8) };
            btnRemove.Click += BtnRemove_Click;

            btnClose = new Button { Text = "Đóng", Size = new Size(90, 35), Location = new Point(630, 8) };
            btnClose.Click += (s, e) => this.Close();

            pnlActions.Controls.AddRange(new Control[] { btnRemove, btnClose });
            this.Controls.Add(pnlActions);

            dgvRelated.BringToFront();
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.BackgroundMain;
            pnlHeader.BackColor = AppTheme.BackgroundCard;
            pnlAddRelation.BackColor = AppTheme.BackgroundSoft;
            pnlActions.BackColor = AppTheme.BackgroundSoft;

            AppTheme.ApplyButtonPrimary(btnAdd);
            AppTheme.ApplyButtonDanger(btnRemove);
            AppTheme.ApplyButtonSecondary(btnClose);
            AppTheme.ApplyDataGridViewStyle(dgvRelated);
        }

        private void LoadRelatedDocuments()
        {
            dgvRelated.Rows.Clear();
            try
            {
                var dt = DatabaseHelper.GetRelatedDocuments(currentDocId);
                foreach (DataRow row in dt.Rows)
                {
                    dgvRelated.Rows.Add(
                        row["ten"]?.ToString(),
                        row["mon_hoc"]?.ToString(),
                        row["loai"]?.ToString(),
                        row["relation_type"]?.ToString(),
                        row["relation_id"]?.ToString(),
                        row["id"]?.ToString()
                    );
                }
            }
            catch { }
        }

        private void LoadAllDocuments()
        {
            cmbDocuments.Items.Clear();
            try
            {
                var dt = DatabaseHelper.GetAllDocuments();
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    if (id == currentDocId) continue;
                    cmbDocuments.Items.Add(new DocItem { Id = id, Name = row["ten"]?.ToString() });
                }
                cmbDocuments.DisplayMember = "Name";
            }
            catch { }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var selected = cmbDocuments.SelectedItem as DocItem;
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn tài liệu từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string relType = cmbRelationType.SelectedItem?.ToString() ?? "Liên quan";
            try
            {
                DatabaseHelper.AddDocumentRelation(currentDocId, selected.Id, relType);
                LoadRelatedDocuments();
                ToastNotification.Success("Đã thêm liên kết");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvRelated.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn liên kết cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int relationId;
            if (!int.TryParse(dgvRelated.SelectedRows[0].Cells["RelationId"].Value?.ToString(), out relationId))
                return;

            var confirm = MessageBox.Show("Xóa liên kết này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            DatabaseHelper.RemoveDocumentRelation(relationId);
            LoadRelatedDocuments();
        }

        private class DocItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() { return Name; }
        }
    }
}

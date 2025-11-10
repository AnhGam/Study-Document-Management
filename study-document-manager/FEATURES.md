# ?? DANH SÁCH TÍNH N?NG CÓ TH? NÂNG C?P

> **Study Document Manager** - K? ho?ch phát tri?n tính n?ng

---

## ?? **PHASE 1 - C?N LÀM NGAY** (1-2 tu?n)

### ? 1. Backup & Restore Database
**?? ?u tiên:** ?????  
**Th?i gian ??c tính:** 2-3 ngày

**Mô t?:**
Sao l?u và ph?c h?i d? li?u ?? tránh m?t mát

**Tính n?ng:**
- [ ] Menu: `File > Backup Database`
- [ ] Menu: `File > Restore Database`  
- [ ] T? ??ng backup theo l?ch (hàng ngày/tu?n)
- [ ] Export sang file `.bak` ho?c `.sql`
- [ ] Import t? file backup

**File c?n s?a:**
```
- Form1.Designer.cs (thêm menu items)
- Form1.cs (event handlers)
- DatabaseHelper.cs (methods backup/restore)
```

**Database Changes:** Không c?n

---

### ? 2. Tìm Ki?m Nâng Cao
**?? ?u tiên:** ?????  
**Th?i gian ??c tính:** 3-4 ngày

**Mô t?:**
Form tìm ki?m v?i nhi?u filter ph?c t?p

**Tính n?ng:**
- [ ] Form m?i: `AdvancedSearchForm`
- [ ] Filter theo kho?ng th?i gian (t? ngày - ??n ngày)
- [ ] Filter theo kích th??c file (t? MB - ??n MB)
- [ ] Filter ch? tài li?u quan tr?ng
- [ ] Filter nhi?u môn h?c cùng lúc (checkbox list)
- [ ] Tìm tài li?u không có file (???ng d?n tr?ng)
- [ ] L?u l?ch s? tìm ki?m g?n ?ây (10 query)
- [ ] Save/Load search profiles

**File c?n t?o:**
```
- AdvancedSearchForm.cs
- AdvancedSearchForm.Designer.cs
- AdvancedSearchForm.resx
```

**File c?n s?a:**
```
- DatabaseHelper.cs (thêm AdvancedSearchDocuments)
- Form1.cs (button/menu m? AdvancedSearch)
```

**Database Changes:** 
```sql
-- B?ng l?u l?ch s? tìm ki?m
CREATE TABLE search_history (
    id INT PRIMARY KEY IDENTITY(1,1),
    search_query NVARCHAR(500),
    filters NVARCHAR(MAX), -- JSON
    search_date DATETIME DEFAULT GETDATE()
);
```

---

### ? 3. Context Menu (Quick Actions)
**?? ?u tiên:** ????  
**Th?i gian ??c tính:** 1-2 ngày

**Mô t?:**
Chu?t ph?i trên DataGridView ?? thao tác nhanh

**Tính n?ng:**
- [ ] M? file
- [ ] S?a
- [ ] Xóa
- [ ] Copy ???ng d?n file
- [ ] ?ánh d?u/B? ?ánh d?u quan tr?ng
- [ ] M? th? m?c ch?a file (Explorer)
- [ ] Xem properties (thông tin chi ti?t)
- [ ] Copy tên file
- [ ] Rename file

**File c?n s?a:**
```
- Form1.Designer.cs (thêm ContextMenuStrip)
- Form1.cs (event handlers cho context menu)
```

**Database Changes:** Không c?n

---

### ? 4. Keyboard Shortcuts ??y ??
**?? ?u tiên:** ????  
**Th?i gian ??c tính:** 1 ngày

**Mô t?:**
Phím t?t ti?n l?i cho các thao tác th??ng dùng

**Tính n?ng:**
- [ ] `F2` - S?a tài li?u
- [ ] `Delete` - Xóa tài li?u
- [ ] `Ctrl+F` - Focus search box
- [ ] `Ctrl+R` - Refresh danh sách
- [ ] `Ctrl+D` - Toggle ?ánh d?u quan tr?ng
- [ ] `Enter` - M? file ???c ch?n
- [ ] `Escape` - Clear search
- [ ] `Ctrl+N` - Thêm tài li?u m?i
- [ ] `Ctrl+E` - Export data
- [ ] `Ctrl+S` - Statistics
- [ ] `Ctrl+B` - Backup database

**File c?n s?a:**
```
- Form1.cs (KeyDown event, ProcessCmdKey override)
```

**Database Changes:** Không c?n

---

### ? 5. Ki?m Tra File B? Thi?u
**?? ?u tiên:** ????  
**Th?i gian ??c tính:** 2 ngày

**Mô t?:**
Quét và list file không t?n t?i

**Tính n?ng:**
- [ ] Menu: `Công c? > Ki?m tra tính toàn v?n`
- [ ] Quét toàn b? `duong_dan` trong database
- [ ] List các file không t?n t?i
- [ ] Option: Xóa record ho?c ch?n file m?i
- [ ] Option: Set ???ng d?n = NULL
- [ ] Hi?n th? progress bar khi quét
- [ ] Export danh sách file thi?u ra CSV

**File c?n t?o:**
```
- FileIntegrityCheckForm.cs
- FileIntegrityCheckForm.Designer.cs
- FileIntegrityCheckForm.resx
```

**File c?n s?a:**
```
- Form1.cs (menu item)
- DatabaseHelper.cs (GetAllFilePaths, UpdateFilePath)
```

**Database Changes:** Không c?n

---

## ?? **PHASE 2 - NÂNG CAO** (2-3 tu?n)

### ? 6. Tags/Nhãn Cho Tài Li?u
**?? ?u tiên:** ?????  
**Th?i gian ??c tính:** 3-4 ngày

**Mô t?:**
Phân lo?i linh ho?t b?ng tags

**Tính n?ng:**
- [ ] Thêm c?t `tags` vào b?ng `tai_lieu`
- [ ] M?t tài li?u nhi?u tags (phân cách b?ng `;`)
- [ ] Ví d?: `quan tr?ng;thi cu?i k?;khó`
- [ ] Filter theo tags
- [ ] G?i ý tags ph? bi?n khi nh?p
- [ ] Tag cloud visualization
- [ ] Quick tag buttons (common tags)

**File c?n s?a:**
```
- Database\Database.sql (ALTER TABLE)
- AddEditForm.Designer.cs (thêm TextBox/ComboBox tags)
- AddEditForm.cs (x? lý tags)
- DatabaseHelper.cs (UPDATE queries)
- Form1.cs (filter tags)
```

**Database Changes:**
```sql
-- Thêm c?t tags
ALTER TABLE tai_lieu ADD tags NVARCHAR(500);

-- B?ng tags ph? bi?n (optional)
CREATE TABLE popular_tags (
    tag_name NVARCHAR(50) PRIMARY KEY,
    usage_count INT DEFAULT 0
);
```

---

### ? 7. Preview File
**?? ?u tiên:** ????  
**Th?i gian ??c tính:** 5-7 ngày

**Mô t?:**
Xem tr??c n?i dung file không c?n m? ?ng d?ng

**Tính n?ng:**
- [ ] Panel preview bên ph?i form chính
- [ ] PDF: Hi?n th? thumbnail trang ??u (dùng PdfiumViewer)
- [ ] Word: Hi?n th? 5 dòng ??u (dùng DocX)
- [ ] Text: Hi?n th? toàn b? n?i dung
- [ ] Image: Hi?n th? ?nh thumbnail
- [ ] Metadata: Tác gi?, ngày t?o, s? trang
- [ ] Toggle show/hide preview panel

**File c?n t?o:**
```
- PreviewPanel.cs (UserControl)
- PreviewPanel.Designer.cs
```

**File c?n s?a:**
```
- Form1.Designer.cs (thêm SplitContainer)
- Form1.cs (load preview khi select row)
```

**NuGet Packages:**
```
- PdfiumViewer (PDF preview)
- DocX (Word preview)
```

**Database Changes:** Không c?n

---

### ? 8. Dashboard Chi Ti?t
**?? ?u tiên:** ????  
**Th?i gian ??c tính:** 4-5 ngày

**Mô t?:**
Th?ng kê t?ng quan v?i nhi?u bi?u ??

**Tính n?ng:**
- [ ] Bi?u ?? tròn: % tài li?u theo lo?i
- [ ] Timeline: S? tài li?u thêm m?i theo tháng
- [ ] Top 5 môn h?c có nhi?u tài li?u nh?t
- [ ] T?ng kích th??c file ?ã l?u (GB)
- [ ] Tài li?u ???c m? nhi?u nh?t (c?n thêm c?t view_count)
- [ ] Recent activities (10 tài li?u m?i nh?t)
- [ ] Quick stats cards (Total, Important, This Week)

**File c?n t?o:**
```
- DashboardForm.cs
- DashboardForm.Designer.cs
- DashboardForm.resx
```

**File c?n s?a:**
```
- DatabaseHelper.cs (thêm GetDashboardStats)
- Form1.cs (menu/button m? Dashboard)
```

**Database Changes:**
```sql
-- Thêm c?t view_count
ALTER TABLE tai_lieu ADD view_count INT DEFAULT 0;
```

---

### ? 9. Recent Files
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 2 ngày

**Mô t?:**
L?u và hi?n th? tài li?u m? g?n ?ây

**Tính n?ng:**
- [ ] L?u 20 tài li?u m? g?n nh?t
- [ ] Menu: `File > Recent Files`
- [ ] Hi?n th? trong Panel riêng (dockable)
- [ ] Clear recent files history
- [ ] Pin favorite files

**File c?n s?a:**
```
- Form1.Designer.cs (menu Recent Files)
- Form1.cs (track opened files)
- DatabaseHelper.cs (UpdateViewCount, GetRecentFiles)
```

**Database Changes:**
```sql
-- Thêm c?t last_opened
ALTER TABLE tai_lieu ADD last_opened DATETIME;
```

---

### ? 10. Dark Mode
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 3-4 ngày

**Mô t?:**
Ch? ?? giao di?n t?i

**Tính n?ng:**
- [ ] Toggle Dark/Light theme
- [ ] Menu: `View > Dark Mode`
- [ ] L?u theme preference vào config
- [ ] Apply theme cho t?t c? forms
- [ ] Smooth transition

**File c?n t?o:**
```
- ThemeManager.cs (static class)
```

**File c?n s?a:**
```
- All forms (apply theme)
- App.config (save preference)
```

**Database Changes:** Không c?n

---

## ?? **PHASE 3 - B?O M?T & PHÂN QUY?N** (3-4 tu?n)

### ? 11. Login & User Management
**?? ?u tiên:** ?????  
**Th?i gian ??c tính:** 7-10 ngày

**Mô t?:**
H? th?ng ??ng nh?p v?i phân quy?n

**Tính n?ng:**
- [ ] Form Login
- [ ] Form Register (admin only)
- [ ] Form User Management (admin only)
- [ ] Roles: Admin, Teacher, Student
- [ ] Permissions:
  - Admin: Full quy?n
  - Teacher: Thêm/s?a/xóa tài li?u c?a mình
  - Student: Ch? xem và download
- [ ] Password hashing (BCrypt)
- [ ] Remember Me
- [ ] Forgot Password
- [ ] Change Password

**File c?n t?o:**
```
- LoginForm.cs
- LoginForm.Designer.cs
- UserManagementForm.cs
- UserManagementForm.Designer.cs
- UserSession.cs (static class)
```

**File c?n s?a:**
```
- Program.cs (show LoginForm first)
- Form1.cs (check permissions)
- DatabaseHelper.cs (user methods)
```

**Database Changes:**
```sql
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) UNIQUE NOT NULL,
    password_hash NVARCHAR(255) NOT NULL,
    full_name NVARCHAR(100),
    email NVARCHAR(100),
    role NVARCHAR(20) DEFAULT 'Student',
    is_active BIT DEFAULT 1,
    created_date DATETIME DEFAULT GETDATE(),
    last_login DATETIME
);

-- Thêm c?t user_id vào tai_lieu
ALTER TABLE tai_lieu ADD user_id INT;
ALTER TABLE tai_lieu ADD FOREIGN KEY (user_id) REFERENCES users(id);
```

**NuGet Packages:**
```
- BCrypt.Net-Next (password hashing)
```

---

### ? 12. Activity Log
**?? ?u tiên:** ????  
**Th?i gian ??c tính:** 3-4 ngày

**Mô t?:**
L?ch s? ho?t ??ng c?a ng??i dùng

**Tính n?ng:**
- [ ] Log m?i thao tác: Thêm/S?a/Xóa/Xem
- [ ] Form Activity Log (admin only)
- [ ] Filter theo user, action, date range
- [ ] Export log ra CSV
- [ ] Auto cleanup old logs (> 6 months)

**File c?n t?o:**
```
- ActivityLogForm.cs
- ActivityLogForm.Designer.cs
- ActivityLogger.cs (static class)
```

**File c?n s?a:**
```
- Form1.cs (log actions)
- DatabaseHelper.cs (log methods)
```

**Database Changes:**
```sql
CREATE TABLE activity_logs (
    id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    action NVARCHAR(50) NOT NULL, -- Add, Edit, Delete, View
    document_id INT,
    details NVARCHAR(500),
    ip_address NVARCHAR(50),
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE INDEX idx_activity_logs_user ON activity_logs(user_id);
CREATE INDEX idx_activity_logs_date ON activity_logs(created_date);
```

---

### ? 13. Reminder/Deadline
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 4-5 ngày

**Mô t?:**
Nh?c nh? deadline tài li?u

**Tính n?ng:**
- [ ] Thêm c?t `deadline` vào tài li?u
- [ ] Ví d?: "?? thi gi?a k? - h?n: 15/12/2024"
- [ ] Toast notification khi g?n deadline (3 ngày, 1 ngày)
- [ ] Dashboard hi?n th? upcoming deadlines
- [ ] Mark as completed
- [ ] Recurring reminders

**File c?n t?o:**
```
- ReminderService.cs (background timer)
- NotificationHelper.cs (toast notifications)
```

**File c?n s?a:**
```
- Database\Database.sql (ALTER TABLE)
- AddEditForm.cs (DateTimePicker deadline)
- Form1.cs (start ReminderService)
```

**Database Changes:**
```sql
ALTER TABLE tai_lieu ADD deadline DATETIME;
ALTER TABLE tai_lieu ADD deadline_completed BIT DEFAULT 0;
```

**NuGet Packages:**
```
- Tulpep.NotificationWindow (toast notifications)
```

---

## ?? **PHASE 4 - QU?N LÝ FILE** (3-4 tu?n)

### ? 14. L?u File Vào Database (Binary)
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 5-7 ngày

**Mô t?:**
L?u file tr?c ti?p vào database

**Tính n?ng:**
- [ ] Option: L?u file vào DB ho?c ch? l?u ???ng d?n
- [ ] Gi?i h?n kích th??c file (50MB)
- [ ] Nén file tr??c khi l?u
- [ ] Extract file khi m?
- [ ] Migrate existing files to DB

**File c?n s?a:**
```
- Database\Database.sql (ALTER TABLE)
- AddEditForm.cs (checkbox "Store in DB")
- Form1.cs (open file from DB)
- DatabaseHelper.cs (file storage methods)
```

**Database Changes:**
```sql
ALTER TABLE tai_lieu ADD file_data VARBINARY(MAX);
ALTER TABLE tai_lieu ADD store_in_db BIT DEFAULT 0;
```

---

### ? 15. Cloud Sync (Google Drive)
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 10-14 ngày

**Mô t?:**
??ng b? file lên Google Drive

**Tính n?ng:**
- [ ] Tích h?p Google Drive API
- [ ] Auto upload new files
- [ ] Sync file v? khi c?n
- [ ] Conflict resolution
- [ ] Offline mode support

**File c?n t?o:**
```
- CloudSyncService.cs
- CloudSettingsForm.cs
```

**File c?n s?a:**
```
- AddEditForm.cs (sync after save)
- Form1.cs (sync button)
```

**NuGet Packages:**
```
- Google.Apis.Drive.v3
- Google.Apis.Auth
```

**Database Changes:**
```sql
ALTER TABLE tai_lieu ADD cloud_file_id NVARCHAR(255);
ALTER TABLE tai_lieu ADD last_synced DATETIME;
```

---

### ? 16. Duplicate Detection
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 3-4 ngày

**Mô t?:**
Tìm file trùng l?p

**Tính n?ng:**
- [ ] So sánh tên file, kích th??c
- [ ] Hash file content ?? tìm file trùng (MD5)
- [ ] List duplicates
- [ ] Option: Keep newest, Keep largest, Manual select
- [ ] Merge duplicate records

**File c?n t?o:**
```
- DuplicateDetectionForm.cs
- DuplicateDetectionForm.Designer.cs
```

**File c?n s?a:**
```
- Form1.cs (menu item)
- DatabaseHelper.cs (FindDuplicates)
```

**Database Changes:**
```sql
ALTER TABLE tai_lieu ADD file_hash NVARCHAR(32);
CREATE INDEX idx_file_hash ON tai_lieu(file_hash);
```

---

### ? 17. Version Control
**?? ?u tiên:** ??  
**Th?i gian ??c tính:** 7-10 ngày

**Mô t?:**
L?u nhi?u phiên b?n c?a tài li?u

**Tính n?ng:**
- [ ] B?ng `document_versions`
- [ ] Track changes
- [ ] Rollback v? version c?
- [ ] Compare versions
- [ ] Auto versioning when file changes

**File c?n t?o:**
```
- VersionHistoryForm.cs
- VersionHistoryForm.Designer.cs
```

**File c?n s?a:**
```
- AddEditForm.cs (save new version)
- DatabaseHelper.cs (version methods)
```

**Database Changes:**
```sql
CREATE TABLE document_versions (
    id INT PRIMARY KEY IDENTITY(1,1),
    document_id INT NOT NULL,
    version_number INT NOT NULL,
    file_data VARBINARY(MAX),
    duong_dan NVARCHAR(500),
    modified_by INT,
    modified_date DATETIME DEFAULT GETDATE(),
    change_notes NVARCHAR(500),
    FOREIGN KEY (document_id) REFERENCES tai_lieu(id),
    FOREIGN KEY (modified_by) REFERENCES users(id)
);
```

---

## ?? **PHASE 5 - CHIA S? & H?P TÁC** (2-3 tu?n)

### ? 18. Comments/Reviews
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 4-5 ngày

**Mô t?:**
Bình lu?n và ?ánh giá tài li?u

**Tính n?ng:**
- [ ] B?ng `comments`
- [ ] ?ánh giá 1-5 sao
- [ ] Hi?n th? comments trong form chi ti?t
- [ ] Reply to comments
- [ ] Like/Dislike comments

**File c?n t?o:**
```
- DocumentDetailForm.cs (show comments)
- DocumentDetailForm.Designer.cs
```

**File c?n s?a:**
```
- Form1.cs (open detail form)
- DatabaseHelper.cs (comment methods)
```

**Database Changes:**
```sql
CREATE TABLE comments (
    id INT PRIMARY KEY IDENTITY(1,1),
    document_id INT NOT NULL,
    user_id INT NOT NULL,
    comment_text NVARCHAR(1000),
    rating INT CHECK (rating >= 1 AND rating <= 5),
    parent_comment_id INT, -- for replies
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (document_id) REFERENCES tai_lieu(id),
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (parent_comment_id) REFERENCES comments(id)
);
```

---

### ? 19. Share Link
**?? ?u tiên:** ??  
**Th?i gian ??c tính:** 3-4 ngày

**Mô t?:**
T?o link chia s? tài li?u

**Tính n?ng:**
- [ ] Generate unique share link
- [ ] Link expiration date
- [ ] Password protected links
- [ ] Track link views
- [ ] Revoke link

**File c?n t?o:**
```
- ShareLinkForm.cs
- ShareLinkForm.Designer.cs
```

**File c?n s?a:**
```
- Form1.cs (share button)
- DatabaseHelper.cs (share methods)
```

**Database Changes:**
```sql
CREATE TABLE share_links (
    id INT PRIMARY KEY IDENTITY(1,1),
    document_id INT NOT NULL,
    share_token NVARCHAR(50) UNIQUE NOT NULL,
    password_hash NVARCHAR(255),
    expires_date DATETIME,
    view_count INT DEFAULT 0,
    created_by INT NOT NULL,
    created_date DATETIME DEFAULT GETDATE(),
    is_active BIT DEFAULT 1,
    FOREIGN KEY (document_id) REFERENCES tai_lieu(id),
    FOREIGN KEY (created_by) REFERENCES users(id)
);
```

---

## ??? **PHASE 6 - CÔNG C? B? SUNG** (4-6 tu?n)

### ? 20. OCR Cho PDF Scan
**?? ?u tiên:** ??  
**Th?i gian ??c tính:** 7-10 ngày

**Mô t?:**
Trích xu?t text t? PDF scan

**Tính n?ng:**
- [ ] Dùng Tesseract OCR
- [ ] Trích xu?t text t? PDF scan
- [ ] L?u vào c?t `full_text_content`
- [ ] Full-text search
- [ ] Support multiple languages (Vietnamese)

**File c?n t?o:**
```
- OCRService.cs
```

**File c?n s?a:**
```
- AddEditForm.cs (OCR button)
- DatabaseHelper.cs (full-text search)
```

**NuGet Packages:**
```
- Tesseract (OCR engine)
- PdfiumViewer (PDF rendering)
```

**Database Changes:**
```sql
ALTER TABLE tai_lieu ADD full_text_content NVARCHAR(MAX);
CREATE FULLTEXT INDEX ON tai_lieu(full_text_content);
```

---

### ? 21. Auto-Categorize B?ng AI
**?? ?u tiên:** ??  
**Th?i gian ??c tính:** 10-14 ngày

**Mô t?:**
T? ??ng g?i ý môn h?c/lo?i d?a trên ML

**Tính n?ng:**
- [ ] Keyword matching ??n gi?n
- [ ] Train ML model (Naive Bayes)
- [ ] Suggest môn h?c d?a trên tên file
- [ ] Suggest tags
- [ ] Improve model over time

**File c?n t?o:**
```
- AutoCategorizationService.cs
```

**File c?n s?a:**
```
- AddEditForm.cs (auto-suggest)
```

**NuGet Packages:**
```
- Accord.MachineLearning
- Accord.Statistics
```

**Database Changes:** Không c?n

---

### ? 22. Báo Cáo T? ??ng
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 5-7 ngày

**Mô t?:**
Export báo cáo Word/PDF

**Tính n?ng:**
- [ ] Export báo cáo Word (dùng DocX)
- [ ] Export báo cáo PDF (dùng iTextSharp)
- [ ] N?i dung: Th?ng kê + bi?u ?? + danh sách
- [ ] Template customization
- [ ] Schedule reports (weekly/monthly)
- [ ] Email reports

**File c?n t?o:**
```
- ReportGenerator.cs
- ReportTemplateForm.cs
```

**File c?n s?a:**
```
- Report.cs (export button)
```

**NuGet Packages:**
```
- DocX (Word generation)
- iTextSharp (PDF generation)
```

**Database Changes:** Không c?n

---

## ?? **PHASE 7 - TÍCH H?P** (3-4 tu?n)

### ? 23. Multi-Language Support
**?? ?u tiên:** ??  
**Th?i gian ??c tính:** 5-7 ngày

**Mô t?:**
H? tr? nhi?u ngôn ng?

**Tính n?ng:**
- [ ] i18n implementation
- [ ] Languages: Ti?ng Vi?t, English
- [ ] Resources.resx cho m?i ngôn ng?
- [ ] Language switcher
- [ ] Save preference

**File c?n t?o:**
```
- Resources.en.resx
- Resources.vi.resx
- LanguageManager.cs
```

**File c?n s?a:**
```
- All forms (load text from Resources)
- App.config (language preference)
```

**Database Changes:** Không c?n

---

### ? 24. Email Integration
**?? ?u tiên:** ??  
**Th?i gian ??c tính:** 4-5 ngày

**Mô t?:**
G?i/nh?n tài li?u qua email

**Tính n?ng:**
- [ ] G?i tài li?u qua email (attachment)
- [ ] Share link via email
- [ ] Email reminders
- [ ] SMTP configuration

**File c?n t?o:**
```
- EmailService.cs
- EmailSettingsForm.cs
```

**File c?n s?a:**
```
- Form1.cs (email button)
- App.config (SMTP settings)
```

**NuGet Packages:**
```
- MailKit (email sending)
```

**Database Changes:** Không c?n

---

### ? 25. Export Sang Notion/Obsidian
**?? ?u tiên:** ?  
**Th?i gian ??c tính:** 7-10 ngày

**Mô t?:**
Tích h?p v?i note-taking apps

**Tính n?ng:**
- [ ] Export danh sách sang Markdown
- [ ] Notion API integration
- [ ] Obsidian vault export
- [ ] Sync metadata

**File c?n t?o:**
```
- NotionIntegration.cs
- ObsidianExporter.cs
```

**File c?n s?a:**
```
- Form1.cs (export menu)
```

**NuGet Packages:**
```
- Notion.Client (Notion API)
```

**Database Changes:** Không c?n

---

## ?? **PHASE 8 - K? THU?T** (2-3 tu?n)

### ? 26. Offline Mode
**?? ?u tiên:** ???  
**Th?i gian ??c tính:** 7-10 ngày

**Mô t?:**
Ho?t ??ng offline v?i SQLite

**Tính n?ng:**
- [ ] SQLite local database
- [ ] Auto switch when SQL Server unavailable
- [ ] Sync when online
- [ ] Conflict resolution

**File c?n s?a:**
```
- DatabaseHelper.cs (support SQLite)
```

**NuGet Packages:**
```
- System.Data.SQLite
```

**Database Changes:**
```
Create equivalent SQLite schema
```

---

### ? 27. Performance Optimization
**?? ?u tiên:** ????  
**Th?i gian ??c tính:** 5-7 ngày

**Mô t?:**
T?i ?u hi?u n?ng

**Tính n?ng:**
- [ ] Lazy loading DataGridView (50 rows/page)
- [ ] Cache d? li?u th??ng dùng
- [ ] Database indexes
- [ ] Async loading
- [ ] Memory optimization

**File c?n s?a:**
```
- Form1.cs (pagination)
- DatabaseHelper.cs (caching)
- Database\Database.sql (indexes)
```

**Database Changes:**
```sql
-- Indexes for performance
CREATE INDEX idx_tai_lieu_mon_hoc ON tai_lieu(mon_hoc);
CREATE INDEX idx_tai_lieu_loai ON tai_lieu(loai);
CREATE INDEX idx_tai_lieu_ngay_them ON tai_lieu(ngay_them);
CREATE INDEX idx_tai_lieu_ten ON tai_lieu(ten);
```

---

### ? 28. Customizable Layout
**?? ?u tiên:** ??  
**Th?i gian ??c tính:** 3-4 ngày

**Mô t?:**
Ng??i dùng t? ?i?u ch?nh layout

**Tính n?ng:**
- [ ] Resize columns
- [ ] Reorder columns
- [ ] Show/Hide columns
- [ ] Save layout preference
- [ ] Reset to default

**File c?n s?a:**
```
- Form1.cs (save/load layout)
- App.config (layout settings)
```

**Database Changes:** Không c?n

---

## ?? **T?NG K?T**

### **Th?ng Kê Tính N?ng**

| Phase | S? l??ng tính n?ng | Th?i gian ??c tính | ?? ?u tiên trung bình |
|-------|-------------------|--------------------|-----------------------|
| Phase 1 | 5 | 9-12 ngày | ????? |
| Phase 2 | 5 | 17-24 ngày | ???? |
| Phase 3 | 3 | 14-19 ngày | ???? |
| Phase 4 | 4 | 25-35 ngày | ??? |
| Phase 5 | 2 | 7-9 ngày | ??? |
| Phase 6 | 3 | 22-31 ngày | ?? |
| Phase 7 | 3 | 16-22 ngày | ?? |
| Phase 8 | 3 | 15-21 ngày | ??? |
| **T?NG** | **28** | **~125-173 ngày** | - |

---

## ?? **G?I Ý CHO ?? ÁN CU?I K?**

### **Top 5 Picks Cho Demo ?n T??ng:**

1. ? **Backup/Restore** - Th? hi?n tính b?o m?t
2. ? **Tìm ki?m nâng cao + Tags** - Tính linh ho?t
3. ? **Preview File** - Wow effect cao
4. ? **Dashboard ??p** - ?n t??ng giáo viên  
5. ? **Dark Mode** - Modern, trendy

### **L? Trình ?? Xu?t (4-6 tu?n):**

**Tu?n 1-2:** Phase 1 (Tính n?ng c? b?n)  
**Tu?n 3-4:** Phase 2 (Nâng cao UI/UX)  
**Tu?n 5-6:** Hoàn thi?n, test, làm báo cáo

---

## ?? **GHI CHÚ**

- Th?i gian ??c tính d?a trên 1 developer làm full-time
- Có th? song song m?t s? tính n?ng không ph? thu?c nhau
- Nên làm test coverage cho các tính n?ng quan tr?ng
- Database migration script c?n chu?n b? cho production

---

**C?p nh?t l?n cu?i:** 2024-01-XX  
**Phiên b?n:** 1.0  
**Tác gi?:** Study Document Manager Team

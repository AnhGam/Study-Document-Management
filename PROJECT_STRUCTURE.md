# Cấu trúc dự án Study Document Manager (Personal Mode)

Tài liệu này mô tả kiến trúc, luồng dữ liệu và cấu trúc thư mục của ứng dụng **Study Document Manager**.

Ứng dụng được xây dựng trên **Windows Forms (.NET Framework 4.8)** và **SQLite**, hoạt động theo chế độ **Personal Mode** (đơn người dùng, portable), không yêu cầu cài đặt SQL Server hay đăng nhập.

---

## 1. Tổng quan kiến trúc

### 1.1. Kiến trúc tầng

Ứng dụng tổ chức theo mô hình 3 tầng gọn nhẹ:

```
┌─────────────────────────────────────────────────────────────┐
│  PRESENTATION LAYER (UI - Windows Forms)                    │
│  ├── Documents/: Dashboard, AddEditForm, PersonalNoteForm   │
│  ├── Management/: CategoryManagementForm,                   │
│  │               CollectionManagementForm, FileIntegrityForm│
│  ├── Reports/: Report                                       │
│  └── UI/: AppTheme, ToastNotification, Modern Controls      │
│     └── Controls/: ModernButton, ModernTextBox, InputBox    │
├─────────────────────────────────────────────────────────────┤
│  BUSINESS & DATA ACCESS LAYER (Repository Pattern)          │
│  ├── Data/: DatabaseHelper, DashboardStats                  │
│  ├── Core/Entities/: StudyDocument                          │
│  ├── Core/Interfaces/: IDocumentRepository                  │
│  └── Infrastructure/Repositories/: DocumentRepository       │
├─────────────────────────────────────────────────────────────┤
│  DATA LAYER (SQLite)                                        │
│  Database: bin/Debug/data/study_documents.db                │
│  Tables: tai_lieu, collections, collection_items,           │
│          personal_notes, categories                         │
└─────────────────────────────────────────────────────────────┘
```

1. **Presentation Layer (UI)**
   - **Documents/**: Các form chính quản lý tài liệu.
   - **Management/**: Các form quản lý danh mục, bộ sưu tập, kiểm tra file.
   - **UI/Controls/**: Bộ thư viện Custom Controls (`ModernButton`, `ModernInputBox`...) theo theme Teal/Emerald.
   - **AppTheme.cs**: Định nghĩa màu sắc và style toàn cục.

2. **Business & Data Access Layer**
   - **DatabaseHelper**: Lớp tiện ích tĩnh xử lý kết nối SQLite và các truy vấn CRUD cơ bản.
   - **Repository Pattern**: Đang dần chuyển đổi sang `DocumentRepository` để tách biệt logic truy vấn.

3. **Data Layer (SQLite)**
   - Sử dụng `System.Data.SQLite`.
   - File database tự động tạo tại `bin/Debug/data/study_documents.db` nếu chưa tồn tại.
   - Không cần cài đặt server, chỉ cần copy thư mục là chạy.

### 1.2. Các khối chức năng chính

- **Quản lý tài liệu**: Thêm, sửa, xóa, mở file, tìm kiếm, filter.
- **Personal Mode**: Mặc định là quyền Admin cao nhất, quản lý toàn bộ dữ liệu cục bộ.
- **Modern UI**: Giao diện phẳng, Toast Notification hiện đại, Input Box tùy chỉnh.
- **Filter nâng cao**: Theo danh mục, loại, ngày tháng, dung lượng, quan trọng.
- **Bộ sưu tập (Collections)**: Gom nhóm tài liệu tùy ý.
- **File Integrity**: Quét và xử lý các file bị xóa khỏi ổ cứng.
- **Thống kê**: Biểu đồ trực quan về số lượng và phân bố tài liệu.

---

## 2. Cấu trúc thư mục & file chính

### 2.1. Root repository

```text
study-document-manager/
│
├── study-document-manager/             # Project WinForms (.csproj)
│   │
│   ├── Program.cs                      # Entry point (Khởi tạo DB -> Mở Dashboard)
│   ├── App.config                      # Cấu hình (SQLite connection string)
│   │
│   ├── Documents/                      # Forms quản lý tài liệu
│   │   ├── Dashboard.cs                # Màn hình chính
│   │   ├── AddEditForm.cs              # Thêm / sửa tài liệu
│   │   └── PersonalNoteForm.cs         # Ghi chú cá nhân
│   │
│   ├── Management/                     # Forms quản lý hệ thống
│   │   ├── CategoryManagementForm.cs   # Quản lý danh mục/loại
│   │   ├── CollectionManagementForm.cs # Quản lý bộ sưu tập
│   │   └── FileIntegrityCheckForm.cs   # Kiểm tra file thiếu
│   │
│   ├── Reports/                        # Báo cáo & thống kê
│   │   └── Report.cs                   # Dashboard thống kê nâng cao
│   │
│   ├── Data/                           # Data Access Layer
│   │   ├── DatabaseHelper.cs           # SQLite Helper (InitializeDB, CRUD)
│   │   └── DashboardStats.cs           # Model thống kê
│   │
│   ├── Core/                           # Entities & Interfaces
│   │   ├── Entities/StudyDocument.cs
│   │   └── Interfaces/IDocumentRepository.cs
│   │
│   ├── Infrastructure/                 # Implementations
│   │   └── Repositories/DocumentRepository.cs
│   │
│   ├── UI/                             # UI Components & Theme
│   │   ├── AppTheme.cs                 # Định nghĩa màu sắc (Teal/Emerald)
│   │   ├── IconHelper.cs               # Xử lý icon file
│   │   ├── ToastNotification.cs        # Thông báo hiện đại
│   │   └── Controls/                   # Custom Controls
│   │       ├── ModernButton.cs
│   │       ├── ModernTextBox.cs
│   │       ├── ModernPanel.cs
│   │       └── ModernInputBox.cs       # Thay thế VB InputBox
│   │
│   ├── assets/                         # Static assets (logo, images)
│   │
│   ├── packages.config                 # NuGet packages (System.Data.SQLite)
│   └── study-document-manager.csproj   # Project file
│
├── README.md                           # Giới thiệu & hướng dẫn
├── PROJECT_STRUCTURE.md                # (file hiện tại)
└── study-document-manager.sln          # Solution file
```

### 2.2. Database Schema (SQLite)

Database gồm các bảng chính:
- `tai_lieu`: Lưu thông tin tài liệu (id, ten, duong_dan, loai, mon_hoc, ghi_chu, kich_thuoc, ngay_tao, is_important, is_deleted).
- `categories`: Danh mục (môn học) và loại tài liệu.
- `collections`: Tên bộ sưu tập.
- `collection_items`: Liên kết n-n giữa bộ sưu tập và tài liệu.
- `personal_notes`: Ghi chú chi tiết cho từng tài liệu.

---

## 3. Luồng dữ liệu chính

### 3.1. Khởi động ứng dụng

```
Program.Main()
    └── DatabaseHelper.InitializeDatabase()
            └── Check file .db tồn tại?
            └── Nếu chưa: CREATE TABLE ... (Tự động migrate)
    └── Application.Run(new Dashboard())
```

### 3.2. Quản lý tài liệu (Repository Pattern & Helper)

- **Load Data**: `Dashboard` -> `DatabaseHelper.GetDocuments()` -> `SQLiteDataAdapter` -> `DataTable`.
- **Search/Filter**: Xây dựng câu truy vấn SQL động dựa trên các tiêu chí (Keyword, Category, Type, Date...).
- **CRUD**:
  - `Insert`: `INSERT INTO tai_lieu ...`
  - `Update`: `UPDATE tai_lieu ...`
  - `Delete`: `UPDATE tai_lieu SET is_deleted = 1` (Soft Delete) hoặc `DELETE` (Hard Delete tùy ngữ cảnh).

---

## 4. UI/UX & Theme System

Hệ thống sử dụng class tĩnh `UI/AppTheme.cs` để quản lý giao diện nhất quán:

- **Màu chủ đạo**: Teal/Emerald (#14B8A6, #10B981).
- **Trạng thái**:
  - Success (Xanh lá): Toast, Button lưu.
  - Error (Đỏ): Toast, Button xóa.
  - Warning (Cam): Cảnh báo.
- **Controls**:
  - `ModernButton`: Button phẳng, bo góc, hiệu ứng hover.
  - `ModernInputBox`: Dialog nhập liệu custom (không dùng Windows native xấu xí).
  - `ToastNotification`: Thông báo nổi góc màn hình, tự động tắt.

---

## 5. Dependencies

- **System.Data.SQLite**: Thư viện chính để làm việc với SQLite.
- **System.Windows.Forms.DataVisualization**: Vẽ biểu đồ.
- **.NET Framework 4.8**: Nền tảng chạy ứng dụng.

---

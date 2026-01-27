# Database Schema (SQLite)

The application uses a local SQLite database named `study_documents.db`.

## Tables

### 1. tai_lieu (Documents)
Stores the main document information.
- `id`: INTEGER PRIMARY KEY AUTOINCREMENT
- `ten`: TEXT NOT NULL (Document Name)
- `mon_hoc`: TEXT (Subject)
- `loai`: TEXT (Type)
- `duong_dan`: TEXT (File Path)
- `ghi_chu`: TEXT (Notes)
- `ngay_them`: DATETIME DEFAULT CURRENT_TIMESTAMP (Date Added)
- `kich_thuoc`: REAL (File Size in MB)
- `tac_gia`: TEXT (Author)
- `quan_trong`: INTEGER DEFAULT 0 (Is Important flag)
- `tags`: TEXT (Semicolon separated tags)
- `deadline`: DATETIME (Optional deadline)

### 2. collections
Stores user-defined collections.
- `id`: INTEGER PRIMARY KEY AUTOINCREMENT
- `name`: TEXT NOT NULL
- `description`: TEXT
- `created_at`: DATETIME DEFAULT CURRENT_TIMESTAMP

### 3. collection_items
Links documents to collections (Many-to-Many).
- `id`: INTEGER PRIMARY KEY AUTOINCREMENT
- `collection_id`: INTEGER NOT NULL (Foreign Key)
- `document_id`: INTEGER NOT NULL (Foreign Key)
- `added_at`: DATETIME DEFAULT CURRENT_TIMESTAMP

### 4. personal_notes
Stores private notes for documents.
- `id`: INTEGER PRIMARY KEY AUTOINCREMENT
- `document_id`: INTEGER NOT NULL (Foreign Key)
- `content`: TEXT
- `created_at`: DATETIME DEFAULT CURRENT_TIMESTAMP
- `updated_at`: DATETIME DEFAULT CURRENT_TIMESTAMP

## Indexes
- `idx_tai_lieu_mon_hoc`
- `idx_tai_lieu_loai`
- `idx_tai_lieu_ngay_them`
- `idx_tai_lieu_deadline`
- `idx_collection_items_collection`
- `idx_collection_items_document`

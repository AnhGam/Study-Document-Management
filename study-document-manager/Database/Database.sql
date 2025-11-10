IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'quan_ly_tai_lieu')
BEGIN
    CREATE DATABASE quan_ly_tai_lieu;
    PRINT N'Database quan_ly_tai_lieu đã được tạo thành công!'
END
GO

USE quan_ly_tai_lieu;
GO

IF OBJECT_ID('tai_lieu', 'U') IS NOT NULL
BEGIN
    DROP TABLE tai_lieu;
    PRINT N'Đã xóa bảng tai_lieu cũ!'
END
GO

CREATE TABLE tai_lieu (
    id INT PRIMARY KEY IDENTITY(1,1),
    ten NVARCHAR(200) NOT NULL,
    mon_hoc NVARCHAR(100),
    loai NVARCHAR(100),
    duong_dan NVARCHAR(500) NOT NULL,
    ghi_chu NVARCHAR(1000),
    ngay_them DATETIME DEFAULT GETDATE(),
    kich_thuoc FLOAT,
    tac_gia NVARCHAR(100),
    quan_trong BIT DEFAULT 0
);
GO

-- Bảng users cho login/register
IF OBJECT_ID('users', 'U') IS NOT NULL
BEGIN
    DROP TABLE users;
    PRINT N'Đã xóa bảng users cũ!'
END
GO

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
GO

-- Thêm admin mặc định (password: admin123)
INSERT INTO users (username, password_hash, full_name, role, is_active)
VALUES ('admin', '$2a$11$K9YQkrMfP8WzJFxf7PFXZeqE/tZ3NkJ4rN3Z.0qXVl6HkDHQFJGKu', N'Administrator', 'Admin', 1);
GO

PRINT N'Đã tạo user admin mặc định (username: admin, password: admin123)';
GO

-- Thêm cột user_id vào tai_lieu
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tai_lieu') AND name = 'user_id')
BEGIN
    ALTER TABLE tai_lieu ADD user_id INT;
    ALTER TABLE tai_lieu ADD CONSTRAINT FK_tai_lieu_user FOREIGN KEY (user_id) REFERENCES users(id);
    PRINT N'Đã thêm cột user_id vào bảng tai_lieu';
END
GO

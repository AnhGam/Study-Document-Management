using System;

namespace study_document_manager
{
    /// <summary>
    /// Quản lý session người dùng hiện tại
    /// </summary>
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string FullName { get; set; }
        public static string Email { get; set; }
        public static string Role { get; set; }
        public static DateTime LoginTime { get; set; }

        /// <summary>
        /// Kiểm tra đã đăng nhập chưa
        /// </summary>
        public static bool IsLoggedIn
        {
            get { return UserId > 0; }
        }

        /// <summary>
        /// Kiểm tra là Admin
        /// </summary>
        public static bool IsAdmin
        {
            get { return Role == "Admin"; }
        }

        /// <summary>
        /// Kiểm tra là Teacher
        /// </summary>
        public static bool IsTeacher
        {
            get { return Role == "Teacher"; }
        }

        /// <summary>
        /// Kiểm tra là Student
        /// </summary>
        public static bool IsStudent
        {
            get { return Role == "Student"; }
        }

        /// <summary>
        /// Có quyền thêm/sửa/xóa tài liệu không (tất cả user đều có quyền với tài liệu của mình)
        /// </summary>
        public static bool CanEdit
        {
            get { return IsAdmin || IsTeacher || IsStudent; }
        }

        /// <summary>
        /// Có quyền quản lý danh mục không (chỉ Teacher và Admin)
        /// </summary>
        public static bool CanManageCategories
        {
            get { return IsAdmin || IsTeacher; }
        }

        /// <summary>
        /// Có quyền sửa/xóa tài liệu của người khác không (chỉ Admin)
        /// </summary>
        public static bool CanEditAllDocuments
        {
            get { return IsAdmin; }
        }

        /// <summary>
        /// Kiểm tra có quyền sửa/xóa tài liệu cụ thể không
        /// </summary>
        public static bool CanEditDocument(int documentUserId)
        {
            // Admin có thể sửa tất cả
            if (IsAdmin)
                return true;

            // Student và Teacher chỉ sửa được tài liệu của mình
            return documentUserId == UserId;
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        public static void Logout()
        {
            UserId = 0;
            Username = string.Empty;
            FullName = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
        }
    }
}

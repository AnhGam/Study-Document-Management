using System;
using System.Drawing;
using System.Windows.Forms;

namespace study_document_manager
{
    public partial class AccountSettingsForm : Form
    {
        public AccountSettingsForm()
        {
            InitializeComponent();
        }

        private void AccountSettingsForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            txtUsername.Text = UserSession.Username;
            txtFullName.Text = UserSession.FullName;
            txtEmail.Text = UserSession.Email;
            lblRole.Text = UserSession.Role;
            lblLoginTime.Text = UserSession.LoginTime.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                bool success = DatabaseHelper.UpdateUserProfile(UserSession.UserId, fullName, email);
                if (success)
                {
                    UserSession.FullName = fullName;
                    UserSession.Email = email;

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(currentPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                var result = DatabaseHelper.ChangePasswordSelf(UserSession.UserId, currentPassword, newPassword);
                
                if (result.Success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show(result.Message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

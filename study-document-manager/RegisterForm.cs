using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace study_document_manager
{
    public partial class RegisterForm : Form
    {
        public string RegisteredUsername { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Thiết lập icon cho button show password
            btnShowPassword.Image = IconHelper.CreateEyeIcon(16, true);
            btnShowPassword.Text = "";
            btnShowConfirmPassword.Image = IconHelper.CreateEyeIcon(16, true);
            btnShowConfirmPassword.Text = "";
            
            // Chế độ cá nhân: Mặc định là User, ẩn dropdown và label chọn role
            cboRole.Items.Clear();
            cboRole.Items.Add("User");
            cboRole.SelectedIndex = 0;
            cboRole.Enabled = false;
            cboRole.Visible = false;
            lblRole.Visible = false;

            txtUsername.Focus();
        }

        /// <summary>
        /// Button Đăng ký
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validation
            if (!ValidateInput())
                return;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = cboRole.SelectedItem.ToString();

            // Kiểm tra username đã tồn tại
            if (DatabaseHelper.CheckUsernameExists(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            // Kiểm tra email đã tồn tại
            if (!string.IsNullOrEmpty(email) && DatabaseHelper.CheckEmailExists(email))
            {
                MessageBox.Show("Email đã được sử dụng!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // Tạo tài khoản
            bool success = DatabaseHelper.RegisterUser(username, password, fullName, email, role);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công!\n\nBạn có thể đăng nhập ngay bây giờ.", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                RegisteredUsername = username;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Vui lòng thử lại.", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validation input
        /// </summary>
        private bool ValidateInput()
        {
            // Username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Password
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Confirm Password
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            // Full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            // Email (optional nhưng phải hợp lệ nếu nhập)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email không hợp lệ!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra email hợp lệ
        /// </summary>
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Button Hủy
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Hiện mật khẩu khi giữ chuột
        /// </summary>
        private void btnShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        /// <summary>
        /// Ẩn mật khẩu khi nhả chuột
        /// </summary>
        private void btnShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        /// <summary>
        /// Hiện mật khẩu xác nhận khi giữ chuột
        /// </summary>
        private void btnShowConfirmPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmPassword.PasswordChar = '\0';
        }

        /// <summary>
        /// Ẩn mật khẩu xác nhận khi nhả chuột
        /// </summary>
        private void btnShowConfirmPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtConfirmPassword.PasswordChar = '*';
        }
    }
}

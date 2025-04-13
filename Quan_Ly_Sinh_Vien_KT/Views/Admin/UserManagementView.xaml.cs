using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Quan_Ly_Sinh_Vien_KT.Models;

namespace Quan_Ly_Sinh_Vien_KT.Views.Admin
{
    /// <summary>
    /// Interaction logic for UserManagementView.xaml
    /// </summary>
    public partial class UserManagementView : UserControl
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        public UserManagementView()
        {
            InitializeComponent();
            LoadUsers();

            // Thêm sự kiện click cho các nút
            btnAddUser.Click += BtnAddUser_Click;
            btnUpdateUser.Click += BtnUpdateUser_Click;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnClearUser.Click += BtnClearUser_Click;
            btnFindStudent.Click += BtnFindStudent_Click;

            // Thêm sự kiện cho DataGrid
            dgUsers.SelectionChanged += DgUsers_SelectionChanged;
        }

        private void LoadUsers()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = @"SELECT u.*, s.Name as StudentName 
                               FROM [User] u 
                               LEFT JOIN Student s ON u.IdStudent = s.Id";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);

                dgUsers.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void DgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgUsers.SelectedItem;

                // Hiển thị thông tin người dùng
                if (row["IdStudent"] != DBNull.Value)
                {
                    txtIdStudent.Text = row["IdStudent"].ToString();
                    txtStudentName.Text = row["StudentName"]?.ToString() ?? "";
                }
                else
                {
                    txtIdStudent.Text = "";
                    txtStudentName.Text = "";
                }

                txtUsername.Text = row["Username"].ToString();

                // Không hiển thị mật khẩu vì lý do bảo mật
                txtPassword.Password = "";

                // Disable Username khi đã chọn record để cập nhật
                txtUsername.IsEnabled = false;
            }
        }

        private void BtnFindStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdStudent.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm!");
                    return;
                }

                int studentId;
                if (!int.TryParse(txtIdStudent.Text, out studentId))
                {
                    MessageBox.Show("Mã sinh viên phải là số!");
                    return;
                }

                // Kiểm tra sinh viên đã có tài khoản chưa
                conn = new SqlConnection(connStr);
                conn.Open();

                string checkUserQuery = "SELECT COUNT(*) FROM [User] WHERE IdStudent = @IdStudent";
                cmd = new SqlCommand(checkUserQuery, conn);
                cmd.Parameters.AddWithValue("@IdStudent", studentId);
                int userCount = (int)cmd.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Sinh viên này đã có tài khoản!");
                    conn.Close();
                    return;
                }

                // Tìm thông tin sinh viên
                string query = "SELECT * FROM Student WHERE Id = @Id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", studentId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtStudentName.Text = reader["Name"].ToString();

                    // Tạo username mặc định từ mã sinh viên
                    txtUsername.Text = "SV" + txtIdStudent.Text;

                    MessageBox.Show("Đã tìm thấy sinh viên: " + txtStudentName.Text);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với mã " + txtIdStudent.Text);
                    txtStudentName.Text = "";
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra nhập liệu
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();

                // Kiểm tra username đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";
                cmd = new SqlCommand(checkQuery, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    conn.Close();
                    return;
                }

                // Thêm người dùng mới và thêm ModifiedAt = GETDATE()
                string query = string.IsNullOrWhiteSpace(txtIdStudent.Text) ?
                    "INSERT INTO [User] (Username, Password, Status, CreatedAt, ModifiedAt) VALUES (@Username, @Password, 1, GETDATE(), GETDATE())" :
                    "INSERT INTO [User] (Username, Password, IdStudent, Status, CreatedAt, ModifiedAt) VALUES (@Username, @Password, @IdStudent, 1, GETDATE(), GETDATE())";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Password);

                if (!string.IsNullOrWhiteSpace(txtIdStudent.Text))
                {
                    int studentId;
                    if (int.TryParse(txtIdStudent.Text, out studentId))
                    {
                        cmd.Parameters.AddWithValue("@IdStudent", studentId);
                    }
                }

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm người dùng thành công!");
                    LoadUsers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgUsers.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần cập nhật!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();

                // Cấu trúc câu lệnh SQL cập nhật
                string query = "UPDATE [User] SET ModifiedAt = GETDATE()";

                // Kiểm tra nếu nhập mật khẩu mới thì cập nhật mật khẩu
                if (!string.IsNullOrEmpty(txtPassword.Password))
                {
                    query += ", Password = @Password";
                }

                // Cập nhật IdStudent nếu có
                if (!string.IsNullOrEmpty(txtIdStudent.Text))
                {
                    query += ", IdStudent = @IdStudent";
                }

                query += " WHERE Username = @Username";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);

                if (!string.IsNullOrEmpty(txtPassword.Password))
                {
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                }

                if (!string.IsNullOrEmpty(txtIdStudent.Text))
                {
                    int studentId;
                    if (int.TryParse(txtIdStudent.Text, out studentId))
                    {
                        cmd.Parameters.AddWithValue("@IdStudent", studentId);
                    }
                }

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật người dùng thành công!");
                    LoadUsers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật người dùng thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgUsers.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần xóa!");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?",
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();

                    // Kiểm tra người dùng đã có vai trò chưa
                    string checkQuery = "SELECT COUNT(*) FROM UserRole WHERE Username = @Username";
                    cmd = new SqlCommand(checkQuery, conn);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa người dùng này vì đã được phân quyền!");
                        conn.Close();
                        return;
                    }

                    // Tiến hành xóa người dùng
                    string query = "DELETE FROM [User] WHERE Username = @Username";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);

                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa người dùng thành công!");
                        LoadUsers();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng thất bại!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearUser_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtIdStudent.Text = "";
            txtStudentName.Text = "";
            txtUsername.Text = "";
            txtPassword.Password = "";
            txtUsername.IsEnabled = true;
            dgUsers.SelectedItem = null;
        }
    }
}
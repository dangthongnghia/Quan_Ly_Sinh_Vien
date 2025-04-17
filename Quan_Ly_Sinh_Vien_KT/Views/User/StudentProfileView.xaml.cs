using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Quan_Ly_Sinh_Vien_KT.Views.User
{
    public partial class StudentProfileView : UserControl
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string _currentStudentId;
        private string _currentUsername;

        public StudentProfileView(string studentId, string username)
        {
            InitializeComponent();
            _currentStudentId = studentId;
            _currentUsername = username;

            // Tải thông tin sinh viên
            LoadStudentInfo();

            // Load danh sách tỉnh thành
            LoadProvinces();

            // Đăng ký sự kiện cho nút cập nhật
            btnUpdateProfile.Click += BtnUpdateProfile_Click;
        }

        private void LoadStudentInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT s.*, u.Username, u.Password, p.Name as ProvinceName
                                    FROM Student s
                                    INNER JOIN [User] u ON s.Id = u.IdStudent
                                    LEFT JOIN Province p ON s.IdProvince = p.Id
                                    WHERE s.Id = @IdStudent";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdStudent", _currentStudentId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Hiển thị thông tin cơ bản
                        lblFullStudentName.Text = reader["Name"].ToString();
                        lblStudentId.Text = $"Mã SV: {reader["Id"]}";

                        // Điền thông tin vào form
                        txtFullName.Text = reader["Name"].ToString();

                        if (reader["BOF"] != DBNull.Value)
                        {
                            dpBirthday.SelectedDate = Convert.ToDateTime(reader["BOF"]);
                        }

                        txtUsername.Text = reader["Username"].ToString();

                        // Chọn tỉnh/thành trong combobox nếu có
                        if (reader["IdProvince"] != DBNull.Value)
                        {
                            cbProvince.SelectedValue = reader["IdProvince"].ToString();
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadProvinces()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT Id, Name FROM Province";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbProvince.ItemsSource = dt.DefaultView;
                    cbProvince.DisplayMemberPath = "Name";
                    cbProvince.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tỉnh thành: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();

                    // 1. Cập nhật thông tin sinh viên
                    string updateStudentQuery = @"UPDATE Student 
                                                SET Name = @Name, 
                                                    BOF = @BOF,
                                                    IdProvince = @IdProvince
                                                WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(updateStudentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                        if (dpBirthday.SelectedDate.HasValue)
                            cmd.Parameters.AddWithValue("@BOF", dpBirthday.SelectedDate.Value);
                        else
                            cmd.Parameters.AddWithValue("@BOF", DBNull.Value);

                        if (cbProvince.SelectedValue != null)
                            cmd.Parameters.AddWithValue("@IdProvince", cbProvince.SelectedValue);
                        else
                            cmd.Parameters.AddWithValue("@IdProvince", DBNull.Value);

                        cmd.Parameters.AddWithValue("@Id", _currentStudentId);

                        cmd.ExecuteNonQuery();
                    }

                    // 2. Cập nhật mật khẩu nếu người dùng nhập mật khẩu mới
                    if (!string.IsNullOrEmpty(txtNewPassword.Password))
                    {
                        string updatePasswordQuery = @"UPDATE [User] 
                                                    SET Password = @Password,
                                                        ModifiedAt = GETDATE() 
                                                    WHERE Username = @Username";

                        using (SqlCommand cmd = new SqlCommand(updatePasswordQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Password", txtNewPassword.Password);
                            cmd.Parameters.AddWithValue("@Username", _currentUsername);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    // Tải lại thông tin sau khi cập nhật
                    LoadStudentInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thông tin: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
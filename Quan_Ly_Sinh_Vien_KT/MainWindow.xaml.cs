using System;
using System.Collections.Generic;
using System.Windows;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Quan_Ly_Sinh_Vien_KT.Views.Admin;
using Quan_Ly_Sinh_Vien_KT.Views.User;

namespace Quan_Ly_Sinh_Vien_KT;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Password;
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
            return;
        }

        try
        {
            conn.ConnectionString = connStr;
            conn.Open();
            cmd.Connection = conn;

            // Clear any existing parameters before adding new ones
            cmd.Parameters.Clear();

            // Kiểm tra thông tin đăng nhập
            cmd.CommandText = "SELECT * FROM [User] WHERE Username = @username AND Password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                // Lưu thông tin người dùng để sử dụng sau này
                string idStudent = reader["IdStudent"].ToString();
                reader.Close();

                // Kiểm tra vai trò của người dùng - SỬA CHỖ NÀY
                cmd.CommandText = @"SELECT r.Id, r.Name 
              FROM UserRole ur 
              INNER JOIN Role r ON ur.IdRole = r.Id 
              WHERE ur.IdStudent = @idStudent";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idStudent", idStudent);  // Sử dụng IdStudent thay vì username

                List<string> roles = new List<string>();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(reader["Name"].ToString().ToLower());
                }
                reader.Close();

                // Nếu người dùng không có vai trò nào được gán
                if (roles.Count == 0)
                {
                    // Mặc định là vai trò user/student
                    UserDashboardWindow userDashboard = new UserDashboardWindow(username);
                    userDashboard.Show();
                    this.Close();
                }
                else if (roles.Contains("admin"))
                {
                    // Người dùng có vai trò admin
                    AdminMainWindow adminView = new AdminMainWindow();
                    adminView.Show();
                    this.Close();
                }
                else
                {
                    // Người dùng là sinh viên
                    UserDashboardWindow userDashboard = new UserDashboardWindow(username);
                    userDashboard.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ.");
                reader.Close();
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
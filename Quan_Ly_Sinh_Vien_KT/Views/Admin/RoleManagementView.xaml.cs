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
    /// Interaction logic for RoleManagementView.xaml
    /// </summary>
    public partial class RoleManagementView : UserControl
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        
        public RoleManagementView()
        {
            InitializeComponent();
            LoadRoles();
            
            // Thêm sự kiện click cho các nút
            btnAddRole.Click += BtnAddRole_Click;
            btnUpdateRole.Click += BtnUpdateRole_Click;
            btnDeleteRole.Click += BtnDeleteRole_Click;
            btnClearRole.Click += BtnClearRole_Click;
            
            // Thêm sự kiện cho DataGrid
            dgRoles.SelectionChanged += DgRoles_SelectionChanged;
        }

        private void LoadRoles()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "SELECT * FROM Role";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                
                dgRoles.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void DgRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgRoles.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgRoles.SelectedItem;
                txtRoleId.Text = row["Id"].ToString();
                txtRoleName.Text = row["Name"].ToString();
                
                // Disable RoleId khi đã chọn record để cập nhật
                txtRoleId.IsEnabled = false;
            }
        }

        private void BtnAddRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRoleId.Text) || string.IsNullOrEmpty(txtRoleName.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "INSERT INTO Role (Id, Name) VALUES (@Id, @Name)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtRoleId.Text);
                cmd.Parameters.AddWithValue("@Name", txtRoleName.Text);
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm vai trò thành công!");
                    LoadRoles();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm vai trò thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnUpdateRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgRoles.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn vai trò cần cập nhật!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "UPDATE Role SET Name = @Name WHERE Id = @Id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtRoleId.Text);
                cmd.Parameters.AddWithValue("@Name", txtRoleName.Text);
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật vai trò thành công!");
                    LoadRoles();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật vai trò thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnDeleteRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgRoles.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn vai trò cần xóa!");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa vai trò này?", 
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    
                    // Kiểm tra vai trò đã có phân quyền cho người dùng chưa
                    string checkQuery = "SELECT COUNT(*) FROM UserRole WHERE RoleId = @Id";
                    cmd = new SqlCommand(checkQuery, conn);
                    cmd.Parameters.AddWithValue("@Id", txtRoleId.Text);
                    int count = (int)cmd.ExecuteScalar();
                    
                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa vai trò này vì đã được gán cho người dùng!");
                        conn.Close();
                        return;
                    }
                    
                    // Tiến hành xóa vai trò
                    string query = "DELETE FROM Role WHERE Id = @Id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", txtRoleId.Text);
                    
                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa vai trò thành công!");
                        LoadRoles();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa vai trò thất bại!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearRole_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtRoleId.Text = "";
            txtRoleName.Text = "";
            txtRoleId.IsEnabled = true;
            dgRoles.SelectedItem = null;
        }
    }
}
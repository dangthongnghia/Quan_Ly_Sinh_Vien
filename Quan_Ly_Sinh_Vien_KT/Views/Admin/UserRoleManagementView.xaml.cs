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
    /// Interaction logic for UserRoleManagementView.xaml
    /// </summary>
    public partial class UserRoleManagementView : UserControl
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        
        public UserRoleManagementView()
        {
            InitializeComponent();
            LoadUserRoles();
            LoadUsers();
            LoadRoles();
            
            // Thêm sự kiện click cho các nút
            btnAssignRole.Click += BtnAssignRole_Click;
            btnRemoveRole.Click += BtnRemoveRole_Click;
            
            // Thêm sự kiện cho DataGrid
            dgUserRoles.SelectionChanged += DgUserRoles_SelectionChanged;
        }

        private void LoadUserRoles()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = @"SELECT ur.Id, ur.UserId, ur.RoleId, u.Username, r.Name as RoleName 
                               FROM UserRole ur
                               INNER JOIN [User] u ON ur.UserId = u.Username
                               INNER JOIN Role r ON ur.RoleId = r.Id";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                
                dgUserRoles.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        
        private void LoadUsers()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "SELECT * FROM [User] WHERE IsActive = 1";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable dtUsers = new DataTable();
                adapter.Fill(dtUsers);
                
                cbUser.ItemsSource = dtUsers.DefaultView;
                cbUser.DisplayMemberPath = "Username";
                cbUser.SelectedValuePath = "Username";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
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
                DataTable dtRoles = new DataTable();
                adapter.Fill(dtRoles);
                
                cbRole.ItemsSource = dtRoles.DefaultView;
                cbRole.DisplayMemberPath = "Name";
                cbRole.SelectedValuePath = "Id";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void DgUserRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUserRoles.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgUserRoles.SelectedItem;
                cbUser.SelectedValue = row["UserId"].ToString();
                cbRole.SelectedValue = row["RoleId"];
            }
        }

        private void BtnAssignRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbUser.SelectedValue == null || cbRole.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng và vai trò!");
                    return;
                }

                // Kiểm tra xem phân quyền đã tồn tại chưa
                conn = new SqlConnection(connStr);
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM UserRole WHERE UserId = @UserId AND RoleId = @RoleId";
                cmd = new SqlCommand(checkQuery, conn);
                cmd.Parameters.AddWithValue("@UserId", cbUser.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@RoleId", cbRole.SelectedValue);
                int count = (int)cmd.ExecuteScalar();
                
                if (count > 0)
                {
                    MessageBox.Show("Người dùng đã được gán vai trò này!");
                    conn.Close();
                    return;
                }

                // Tiến hành phân quyền cho người dùng
                string query = "INSERT INTO UserRole (UserId, RoleId) VALUES (@UserId, @RoleId)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", cbUser.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@RoleId", cbRole.SelectedValue);
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Gán vai trò cho người dùng thành công!");
                    LoadUserRoles();
                    ClearSelections();
                }
                else
                {
                    MessageBox.Show("Gán vai trò cho người dùng thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnRemoveRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgUserRoles.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn bản ghi cần xóa!");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa vai trò này khỏi người dùng?", 
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    DataRowView row = (DataRowView)dgUserRoles.SelectedItem;
                    int userRoleId = Convert.ToInt32(row["Id"]);
                    
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    string query = "DELETE FROM UserRole WHERE Id = @Id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", userRoleId);
                    
                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa phân quyền thành công!");
                        LoadUserRoles();
                        ClearSelections();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phân quyền thất bại!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ClearSelections()
        {
            cbUser.SelectedIndex = -1;
            cbRole.SelectedIndex = -1;
            dgUserRoles.SelectedItem = null;
        }
    }
}

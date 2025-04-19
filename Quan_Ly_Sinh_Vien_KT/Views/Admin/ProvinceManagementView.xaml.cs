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
using System.Windows.Markup;
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
    /// Interaction logic for ProvinceManagementView.xaml
    /// </summary>
    public partial class ProvinceManagementView : UserControl
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        
        public ProvinceManagementView()
        {
            InitializeComponent();
            LoadProvinces();
            
            // Thêm sự kiện click cho các nút
            btnAddProvince.Click += BtnAddProvince_Click;
            btnUpdateProvince.Click += BtnUpdateProvince_Click; 
            btnDeleteProvince.Click += BtnDeleteProvince_Click;
            btnClearProvince.Click += BtnClearProvince_Click;
            
            // Thêm sự kiện cho DataGrid
            dgProvinces.SelectionChanged += DgProvinces_SelectionChanged;
        }

        private void LoadProvinces()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM Province", conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                
                dgProvinces.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void DgProvinces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProvinces.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgProvinces.SelectedItem;
                txtProvinceId.Text = row["Id"].ToString();
                txtProvinceName.Text = row["Name"].ToString();
                
                // Disable ProvinceId khi đã chọn record để cập nhật
                txtProvinceId.IsEnabled = false;
            }
        }

        private void BtnAddProvince_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProvinceId.Text) || string.IsNullOrEmpty(txtProvinceName.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "INSERT INTO Province (Id, Name) VALUES (@Id, @Name)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtProvinceId.Text);
                cmd.Parameters.AddWithValue("@Name", txtProvinceName.Text);
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm tỉnh/thành phố thành công!");
                    LoadProvinces();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm tỉnh/thành phố thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnUpdateProvince_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProvinces.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn tỉnh/thành phố cần cập nhật!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "UPDATE Province SET Name = @Name WHERE Id = @Id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtProvinceId.Text);
                cmd.Parameters.AddWithValue("@Name", txtProvinceName.Text);
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật tỉnh/thành phố thành công!");
                    LoadProvinces();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật tỉnh/thành phố thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnDeleteProvince_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProvinces.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn tỉnh/thành phố cần xóa!");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tỉnh/thành phố này?", 
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    string query = "DELETE FROM Province WHERE Id = @Id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", txtProvinceId.Text);
                    
                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa tỉnh/thành phố thành công!");
                        LoadProvinces();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tỉnh/thành phố thất bại!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearProvince_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProvinceId.Text = "";
            txtProvinceName.Text = "";
            txtProvinceId.IsEnabled = true;
            dgProvinces.SelectedItem = null;
        }

       
    }
}

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
using System.Windows.Navigation;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Quan_Ly_Sinh_Vien_KT.Models;

namespace Quan_Ly_Sinh_Vien_KT.Views.Admin
{
    /// <summary>
    /// Interaction logic for StudentManagementView.xaml
    /// </summary>
    public partial class StudentManagementView : UserControl
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        
        public StudentManagementView()
        {
            InitializeComponent();
            LoadStudents();
            LoadProvinces();
            
            // Thêm sự kiện click cho các nút
            btnAddStudent.Click += BtnAddStudent_Click;
            btnUpdateStudent.Click += BtnUpdateStudent_Click;
            btnDeleteStudent.Click += BtnDeleteStudent_Click;
            btnClearStudent.Click += BtnClearStudent_Click;
            
            // Thêm sự kiện cho DataGrid
            dgStudents.SelectionChanged += DgStudents_SelectionChanged;
        }

        private void LoadStudents()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = @"SELECT s.Id, s.Name, s.BOF, p.Name as Province, s.IdProvince 
                                FROM Student s 
                                LEFT JOIN Province p ON s.IdProvince = p.Id";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                
                dgStudents.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        
        private void LoadProvinces()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM Province", conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable dtProvinces = new DataTable();
                adapter.Fill(dtProvinces);
                
                cbProvince.ItemsSource = dtProvinces.DefaultView;
                cbProvince.DisplayMemberPath = "Name";
                cbProvince.SelectedValuePath = "Id";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void DgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgStudents.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgStudents.SelectedItem;
                txtStudentId.Text = row["Id"].ToString();
                txtStudentName.Text = row["Name"].ToString();
                
                // Xử lý ngày sinh
                if(row["BOF"] != DBNull.Value)
                {
                    dpBirthday.SelectedDate = Convert.ToDateTime(row["BOF"]);
                }
                
                // Chọn tỉnh/thành phố
                if(row["IdProvince"] != DBNull.Value)
                {
                    cbProvince.SelectedValue = row["IdProvince"];
                }
                
                // Disable StudentId khi đã chọn record để cập nhật
                txtStudentId.IsEnabled = false;
            }
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtStudentId.Text) || string.IsNullOrEmpty(txtStudentName.Text) 
                    || dpBirthday.SelectedDate == null || cbProvince.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "INSERT INTO Student (Id, Name, BOF, IdProvince) VALUES (@Id, @Name, @BOF, @IdProvince)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtStudentId.Text);
                cmd.Parameters.AddWithValue("@Name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@BOF", dpBirthday.SelectedDate);
                cmd.Parameters.AddWithValue("@IdProvince", cbProvince.SelectedValue);
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm sinh viên thành công!");
                    LoadStudents();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgStudents.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần cập nhật!");
                    return;
                }

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "UPDATE Student SET Name = @Name, BOF = @BOF, IdProvince = @IdProvince WHERE Id = @Id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtStudentId.Text);
                cmd.Parameters.AddWithValue("@Name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@BOF", dpBirthday.SelectedDate);
                cmd.Parameters.AddWithValue("@IdProvince", cbProvince.SelectedValue);
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công!");
                    LoadStudents();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật sinh viên thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgStudents.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", 
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    
                    // Kiểm tra sinh viên đã có đăng ký môn học chưa
                    string checkQuery = "SELECT COUNT(*) FROM Enrol WHERE IdStudent = @Id";
                    cmd = new SqlCommand(checkQuery, conn);
                    cmd.Parameters.AddWithValue("@Id", txtStudentId.Text);
                    int count = (int)cmd.ExecuteScalar();
                    
                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa sinh viên này vì đã có đăng ký môn học!");
                        conn.Close();
                        return;
                    }
                    
                    // Tiến hành xóa sinh viên
                    string query = "DELETE FROM Student WHERE Id = @Id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", txtStudentId.Text);
                    
                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa sinh viên thành công!");
                        LoadStudents();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sinh viên thất bại!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearStudent_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtStudentId.Text = "";
            txtStudentName.Text = "";
            dpBirthday.SelectedDate = null;
            cbProvince.SelectedIndex = -1;
            txtStudentId.IsEnabled = true;
            dgStudents.SelectedItem = null;
        }
    }
}
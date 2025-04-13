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
    /// Interaction logic for SubjectManagementView.xaml
    /// </summary>
    public partial class SubjectManagementView : UserControl
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        
        public SubjectManagementView()
        {
            InitializeComponent();
            LoadSubjects();
            
            // Thêm sự kiện click cho các nút
            btnAddSubject.Click += BtnAddSubject_Click;
            btnUpdateSubject.Click += BtnUpdateSubject_Click;
            btnDeleteSubject.Click += BtnDeleteSubject_Click;
            btnClearSubject.Click += BtnClearSubject_Click;
            
            // Thêm sự kiện cho DataGrid
            dgSubjects.SelectionChanged += DgSubjects_SelectionChanged;
        }

        private void LoadSubjects()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "SELECT * FROM Subject";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                
                dgSubjects.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void DgSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSubjects.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgSubjects.SelectedItem;
                txtSubjectId.Text = row["Id"].ToString();
                txtSubjectName.Text = row["Name"].ToString();
                
                
                // Disable SubjectId khi đã chọn record để cập nhật
                txtSubjectId.IsEnabled = false;
            }
        }

        private void BtnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSubjectId.Text) || string.IsNullOrEmpty(txtSubjectName.Text) 
                    )
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                // Kiểm tra số tín chỉ có phải là số hay không
                

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "INSERT INTO Subject (Id, Name) VALUES (@Id, @Name)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtSubjectId.Text);
                cmd.Parameters.AddWithValue("@Name", txtSubjectName.Text);
               
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm môn học thành công!");
                    LoadSubjects();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm môn học thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnUpdateSubject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSubjects.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học cần cập nhật!");
                    return;
                }

                // Kiểm tra số tín chỉ có phải là số hay không
              

                conn = new SqlConnection(connStr);
                conn.Open();
                string query = "UPDATE Subject SET Name = @Name  WHERE Id = @Id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", txtSubjectId.Text);
                cmd.Parameters.AddWithValue("@Name", txtSubjectName.Text);
               
                
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật môn học thành công!");
                    LoadSubjects();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật môn học thất bại!");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnDeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSubjects.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học cần xóa!");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", 
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    
                    // Kiểm tra môn học đã có đăng ký chưa
                    string checkQuery = "SELECT COUNT(*) FROM Enrol WHERE IdSubject = @Id";
                    cmd = new SqlCommand(checkQuery, conn);
                    cmd.Parameters.AddWithValue("@Id", txtSubjectId.Text);
                    int count = (int)cmd.ExecuteScalar();
                    
                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa môn học này vì đã có sinh viên đăng ký!");
                        conn.Close();
                        return;
                    }
                    
                    // Tiến hành xóa môn học
                    string query = "DELETE FROM Subject WHERE Id = @Id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", txtSubjectId.Text);
                    
                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa môn học thành công!");
                        LoadSubjects();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa môn học thất bại!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnClearSubject_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtSubjectId.Text = "";
            txtSubjectName.Text = "";
            
            txtSubjectId.IsEnabled = true;
            dgSubjects.SelectedItem = null;
        }
    }
}

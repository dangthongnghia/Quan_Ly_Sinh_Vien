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

namespace Quan_Ly_Sinh_Vien_KT.Views.Admin
{
    /// <summary>
    /// Interaction logic for StudentRegistrationView.xaml
    /// </summary>
    public partial class StudentRegistrationView : UserControl
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        
        public StudentRegistrationView()
        {
            InitializeComponent();
            LoadRegistrations();
        }
        
        private void LoadRegistrations()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = @"SELECT e.Id, s.Id as StudentId, s.Name as StudentName, 
                               subj.Id as SubjectId, subj.Name as SubjectName, 
                               e.RegisterDate, subj.Credits
                               FROM Enrol e
                               INNER JOIN Student s ON e.IdStudent = s.Id
                               INNER JOIN Subject subj ON e.IdSubject = subj.Id";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
                
                dgRegistrations.ItemsSource = dt.DefaultView;
                conn.Close();
                
                // Thêm sự kiện cho DataGrid nếu cần
                dgRegistrations.SelectionChanged += DgRegistrations_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        
        private void DgRegistrations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý khi chọn một đăng ký trong DataGrid
            // Nếu cần hiển thị chi tiết hoặc cho phép chỉnh sửa, có thể thêm code ở đây
        }
        
        // Hiển thị chi tiết đăng ký khi được chọn (có thể thêm các button và chức năng nếu cần)
        public void ShowRegistrationDetails(int registrationId)
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = @"SELECT e.Id, s.Id as StudentId, s.Name as StudentName, 
                                subj.Id as SubjectId, subj.Name as SubjectName, 
                                e.RegisterDate, subj.Credits
                                FROM Enrol e
                                INNER JOIN Student s ON e.IdStudent = s.Id
                                INNER JOIN Subject subj ON e.IdSubject = subj.Id
                                WHERE e.Id = @Id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", registrationId);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Hiển thị chi tiết đăng ký (có thể mở dialog hoặc hiển thị trong form)
                    string details = $"Mã đăng ký: {reader["Id"]}\n" +
                                    $"Sinh viên: {reader["StudentName"]} (Mã: {reader["StudentId"]})\n" +
                                    $"Môn học: {reader["SubjectName"]} (Mã: {reader["SubjectId"]})\n" +
                                    $"Ngày đăng ký: {Convert.ToDateTime(reader["RegisterDate"]).ToString("dd/MM/yyyy")}\n" +
                                    $"Số tín chỉ: {reader["Credits"]}";
                    
                    MessageBox.Show(details, "Chi tiết đăng ký", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        
        // Thống kê số lượng sinh viên đăng ký theo môn học
        public void ShowSubjectStatistics()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = @"SELECT subj.Id as SubjectId, subj.Name as SubjectName, 
                               COUNT(e.Id) as StudentCount
                               FROM Subject subj
                               LEFT JOIN Enrol e ON subj.Id = e.IdSubject
                               GROUP BY subj.Id, subj.Name
                               ORDER BY StudentCount DESC";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable statTable = new DataTable();
                adapter.Fill(statTable);
                
                // Hiển thị kết quả thống kê (có thể trong một dialog hoặc report khác)
                string statistics = "THỐNG KÊ SINH VIÊN ĐĂNG KÝ THEO MÔN HỌC\n\n";
                foreach (DataRow row in statTable.Rows)
                {
                    statistics += $"Môn học: {row["SubjectName"]} (Mã: {row["SubjectId"]})\n";
                    statistics += $"Số sinh viên đăng ký: {row["StudentCount"]}\n\n";
                }
                
                // Nếu có UI cho thống kê, có thể hiển thị ở đây
                MessageBox.Show(statistics, "Thống kê đăng ký", MessageBoxButton.OK, MessageBoxImage.Information);
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        
        // Có thể thêm các phương thức sau nếu cần thiết:
        // - Xóa đăng ký
        // - Xuất danh sách đăng ký ra Excel/PDF
        // - Lọc theo sinh viên/môn học
        // - v.v.
    }
}

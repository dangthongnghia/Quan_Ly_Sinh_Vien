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
                string query = @"SELECT 
                        e.IdStudent, s.Name as StudentName, 
                        e.IdSubject, subj.Name as SubjectName,
                        e.Mark
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

        // Hiển thị chi tiết đăng ký khi được chọn
        public void ShowRegistrationDetails(string studentId, string subjectId)
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string query = @"SELECT 
                                e.IdStudent, s.Name as StudentName, 
                                e.IdSubject, subj.Name as SubjectName,
                                e.Mark, subj.Credits
                                FROM Enrol e
                                INNER JOIN Student s ON e.IdStudent = s.Id
                                INNER JOIN Subject subj ON e.IdSubject = subj.Id
                                WHERE e.IdStudent = @IdStudent AND e.IdSubject = @IdSubject";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdStudent", studentId);
                cmd.Parameters.AddWithValue("@IdSubject", subjectId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Hiển thị chi tiết đăng ký
                    string details = $"Sinh viên: {reader["StudentName"]} (Mã: {reader["IdStudent"]})\n" +
                                    $"Môn học: {reader["SubjectName"]} (Mã: {reader["IdSubject"]})\n" +
                                    $"Điểm số: {reader["Mark"]}\n" +
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
                string query = @"SELECT 
                                subj.Id as IdSubject, 
                                subj.Name as SubjectName, 
                                COUNT(e.IdStudent) as StudentCount
                                FROM Subject subj
                                LEFT JOIN Enrol e ON subj.Id = e.IdSubject
                                GROUP BY subj.Id, subj.Name
                                ORDER BY StudentCount DESC";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable statTable = new DataTable();
                adapter.Fill(statTable);

                // Hiển thị kết quả thống kê
                string statistics = "THỐNG KÊ SINH VIÊN ĐĂNG KÝ THEO MÔN HỌC\n\n";
                foreach (DataRow row in statTable.Rows)
                {
                    statistics += $"Môn học: {row["SubjectName"]} (Mã: {row["SubjectId"]})\n";
                    statistics += $"Số sinh viên đăng ký: {row["StudentCount"]}\n\n";
                }

                // Hiển thị thông tin thống kê
                MessageBox.Show(statistics, "Thống kê đăng ký", MessageBoxButton.OK, MessageBoxImage.Information);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
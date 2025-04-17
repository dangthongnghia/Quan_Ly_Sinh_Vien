using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Data;

namespace Quan_Ly_Sinh_Vien_KT.Views.User
{
    public partial class MySubjectsView : UserControl
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string _currentStudentId;

        public MySubjectsView(string studentId)
        {
            InitializeComponent();
            _currentStudentId = studentId;

            // Thêm cột nút hủy đăng ký
            AddCancelButtonColumn();

            // Tải danh sách môn học đã đăng ký
            LoadRegisteredSubjects();

            // Đăng ký sự kiện cho nút xuất danh sách
            btnExportList.Click += BtnExportList_Click;
        }

        // Thêm cột nút hủy vào DataGrid
        private void AddCancelButtonColumn()
        {
            // Template cho nút hủy
            FrameworkElementFactory btnFactory = new FrameworkElementFactory(typeof(Button));
            btnFactory.SetValue(Button.ContentProperty, "Hủy");
            btnFactory.SetValue(Button.TagProperty, new Binding("Id"));
            btnFactory.SetValue(Button.BackgroundProperty, new System.Windows.Media.SolidColorBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F44336")));
            btnFactory.SetValue(Button.ForegroundProperty, new System.Windows.Media.SolidColorBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF")));
            btnFactory.SetValue(Button.MarginProperty, new Thickness(2));
            btnFactory.SetValue(Button.PaddingProperty, new Thickness(5, 3, 5, 3));
            btnFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Cancel_Click));

            DataTemplate btnTemplate = new DataTemplate();
            btnTemplate.VisualTree = btnFactory;

            // Tạo và cấu hình cột nút hủy
            DataGridTemplateColumn btnColumn = new DataGridTemplateColumn();
            btnColumn.Header = "Hủy";
            btnColumn.CellTemplate = btnTemplate;
            btnColumn.Width = 80;

            // Thêm cột vào DataGrid
            dgRegisteredSubjects.Columns.Add(btnColumn);
        }

        private void LoadRegisteredSubjects()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();

                    // Lấy danh sách môn học đã đăng ký
                    string query = @"SELECT s.Id, s.Name, e.Mark, GETDATE() as RegistrationDate
                                    FROM Enrol e
                                    INNER JOIN Subject s ON e.IdSubject = s.Id
                                    WHERE e.IdStudent = @IdStudent";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdStudent", _currentStudentId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Đếm tổng số môn học và tổng số tín chỉ
                    lblTotalSubjects.Text = dt.Rows.Count.ToString();
                    lblTotalCredits.Text = (dt.Rows.Count * 3).ToString(); // Giả sử mỗi môn có 3 tín chỉ

                    // Gán dữ liệu cho DataGrid
                    dgRegisteredSubjects.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách môn học đã đăng ký: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn == null) return;

                string subjectId = btn.Tag.ToString();
                if (string.IsNullOrEmpty(subjectId)) return;

                // Xác nhận hủy đăng ký
                MessageBoxResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy đăng ký môn học này không?",
                    "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(_connStr))
                    {
                        conn.Open();

                        // Xóa đăng ký
                        string cancelQuery = @"DELETE FROM Enrol 
                                            WHERE IdStudent = @IdStudent AND IdSubject = @IdSubject";

                        SqlCommand cancelCmd = new SqlCommand(cancelQuery, conn);
                        cancelCmd.Parameters.AddWithValue("@IdStudent", _currentStudentId);
                        cancelCmd.Parameters.AddWithValue("@IdSubject", subjectId);

                        int deleteResult = cancelCmd.ExecuteNonQuery();

                        if (deleteResult > 0)
                        {
                            MessageBox.Show("Hủy đăng ký môn học thành công!",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                            // Tải lại danh sách môn học sau khi hủy
                            LoadRegisteredSubjects();
                        }
                        else
                        {
                            MessageBox.Show("Hủy đăng ký môn học thất bại!",
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy đăng ký môn học: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnExportList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Triển khai chức năng xuất danh sách (có thể xuất ra Excel, PDF, v.v.)
                MessageBox.Show("Chức năng xuất danh sách môn học đang được phát triển!",
                    "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất danh sách: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
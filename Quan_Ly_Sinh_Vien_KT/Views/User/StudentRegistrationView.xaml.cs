using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Data;

namespace Quan_Ly_Sinh_Vien_KT.Views.User
{
    public partial class StudentRegistrationView : UserControl
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string _currentStudentId;

        public StudentRegistrationView(string studentId)
        {
            InitializeComponent();
            _currentStudentId = studentId;

            // Check if user has permission to register subjects
            if (!HasRegistrationPermission())
            {
                MessageBox.Show("Bạn không có quyền đăng ký môn học!", 
                    "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tải danh sách môn học có thể đăng ký
            LoadAvailableSubjects();
        }

        private bool HasRegistrationPermission()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) 
                                   FROM UserRole ur 
                                   INNER JOIN Role r ON ur.IdRole = r.Id
                                   WHERE ur.IdStudent = @IdStudent AND r.Name = 'user'";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdStudent", _currentStudentId);
                    
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra quyền: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void LoadAvailableSubjects()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();

                    // Lấy danh sách môn học chưa đăng ký
                    string query = @"SELECT s.Id, s.Name
                                    FROM Subject s
                                    WHERE s.Id NOT IN (
                                        SELECT e.IdSubject 
                                        FROM Enrol e 
                                        WHERE e.IdStudent = @IdStudent
                                    )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdStudent", _currentStudentId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Xóa các cột hiện có trong DataGrid
                    dgAvailableSubjects.Columns.Clear();

                    // Thêm cột ID
                    DataGridTextColumn idColumn = new DataGridTextColumn();
                    idColumn.Header = "Mã môn";
                    idColumn.Binding = new Binding("Id");
                    idColumn.Width = 100;
                    dgAvailableSubjects.Columns.Add(idColumn);

                    // Thêm cột tên môn học
                    DataGridTextColumn nameColumn = new DataGridTextColumn();
                    nameColumn.Header = "Tên môn học";
                    nameColumn.Binding = new Binding("Name");
                    nameColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    dgAvailableSubjects.Columns.Add(nameColumn);

                    // Thêm cột nút đăng ký
                    DataGridTemplateColumn btnColumn = new DataGridTemplateColumn();
                    btnColumn.Header = "Đăng ký";
                    btnColumn.Width = 100;

                    // Template cho nút đăng ký
                    FrameworkElementFactory btnFactory = new FrameworkElementFactory(typeof(Button));
                    btnFactory.SetValue(Button.ContentProperty, "Đăng ký");
                    btnFactory.SetValue(Button.TagProperty, new Binding("Id"));
                    btnFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Register_Click));

                    DataTemplate btnTemplate = new DataTemplate();
                    btnTemplate.VisualTree = btnFactory;
                    btnColumn.CellTemplate = btnTemplate;

                    dgAvailableSubjects.Columns.Add(btnColumn);

                    // Gán dữ liệu cho DataGrid
                    dgAvailableSubjects.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách môn học: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                string subjectId = btn.Tag.ToString();

                // Kiểm tra môn học đã đăng ký chưa
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();

                    string checkQuery = @"SELECT COUNT(*) 
                                        FROM Enrol 
                                        WHERE IdStudent = @IdStudent AND IdSubject = @IdSubject";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@IdStudent", _currentStudentId);
                    checkCmd.Parameters.AddWithValue("@IdSubject", subjectId);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bạn đã đăng ký môn học này rồi!",
                            "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    // Thực hiện đăng ký
                    string registerQuery = @"INSERT INTO Enrol (IdStudent, IdSubject, Mark) 
                                          VALUES (@IdStudent, @IdSubject, '0')";

                    SqlCommand registerCmd = new SqlCommand(registerQuery, conn);
                    registerCmd.Parameters.AddWithValue("@IdStudent", _currentStudentId);
                    registerCmd.Parameters.AddWithValue("@IdSubject", subjectId);

                    int result = registerCmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Đăng ký môn học thành công!",
                            "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Tải lại danh sách môn học sau khi đăng ký
                        LoadAvailableSubjects();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký môn học thất bại!",
                            "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng ký môn học: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
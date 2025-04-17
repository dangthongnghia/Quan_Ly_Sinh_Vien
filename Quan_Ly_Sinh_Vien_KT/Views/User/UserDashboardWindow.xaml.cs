using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Quan_Ly_Sinh_Vien_KT.Views.User
{
    /// <summary>
    /// Interaction logic for UserDashboardWindow.xaml
    /// </summary>
    public partial class UserDashboardWindow : Window
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string _currentUsername;
        private string _currentStudentId;
        private DispatcherTimer _timer;
        private Button _activeButton;

        public UserDashboardWindow(string username)
        {
            InitializeComponent();
            _currentUsername = username;

            // Lấy thông tin sinh viên từ tên đăng nhập
            GetStudentInfo();

            // Khởi tạo timer để cập nhật thời gian
            InitializeTimer();

            // Đặt nút Profile là nút kích hoạt mặc định
            SetActiveButton(btnProfile);
            btnProfile_Click(null, null);

            // Đăng ký sự kiện khi cửa sổ đóng để dừng timer
            this.Closed += (s, e) => _timer.Stop();
        }

        private void InitializeTimer()
        {
            // Cập nhật ngày giờ hiện tại
            UpdateDateTime();

            // Tạo timer để cập nhật thời gian mỗi giây
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => UpdateDateTime();
            _timer.Start();
        }

        private void UpdateDateTime()
        {
            txtCurrentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void GetStudentInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT s.Id, s.Name
                                    FROM Student s
                                    INNER JOIN [User] u ON s.Id = u.IdStudent
                                    WHERE u.Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", _currentUsername);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _currentStudentId = reader["Id"].ToString();
                                lblStudentName.Text = reader["Name"].ToString();
                                lblStudentId.Text = $"Mã SV: {_currentStudentId}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin sinh viên: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetActiveButton(Button button)
        {
            // Đặt lại style cho nút đã kích hoạt trước đó (nếu có)
            if (_activeButton != null)
            {
                _activeButton.Style = FindResource("NavButtonStyle") as Style;
            }

            // Đặt style mới cho nút được kích hoạt
            button.Style = FindResource("NavButtonActiveStyle") as Style;
            _activeButton = button;

            // Cập nhật tiêu đề trang
            string buttonText = "";
            if (button == btnProfile) buttonText = "Thông tin cá nhân";
            else if (button == btnRegisterSubjects) buttonText = "Đăng ký môn học";
            else if (button == btnMySubjects) buttonText = "Môn học đã đăng ký";
            else if (button == btnSchedule) buttonText = "Lịch học";
            else if (button == btnGrades) buttonText = "Điểm số";

            txtPageTitle.Text = buttonText;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnProfile);
            contentControl.Content = new StudentProfileView(_currentStudentId, _currentUsername);
        }

        private void btnRegisterSubjects_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnRegisterSubjects);
            contentControl.Content = new StudentRegistrationView(_currentStudentId);
        }

        private void btnMySubjects_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnMySubjects);
            contentControl.Content = new MySubjectsView(_currentStudentId);
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnSchedule);
            // Tạm thời hiển thị thông báo cho chức năng đang phát triển
            contentControl.Content = new DevelopingFeatureView("Lịch học");
        }

        private void btnGrades_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnGrades);
            // Tạm thời hiển thị thông báo cho chức năng đang phát triển
            contentControl.Content = new DevelopingFeatureView("Điểm số");
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            // Trở về màn hình đăng nhập
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }

    // View hiển thị cho các tính năng đang phát triển
    public class DevelopingFeatureView : UserControl
    {
        public DevelopingFeatureView(string featureName)
        {
            Border border = new Border
            {
                Background = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F0F8FF")),
                BorderBrush = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#B0E0E6")),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(20)
            };

            StackPanel stackPanel = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock iconBlock = new TextBlock
            {
                Text = "🛠️",
                FontSize = 48,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 20)
            };

            TextBlock titleBlock = new TextBlock
            {
                Text = $"Chức năng {featureName} đang được phát triển",
                FontSize = 18,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 10)
            };

            TextBlock messageBlock = new TextBlock
            {
                Text = "Chức năng này sẽ sớm được hoàn thiện trong các phiên bản tới.",
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                Foreground = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#555555"))
            };

            stackPanel.Children.Add(iconBlock);
            stackPanel.Children.Add(titleBlock);
            stackPanel.Children.Add(messageBlock);

            border.Child = stackPanel;
            this.Content = border;
        }
    }
}
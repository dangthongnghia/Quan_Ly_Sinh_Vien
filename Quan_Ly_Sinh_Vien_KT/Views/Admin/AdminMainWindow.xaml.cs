using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Quan_Ly_Sinh_Vien_KT.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private Button _activeButton;
        private DispatcherTimer _timer;

        public AdminMainWindow()
        {
            InitializeComponent();

            // Khởi tạo timer để cập nhật thời gian
            InitializeTimer();

            // Hiển thị StudentManagementView mặc định khi khởi động
            SetActiveButton(btnStudents);
            btnStudents_Click(null, null);

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

        private void SetActiveButton(Button button)
        {
            // Đặt lại style cho nút đã kích hoạt trước đó (nếu có)
            if (_activeButton != null)
            {
                _activeButton.Style = FindResource("MenuButtonStyle") as Style;
            }

            // Đặt style mới cho nút được kích hoạt
            button.Style = FindResource("MenuButtonActiveStyle") as Style;
            _activeButton = button;

            // Cập nhật tiêu đề trang
            string buttonText = "";
            if (button == btnStudents) buttonText = "Quản lý sinh viên";
            else if (button == btnUsers) buttonText = "Quản lý người dùng";
            else if (button == btnRoles) buttonText = "Quản lý vai trò";
            else if (button == btnUserRoles) buttonText = "Phân quyền người dùng";
            else if (button == btnSubjects) buttonText = "Quản lý môn học";
            else if (button == btnProvinces) buttonText = "Quản lý tỉnh thành";
            else if (button == btnRegistrations) buttonText = "Đăng ký môn học";

            txtPageTitle.Text = buttonText;
        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null) SetActiveButton(btnStudents);
            MainContent.Content = new StudentManagementView();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnUsers);
            MainContent.Content = new UserManagementView();
        }

        private void btnRoles_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnRoles);
            MainContent.Content = new RoleManagementView();
        }

        private void btnUserRoles_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnUserRoles);
            MainContent.Content = new UserRoleManagementView();
        }

        private void btnSubjects_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnSubjects);
            MainContent.Content = new SubjectManagementView();
        }

        private void btnProvinces_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnProvinces);
            MainContent.Content = new ProvinceManagementView();
        }

        private void btnRegistrations_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(btnRegistrations);
            MainContent.Content = new StudentRegistrationView();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận đăng xuất
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Mở cửa sổ đăng nhập
                MainWindow loginWindow = new MainWindow();
                loginWindow.Show();

                // Đóng cửa sổ hiện tại
                this.Close();
            }
        }
    }
}
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

namespace Quan_Ly_Sinh_Vien_KT.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
            
            // Hiển thị StudentManagementView mặc định khi khởi động
            MainContent.Content = new StudentManagementView();
        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StudentManagementView();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UserManagementView();
        }

        private void btnRoles_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RoleManagementView();
        }

        private void btnUserRoles_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UserRoleManagementView();
        }

        private void btnSubjects_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SubjectManagementView();
        }

        private void btnProvinces_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProvinceManagementView();
        }
        
        private void btnRegistrations_Click(object sender, RoutedEventArgs e)
        {
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

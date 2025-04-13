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

namespace Quan_Ly_Sinh_Vien_KT.Views.User
{
    /// <summary>
    /// Interaction logic for UserDashboardWindow.xaml
    /// </summary>
    public partial class UserDashboardWindow : Window
    {
        public UserDashboardWindow()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new StudentProfileView();
        }

        private void btnRegisterSubjects_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new StudentRegistrationView();
        }

        private void btnMySubjects_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MySubjectsView();
        }
    }
}

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Quan_Ly_Sinh_Vien_KT.Views.Admin;
namespace Quan_Ly_Sinh_Vien_KT;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Password;
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Please enter username and password.");
            return;
        }

        try
        {
            conn.ConnectionString = connStr;
            conn.Open();
            cmd.Connection = conn;

            // Clear any existing parameters before adding new ones
            cmd.Parameters.Clear();

            cmd.CommandText = "SELECT * FROM [User] WHERE Username = @username AND Password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string role = reader.GetString(0); // Assuming role is at position 2

                switch (role.ToLower())
                {
                    case "Admin":
                        AdminMainWindow adminView = new AdminMainWindow();
                        adminView.Show();
                        this.Close();
                        break;

                    case "user":
                    case "student":
                        // Redirect to the user dashboard
                        Views.User.UserDashboardWindow userDashboard = new Views.User.UserDashboardWindow();
                        userDashboard.Show();
                        this.Close();
                        break;

                    default:
                        MessageBox.Show($"Role '{role}' does not have permission to access this application.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
            reader.Close();
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {

    }
}
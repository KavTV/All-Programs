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
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using BCrypt;

namespace WPF_Database
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "server=ftp.elkok.dk;user id=elkokdk;password=Sec4Ever;database=elkokdk_kaphlap";

            MySqlConnection sqlCon = new MySqlConnection(connStr);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM users WHERE username=@Username AND password=@Password";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);

                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    
                    if (count == 1)
                    {
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Brugernavn eller adgangskode forkert.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}

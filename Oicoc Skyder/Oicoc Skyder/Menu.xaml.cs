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


namespace Oicoc_Skyder
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            this.Top = 180;
            this.Left = 600;
        }
      
        
            private void NemtButton_Click(object sender, RoutedEventArgs e)
            {
            
                MainWindow db = new MainWindow(1);
                db.Show();
                this.Close();
            
            }
       
        
        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow db = new MainWindow(2);
            db.Show();
            this.Close();
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow db = new MainWindow(3);
            db.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help db = new Help();
            db.Show();
            this.Close();
        }
    }
}

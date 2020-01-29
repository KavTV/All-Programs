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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            List<int> Resultatet = new List<int>();



        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int Host1Nummer = int.Parse(AddBox.Text);
            //List<int> Resultatet = new List<int>();

            Resultatet.Add(Host1Nummer);
            Resultatet.Sort();
        }

        public void OpdateringsKnap_Click(object sender, RoutedEventArgs e)
        {
            List.Clear();
            foreach (var item in Resultatet)
            {

                List.Text += item + "\n";

            }

        }

        private void AddBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

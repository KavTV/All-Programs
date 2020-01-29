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
using System.Text.RegularExpressions;
using System.Threading;

namespace Subnetteren_over_alle_subnettere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            string newLine = Environment.NewLine;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        




        public static byte[] classes = { 0, 127, 128, 191, 192, 223, 224, 239, 240, 255 };
            public static char[] ClassLabel = {'A','B','C','D','E'};
            public static int[] Subnets = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216 };

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

     

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            
        }
        public string klasse()
        {
            string result = "Null";
            int number = int.Parse(IP1.Text);
            for (int i = 0; i < 10; i += 2)
            {
                if (number >= classes[i] && number <= classes[i + 1])
                {
                    result = $"{ ClassLabel[i / 2]}";
                    
                }

            }
            return result;
        }
        
       public void RegnUdKnap_Click(object sender, RoutedEventArgs e)
        {
            Resultater.Clear();
            Resultatet.Sort();


            foreach (var item in Resultatet)
            {

                Resultater.Text += item + "\n \n";

            }


        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Resultater_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
        }

            List<string> Resultatet = new List<string>();
        public void AddList_Click(object sender, RoutedEventArgs e)
        {

            string IPAdresse = $"{IP1.Text}.{IP2.Text}.{IP3.Text}.{IP4.Text}";
            
            int Host1Nummer = int.Parse(Host1.Text);
            //int Host2Nummer = int.Parse(Host2.Text);
            //int Host3Nummer = int.Parse(Host3.Text);


            if (Host1Nummer <= Subnets[1] && Host1Nummer >= Subnets[0])
            {
                Resultatet.Add($"{IPAdresse} {newLine} 255.255.255.{256 - Subnets[1]}");

            }

            else if (Host1Nummer <= Subnets[2] && Host1Nummer > Subnets[1])
            {
                Resultatet.Add($"{IPAdresse} {newLine} 255.255.255.{256 - Subnets[2]}");

            }
            else if (Host1Nummer <= Subnets[3] && Host1Nummer > Subnets[2])
            {
                Resultatet.Add($"{IPAdresse} {newLine} 255.255.255.{256 - Subnets[3]}");

            }
            else if (Host1Nummer <= Subnets[4] && Host1Nummer > Subnets[3])
            {
                Resultatet.Add($"{IPAdresse} {newLine} 255.255.255.{256 - Subnets[4]}");

            }
            else if (Host1Nummer <= Subnets[5] && Host1Nummer > Subnets[4])
            {
                Resultatet.Add($"{IPAdresse} {newLine} 255.255.255.{256 - Subnets[5]}");

            }
            else if (Host1Nummer <= Subnets[6] && Host1Nummer > Subnets[5])
            {
                Resultatet.Add($"{IPAdresse} {newLine} 255.255.255.{256 - Subnets[6]}");

            }
            else if (Host1Nummer <= Subnets[7] && Host1Nummer > Subnets[6])
            {
                Resultatet.Add($"{IPAdresse} {newLine} 255.255.255.{256 - Subnets[7]}");

            }
            else if (Host1Nummer <= Subnets[8] && Host1Nummer > Subnets[7])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[8] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[9] && Host1Nummer > Subnets[8])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[9] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[10] && Host1Nummer > Subnets[9])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[10] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[11] && Host1Nummer > Subnets[10])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[11] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[12] && Host1Nummer > Subnets[11])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[12] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }

            else if (Host1Nummer <= Subnets[13] && Host1Nummer > Subnets[12])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[13] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[14] && Host1Nummer > Subnets[13])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[14] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[15] && Host1Nummer > Subnets[14])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[15] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[15] && Host1Nummer > Subnets[14])
            {
                if (Host1Nummer > 256)
                {
                    int HostB = (Subnets[15] / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.255.{256 - HostB}.0");
                }

            }
            else if (Host1Nummer <= Subnets[16] && Host1Nummer > Subnets[15])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[16] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }
            else if (Host1Nummer <= Subnets[17] && Host1Nummer > Subnets[16])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[17] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }
            else if (Host1Nummer <= Subnets[18] && Host1Nummer > Subnets[17])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[18] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }
            else if (Host1Nummer <= Subnets[19] && Host1Nummer > Subnets[18])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[19] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }
            else if (Host1Nummer <= Subnets[20] && Host1Nummer > Subnets[19])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[20] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }
            else if (Host1Nummer <= Subnets[21] && Host1Nummer > Subnets[20])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[21] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }
            else if (Host1Nummer <= Subnets[22] && Host1Nummer > Subnets[21])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[22] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }
            else if (Host1Nummer <= Subnets[23] && Host1Nummer > Subnets[22])
            {
                if (Host1Nummer > 65536)
                {
                    int HostB = (Subnets[23] / 256 / 256);

                    Resultatet.Add($"{IPAdresse} {newLine} 255.{256 - HostB}.0.0");
                }

            }


            else
            {
                Resultater.Text = "??\n";
            }
            Host1.Clear();
        }

        private void Host1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddList_Click(sender, e);
                
            }
        }

        private void IP1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IP2.Focus();
            }
        }

        private void IP2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IP3.Focus();
            }
        }

        private void IP3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IP4.Focus();
            }
        }

        private void IP4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Host1.Focus();
            }
        }
    }
}

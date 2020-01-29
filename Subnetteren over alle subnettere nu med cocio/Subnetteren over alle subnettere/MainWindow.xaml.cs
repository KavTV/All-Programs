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
using System.IO;
using System.Windows.Media.Animation;

namespace Subnetteren_over_alle_subnettere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ErDetCocioCola;
        
            string newLine = Environment.NewLine;
        public MainWindow()
        {
            InitializeComponent();
            Drik.IsEnabled = false;
            LoadTxt();
            OpdaterCounter();
        }
        string TxtPath = @"C:\Users\kasp609g\source\repos\Subnetteren over alle subnettere nu med cocio\Subnetteren over alle subnettere\Drukket";
        string CDark = @"C:\Users\kasp609g\source\repos\Subnetteren over alle subnettere nu med cocio\Subnetteren over alle subnettere\CDark";
        string CNormal = @"C:\Users\kasp609g\source\repos\Subnetteren over alle subnettere nu med cocio\Subnetteren over alle subnettere\CNormal";
        string CCola = @"C:\Users\kasp609g\source\repos\Subnetteren over alle subnettere nu med cocio\Subnetteren over alle subnettere\CCola";
        int CocioNummer;
        int CocioNormal;
        int CocioDark;
        int CocioCola;
        

        private void LoadTxt()
        {
            Int32.TryParse(File.ReadAllText(TxtPath), out CocioNummer);
            Int32.TryParse(File.ReadAllText(CNormal), out CocioNormal);
            Int32.TryParse(File.ReadAllText(CDark), out CocioDark);
            Int32.TryParse(File.ReadAllText(CCola), out CocioCola);
        }

        private void OpdaterCounter()
        {
            CocioCounter.Content = $"Cocio drukket: {CocioNummer}" + $"\nAntal liter: " + CocioNummer * 0.400 + $"\nNormal Cocio: {CocioNormal}" + $"\nCocioDark: {CocioDark}" + $"\nCocioCola: {CocioCola}";
        }

        public void MinStartKnap_Click(object sender, RoutedEventArgs e)
        {
            Resultater.Clear();
            Resultatet.Sort();


            foreach (var item in Resultatet)
            {

                Resultater.Text += item + "\n \n";

            }
            fyldop1();
            

        }

        private void Drik_Click(object sender, RoutedEventArgs e)
        {
            RoterCanvas();
            Resultater.Clear();

        }
        //Her bliver Canvas roteret hvor alle rektangler ligger i canvas. 
        //Når animationen er færdig, henviser den til en anden metode med en anden animation.
        private void RoterCanvas()
        {
            KaspersKnap.IsEnabled = false;
            Drik.IsEnabled = false;
            MinStartKnap.IsEnabled = false;
            CocioColaKnap.IsEnabled = false;
            DoubleAnimation da = new DoubleAnimation();
            da.From = 360;
            da.To = 250;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            RotateTransform rt = new RotateTransform();
            DobbeltDrej.RenderTransform = rt;
            da.Completed += new EventHandler(RoterFærdig);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);

        }

        //Her ændrer den højden på rektanglet.
        private void RoterFærdig(object sender, EventArgs e)
        {
            double Height = fyldet2.Height = 320;
            DoubleAnimation animation = new DoubleAnimation(273, Height, TimeSpan.FromSeconds(0.5));
            animation.Completed += new EventHandler(RoterFærdig2);
            fyldet2.BeginAnimation(Rectangle.HeightProperty, animation);

        }

        private void RoterFærdig2(object sender, EventArgs e)
        {

            double Heightt = FyldHæld.Height = 179;
            DoubleAnimation animation = new DoubleAnimation(10, Heightt, TimeSpan.FromSeconds(0.8));
            animation.Completed += new EventHandler(RoterFærdig3);
            FyldHæld.BeginAnimation(Rectangle.HeightProperty, animation);

        }

        private void RoterFærdig3(object sender, EventArgs e)
        {
            double Height = fyldet2.Height = 0;
            DoubleAnimation animation = new DoubleAnimation(0, Height, TimeSpan.FromSeconds(3));
            fyldet2.BeginAnimation(Rectangle.HeightProperty, animation);

            double Heightt = OmvendtFyld.Height = 0;
            DoubleAnimation animation1 = new DoubleAnimation(320, Heightt, TimeSpan.FromSeconds(4));
            animation1.Completed += new EventHandler(RoterFærdig4);
            OmvendtFyld.BeginAnimation(Rectangle.HeightProperty, animation1);

        }

        private void RoterFærdig4(object sender, EventArgs e)
        {
            double Height = FyldHæld.Height = 0;
            DoubleAnimation animation = new DoubleAnimation(0, Height, TimeSpan.FromSeconds(0.3));
            FyldHæld.BeginAnimation(Rectangle.HeightProperty, animation);

            double Heightt = SidsteFyld.Height = 0;
            DoubleAnimation animation1 = new DoubleAnimation(150, Heightt, TimeSpan.FromSeconds(1.5));
            animation1.Completed += new EventHandler(RoterTilbage);
            SidsteFyld.BeginAnimation(Rectangle.HeightProperty, animation1);

        }

        private void RoterTilbage(object sender, EventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 250;
            da.To = 360;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            RotateTransform rt = new RotateTransform();
            DobbeltDrej.RenderTransform = rt;
            da.Completed += new EventHandler(DrikFærdigKnap);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);

        }

        //Her bliver knapperne "Fyld op" og "skift cocio" enabled.
        private void DrikFærdigKnap(object sender, EventArgs e)
        {
            if (ErDetCocioCola == true)
            {
                MinStartKnap.IsEnabled = true;
                KaspersKnap.IsEnabled = true;
                CocioColaKnap.IsEnabled = true;
                Int32.TryParse(File.ReadAllText(TxtPath), out CocioNummer);
                Int32.TryParse(File.ReadAllText(CCola), out CocioCola);
                CocioNummer++;
                CocioCola++;
                File.WriteAllText(TxtPath, $"{CocioNummer}");
                File.WriteAllText(CCola, $"{CocioCola}");
                CocioColaKnap.Content = "Cocio Cola";
                OpdaterCounter();
                
            }
            else if (KaspersKnap.Content.ToString() == "Cocio Classic")
            {
                MinStartKnap.IsEnabled = true;
                KaspersKnap.IsEnabled = true;
                CocioColaKnap.IsEnabled = true;
                Int32.TryParse(File.ReadAllText(TxtPath), out CocioNummer);
                Int32.TryParse(File.ReadAllText(CDark), out CocioDark);
                CocioNummer++;
                CocioDark++;
                File.WriteAllText(TxtPath, $"{CocioNummer}");
                File.WriteAllText(CDark, $"{CocioDark}");
                OpdaterCounter();
            }
            else if (KaspersKnap.Content.ToString() == "Cocio Dark")
            {
                MinStartKnap.IsEnabled = true;
                KaspersKnap.IsEnabled = true;
                CocioColaKnap.IsEnabled = true;
                //Her læser den filen Drukket.txt som er lavet om til en string og kaldt TxtPath i toppen af koden.
                Int32.TryParse(File.ReadAllText(TxtPath), out CocioNummer);
                Int32.TryParse(File.ReadAllText(CNormal), out CocioNormal);
                //så plusser den cocioens nummer.
                CocioNummer++;
                CocioNormal++;
                //Her skriver den CocioNummeret ind i Drukket.txt filen til næste gang programmet bliver åbnet.
                File.WriteAllText(TxtPath, $"{CocioNummer}");
                File.WriteAllText(CNormal, $"{CocioNormal}");

                //og så skriver den label(cociocounter) om så den bliver opdateret.
                OpdaterCounter();
            }

        }



        public void fyldop1()
        {
            KaspersKnap.IsEnabled = false;
            MinStartKnap.IsEnabled = false;
            Drik.IsEnabled = false;
            CocioColaKnap.IsEnabled = false;
            double Height = fyldet1.Height = 400;
            DoubleAnimation animation = new DoubleAnimation(0, Height, TimeSpan.FromSeconds(2.5));
            animation.Completed += new EventHandler(animation_Completed);
            fyldet1.BeginAnimation(Rectangle.HeightProperty, animation);
        }


        private void animation_Completed(object sender, EventArgs e)
        {

            double Height = fyldet2.Height = 273;
            DoubleAnimation animation = new DoubleAnimation(0, Height, TimeSpan.FromSeconds(4));
            animation.Completed += new EventHandler(animation_Completed2);
            fyldet2.BeginAnimation(Rectangle.HeightProperty, animation);

        }


        private void nedad_færdig(object sender, EventArgs e)
        {
            fyldet2.Height = Double.NaN;
            //MinStartKnap.IsEnabled = true;
            Drik.IsEnabled = false;
            double Height = fyldet2.Height = 0;
            DoubleAnimation animation = new DoubleAnimation(273, Height, TimeSpan.FromSeconds(7));
            animation.Completed += new EventHandler(nedad_færdig);
            fyldet2.BeginAnimation(Rectangle.HeightProperty, animation);
        }

        private void animation_Completed2(object sender, EventArgs e)
        {
            double Height = fyldet1.Height = 0;
            DoubleAnimation animation = new DoubleAnimation(390, Height, TimeSpan.FromSeconds(0.3));
            animation.Completed += new EventHandler(animation_Completed3);
            fyldet1.BeginAnimation(Rectangle.HeightProperty, animation);
            fyldet2.Height = Double.NaN;
            Drik.IsEnabled = true;

        }


        private void animation_Completed3(object sender, EventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush myNormalCocio = new SolidColorBrush();
            SolidColorBrush myDarkCocio = new SolidColorBrush();

            myDarkCocio.Color = Color.FromArgb(255, 107, 60, 35);

            myNormalCocio.Color = Color.FromArgb(255, 160, 110, 69);
            ErDetCocioCola = false;
            if (KaspersKnap.Content.ToString() == "Cocio Dark")
            {
                KaspersKnap.Content = "Cocio Classic";
                cocioimg.Source = new BitmapImage(new Uri(@"C:\Users\kasp609g\source\repos\Cocio\Cocio\Images\cocio_dark2.png"));
                fyldet2.Fill = myDarkCocio;
                fyldet1.Fill = myDarkCocio;
                FyldHæld.Fill = myDarkCocio;
                OmvendtFyld.Fill = myDarkCocio;
                SidsteFyld.Fill = myDarkCocio;
                
                
            }
            else if (KaspersKnap.Content.ToString() == "Cocio Classic")
            {
                KaspersKnap.Content = "Cocio Dark";
                cocioimg.Source = new BitmapImage(new Uri(@"C:\Users\kasp609g\source\repos\Cocio\Cocio\Images\cociogennemsigtigv4.png"));
                fyldet2.Fill = myNormalCocio;
                fyldet1.Fill = myNormalCocio;
                FyldHæld.Fill = myNormalCocio;
                OmvendtFyld.Fill = myNormalCocio;
                SidsteFyld.Fill = myNormalCocio;
                
                
            }

        }


        private void CocioColaClick(object sender, RoutedEventArgs e)
        {
            SolidColorBrush MyCocioCola = new SolidColorBrush();
            MyCocioCola.Color = Color.FromArgb(255, 102, 24, 28);
            ErDetCocioCola = true;
            


            cocioimg.Source = new BitmapImage(new Uri(@"C:\Users\kasp609g\source\repos\Cocio\Cocio\Images\CocioCola.png"));

            fyldet2.Fill = MyCocioCola;
            fyldet1.Fill = MyCocioCola;
            FyldHæld.Fill = MyCocioCola;
            OmvendtFyld.Fill = MyCocioCola;
            SidsteFyld.Fill = MyCocioCola;
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
        private void AddList_Click(object sender, RoutedEventArgs e)
        {

            string IPAdresse = $"{IP1.Text}.{IP2.Text}.{IP3.Text}.{IP4.Text}";
            int Host1Nummer = int.Parse(Host1.Text);

            if (klasse() == "A" || klasse() == "B" || klasse() == "C" || klasse() == "D" || klasse() == "E")
            {


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
            }
            else
            {            
                    Resultater.Text = "Det kan man ikke";
            }

            Host1.Clear();

        }
       


        private void IP1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IP2.Focus();
            }
        }

        private void IP2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IP3.Focus();
            }
        }

        private void IP3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IP4.Focus();
            }
        }

        private void IP4_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Host1.Focus();
            }
        }

        private void Host1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddList_Click(sender, e);

            }
        }
    }
}

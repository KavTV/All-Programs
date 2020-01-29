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
using System.Windows.Media.Animation;
using System.Threading;
using System.IO;

namespace GrafiskKaffekopDerVirker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //string TxtPath = @"C:\Users\kasp609g\source\repos\Cocio\Cocio\Drukket.txt"; 
        //string CDark = @"C:\Users\kasp609g\source\repos\Cocio\Cocio\CDark.txt";
        //string CNormal = @"C:\Users\kasp609g\source\repos\Cocio\Cocio\CNormal.txt";
        //string CCola = @"C:\Users\kasp609g\source\repos\Cocio\CCola.txt";
        
        string TxtPath = Environment.CurrentDirectory + @"\Drukket.lmx";
        //ring TxtPath2 = Environment.CurrentDirectory + @"\Drukket2.lmx";
        string CDark = Environment.CurrentDirectory + @"\CDark.lmx";
        string CNormal = Environment.CurrentDirectory + @"\CNormal.lmx";
        string CCola = Environment.CurrentDirectory + @"\CCola.lmx";

        int CocioNummer;
        int CocioNormal;
        int CocioDark;
        int CocioCola;
        public MainWindow()
        {

            if (File.Exists(TxtPath))
            {
                Console.WriteLine("flot");

            }
            else
            {
               using (FileStream stream1 = File.Create(TxtPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("0");
                stream1.Write(info, 0, info.Length);
            }
            

            }
            if (File.Exists(CDark))
            {
                Console.WriteLine("flot");

            }
            else
            {
                using (FileStream stream2 = File.Create(CDark))
            {

                Byte[] info = new UTF8Encoding(true).GetBytes("0");
                stream2.Write(info, 0, info.Length);


            }
            }
            if (File.Exists(CNormal))
            {
                Console.WriteLine("flot");

            }
            else
            {
             using (FileStream stream3 = File.Create(CNormal)) { 

                Byte[] info = new UTF8Encoding(true).GetBytes("0");
                    stream3.Write(info, 0, info.Length);


                }
            }
            if (File.Exists(CCola))
            {
                Console.WriteLine("flot");

            }
            else
            {
              using (FileStream stream4 = File.Create(CCola) )
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("0");
                    stream4.Write(info, 0, info.Length);


                }
            }



            




            

       
            
                

            
            InitializeComponent();
            //string path = @"D:\Example.txt";
            Drik.IsEnabled = false;
            LoadTxt();
            OpdaterCounter();
            

        }
        
        bool IsCola = false;
                  
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
            fyldop1();

        }

        private void Drik_Click(object sender, RoutedEventArgs e)
        {
            RoterCanvas();

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

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Drikkelyd.wav");
            player.Play();
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
            if (IsCola == true)
            {
                Int32.TryParse(File.ReadAllText(TxtPath), out CocioNummer);
                Int32.TryParse(File.ReadAllText(CCola), out CocioCola);
                CocioNummer++;
                CocioCola++;
                MinStartKnap.IsEnabled = true;
                KaspersKnap.IsEnabled = true;
                CocioColaKnap.IsEnabled = true;
                File.WriteAllText(TxtPath, $"{CocioNummer}");
                File.WriteAllText(CCola, $"{CocioCola}");
                OpdaterCounter();
                CocioColaKnap.Content = "Cocio Cola";
            }

            else if (KaspersKnap.Content.ToString() == "Cocio Classic")
            {
                Int32.TryParse(File.ReadAllText(TxtPath), out CocioNummer);
                Int32.TryParse(File.ReadAllText(CDark), out CocioDark);
                CocioNummer++;
                CocioDark++;
                File.WriteAllText(TxtPath, $"{CocioNummer}");
                File.WriteAllText(CDark, $"{CocioDark}");
                MinStartKnap.IsEnabled = true;
                KaspersKnap.IsEnabled = true;
                CocioColaKnap.IsEnabled = true;
                OpdaterCounter();
            }
            else if (KaspersKnap.Content.ToString() == "Cocio Dark")
            {
                //Her læser den filen Drukket.txt som er lavet om til en string og kaldt TxtPath i toppen af koden.
                Int32.TryParse(File.ReadAllText(TxtPath), out CocioNummer);
                Int32.TryParse(File.ReadAllText(CNormal), out CocioNormal);
                //så plusser den cocioens nummer.
                CocioNummer++;
                CocioNormal++;
                //Her skriver den CocioNummeret ind i Drukket.txt filen til næste gang programmet bliver åbnet.
                File.WriteAllText(TxtPath, $"{CocioNummer}");
                File.WriteAllText(CNormal, $"{CocioNormal}");

                MinStartKnap.IsEnabled = true;
                KaspersKnap.IsEnabled = true;
                CocioColaKnap.IsEnabled = true;
                //og så skriver den label(cociocounter) om så den bliver opdateret.
                OpdaterCounter();
            }
            else
            {
                MinStartKnap.IsEnabled = true;
                KaspersKnap.IsEnabled = true;
                CocioColaKnap.IsEnabled = true;
            }
            
        }

        
        public void fyldop1()
        {
            //MediaPlayer Sound1 = new MediaPlayer();
            //Sound1.Open(new Uri(Environment.CurrentDirectory + @"\Åbncocio.wav"));
            //Sound1.Play();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Åbncocio.wav");
            player.Play();

            KaspersKnap.IsEnabled = false;
            MinStartKnap.IsEnabled = false;
            Drik.IsEnabled = false;
            CocioColaKnap.IsEnabled = false;
            double Height = fyldet1.Height = 400;
            DoubleAnimation animation = new DoubleAnimation(0, Height, TimeSpan.FromSeconds(4));
            animation.Completed += new EventHandler(animation_Completed);
            fyldet1.BeginAnimation(Rectangle.HeightProperty, animation);
        }


        private void animation_Completed(object sender, EventArgs e)
        {
            double Height = fyldet2.Height = 273;
            DoubleAnimation animation = new DoubleAnimation(0, Height, TimeSpan.FromSeconds(4));
            animation.Completed += new EventHandler(animation_Completed2);
            fyldet2.BeginAnimation(Rectangle.HeightProperty, animation);

            //MediaPlayer Sound1 = new MediaPlayer();
            //Sound1.Open(new Uri(Environment.CurrentDirectory + @"\Fyldop2.wav"));
            //Sound1.Play();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Fyldop2.wav");
            player.Play();
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
            if (KaspersKnap.Content.ToString() == "Cocio Dark")
            {
                KaspersKnap.Content = "Cocio Classic";
                cocioimg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Cocio;component/Images/cocio_dark2.png"));
                fyldet2.Fill = myDarkCocio;
                fyldet1.Fill = myDarkCocio;
                FyldHæld.Fill = myDarkCocio;
                OmvendtFyld.Fill = myDarkCocio;
                SidsteFyld.Fill = myDarkCocio;
                CocioColaKnap.Content = "Cocio Cola";
                IsCola = false;
            }
            else
            {
                KaspersKnap.Content = "Cocio Dark";
                cocioimg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Cocio;component/Images/cociogennemsigtigv4.png"));
                fyldet2.Fill = myNormalCocio;
                fyldet1.Fill = myNormalCocio;
                FyldHæld.Fill = myNormalCocio;
                OmvendtFyld.Fill = myNormalCocio;
                SidsteFyld.Fill = myNormalCocio;
                CocioColaKnap.Content = "Cocio Cola";
                IsCola = false;
            }

        }


        private void CocioColaClick(object sender, RoutedEventArgs e)
        {
            SolidColorBrush MyCocioCola = new SolidColorBrush();
            MyCocioCola.Color = Color.FromArgb(255, 102, 24, 28);

            

            cocioimg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Cocio;component/Images/CocioCola.png"));

            fyldet2.Fill = MyCocioCola;
            fyldet1.Fill = MyCocioCola;
            FyldHæld.Fill = MyCocioCola;
            OmvendtFyld.Fill = MyCocioCola;
            SidsteFyld.Fill = MyCocioCola;
            IsCola = true;

        }

        private void Testbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            testbox.Text = "Lavet af KAVTV med hjælp af PHLAP";
        }

        private void CocioKoImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                fyldop1();
            }
        }

        private void BundMund2Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && Drik.IsEnabled == true)
            {
                RoterCanvas();
            }
        }

        private void BundMund1Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && Drik.IsEnabled == true)
            {
                RoterCanvas();
            }
        }
    }
}

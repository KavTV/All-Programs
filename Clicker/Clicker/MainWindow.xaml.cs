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
using System.Windows.Threading;
using System.IO;



namespace Clicker
{
    /// <summary>
    /// longeraction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long Cocioer = 0; //Penge
        long Click_v = 1; //Polong for clicks
        long Cps = 0; //Clicks per second
        long ClickPrice;
        long CpsPrice;
        long CpsUpgrade;
        long ClickUpgrade;
        long ClickClickPrice;
        long ClickClickUpgrade;
        
        

        string CocioMoney = Environment.CurrentDirectory +@"/CocioMoney.lmx";
        string CpsUpgradesSave = Environment.CurrentDirectory + @"/CpsUpgradesSave.lmx";
        string ClickSave = Environment.CurrentDirectory + @"/ClickSave.lmx";
        string ClickPriceSave = Environment.CurrentDirectory + @"/ClickPrice.lmx";
        string CpsSave = Environment.CurrentDirectory + @"/CpsSave.lmx";
        string CpsPriceSave = Environment.CurrentDirectory + @"/CpsPriceSave.lmx";
        string ClickClickUpgradesSave = Environment.CurrentDirectory + @"/ClickClickUpgradesSave.lmx";
        string ClickClickPriceSave = Environment.CurrentDirectory + @"/ClickClickPriceSave.lmx";
        string ClickUpgradesSave = Environment.CurrentDirectory + @"/ClickUpgradesSave.lmx";
        
        public MainWindow()
        {
            //try
            //{

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message + "  -  " + e.StackTrace);
            //}
            MakeFiles();

            InitializeComponent();
            Opdatercounter();
            if (Cps >= 1)
            {
                timer1_tick();
            }
        }

        private void MakeFiles()
        {
            if (File.Exists(CocioMoney))
            {

            }
            else
            {
                using (FileStream fs = File.Create(CocioMoney))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(CpsSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(CpsSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(CpsUpgradesSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(CpsUpgradesSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(ClickSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(ClickSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("1");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(ClickPriceSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(ClickPriceSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("35");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(CpsPriceSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(CpsPriceSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("45");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(ClickClickUpgradesSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(ClickClickUpgradesSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(ClickClickPriceSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(ClickClickPriceSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("200");
                    fs.Write(info, 0, info.Length);
                }
            }
            if (File.Exists(ClickUpgradesSave))
            {

            }
            else
            {
                using (FileStream fs = File.Create(ClickUpgradesSave))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("0");
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        private void CocioKnap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Released)
            {
                Cocioer = Cocioer + Click_v;
                File.WriteAllText(CocioMoney, $"{Cocioer}");
                CocioCounter.Content = Cocioer;
                Random rnd = new Random();
                int Rnd = rnd.Next(0, 3);
                if (Rnd == 1)
                {

                double opacity = plus1.Opacity = 1;
                DoubleAnimation da = new DoubleAnimation(0, opacity, TimeSpan.FromSeconds(0.5));
                da.Completed += new EventHandler(hideplus1);
                plus1.BeginAnimation(OpacityProperty, da);
                }
                else if (Rnd == 2)
                {
                    double gennemsigtig = plus2.Opacity = 1;
                    DoubleAnimation de = new DoubleAnimation(0, gennemsigtig, TimeSpan.FromSeconds(0.5));
                    de.Completed += new EventHandler(hideplus2);
                    plus2.BeginAnimation(OpacityProperty, de);
                }
                else
                {
                    double opacity = plus3.Opacity = 1;
                    DoubleAnimation da = new DoubleAnimation(0, opacity, TimeSpan.FromSeconds(0.5));
                    da.Completed += new EventHandler(hideplus3);
                    plus3.BeginAnimation(OpacityProperty, da);
                }

            }
        }

        private void hideplus1(object sender, EventArgs e)
        {
            double opacity = plus1.Opacity = 0;
            DoubleAnimation da = new DoubleAnimation(1, opacity, TimeSpan.FromSeconds(0.3));
            plus1.BeginAnimation(OpacityProperty, da);
            
        }
        private void hideplus2(object sender, EventArgs e)
        {
            double gennemsigtig = plus2.Opacity = 0;
            DoubleAnimation de = new DoubleAnimation(1, gennemsigtig, TimeSpan.FromSeconds(0.3));
            plus2.BeginAnimation(OpacityProperty, de);
        }
        private void hideplus3(object sender, EventArgs e)
        {
            double opacity = plus3.Opacity = 0;
            DoubleAnimation da = new DoubleAnimation(1, opacity, TimeSpan.FromSeconds(0.3));
            plus3.BeginAnimation(OpacityProperty, da);
        }
        private void LoadTxt()
        {

            Int64.TryParse(File.ReadAllText( CocioMoney), out Cocioer);
            Int64.TryParse(File.ReadAllText( ClickSave), out Click_v);
            Int64.TryParse(File.ReadAllText( CpsUpgradesSave), out CpsUpgrade);
            Int64.TryParse(File.ReadAllText(ClickPriceSave), out ClickPrice);
            Int64.TryParse(File.ReadAllText(CpsSave), out Cps);
            Int64.TryParse(File.ReadAllText( CpsPriceSave), out CpsPrice);
            Int64.TryParse(File.ReadAllText(ClickClickUpgradesSave), out ClickClickUpgrade);
            Int64.TryParse(File.ReadAllText(ClickClickPriceSave), out ClickClickPrice);
            Int64.TryParse(File.ReadAllText(ClickUpgradesSave), out ClickUpgrade);
        }

        public void Opdatercounter()
        {
            LoadTxt();
            CocioCounter.Content = Cocioer;
            CpsUpgradeNumber.Content = CpsUpgrade;
            ClickUpgradeNumber.Content = ClickUpgrade;
            ClickUpgradePrice.Text = ClickPrice.ToString();
            CpsUpgradePrice.Text = CpsPrice.ToString();
            ClickClickUpgradeNumber.Content = ClickClickUpgrade;
            ClickClickUpgradePrice.Text = ClickClickPrice.ToString();
            plus1.Content = "+" + Click_v;
            plus2.Content = "+" + Click_v;
            plus3.Content = "+" + Click_v;

        }

        private void ClickUpgradeBtnClick(object sender, RoutedEventArgs e)
        {
            long ClickPrice = long.Parse(ClickUpgradePrice.Text);
            if (Cocioer >= ClickPrice)
            {
                Cocioer = Cocioer - ClickPrice;
                Click_v += 1;
                CocioCounter.Content = Cocioer;
                ClickUpgrade++;
                ClickUpgradeNumber.Content = ClickUpgrade;
                File.WriteAllText(ClickSave, $"{Click_v}");
                File.WriteAllText(ClickUpgradesSave, $"{ClickUpgrade}");

                plus1.Content = "+" + Click_v;
                plus2.Content = "+" + Click_v;
                plus3.Content = "+" + Click_v;

                long NewPrice = ClickPrice * 2 + 25;
                ClickUpgradePrice.Text = NewPrice.ToString();
                File.WriteAllText(ClickPriceSave, $"{NewPrice}");
            }
        }

        private void Cps_upgrade1_btn_Click(object sender, EventArgs e)
        {
            long CpsPrice = long.Parse(CpsUpgradePrice.Text);
            if (Cocioer >= CpsPrice)
            {
                Cocioer = Cocioer - CpsPrice;
                Cps = Cps + 1;
                CpsUpgrade++;
                CocioCounter.Content = Cocioer;
                CpsUpgradeNumber.Content = CpsUpgrade;
                File.WriteAllText(CpsSave, $"{Cps}");
                File.WriteAllText(CpsUpgradesSave, $"{CpsUpgrade}");

                long NewPrice = CpsPrice * 2 + 40;
                CpsUpgradePrice.Text = NewPrice.ToString();
                File.WriteAllText(CpsPriceSave, $"{NewPrice}");
                if (Cps == 1)
                {
                    timer1_tick();
                }

            }
        }

        private void timer1_tick()
        {
            if (Cps > 0)
            {
                Opdatercounter();
                DispatcherTimer dt = new DispatcherTimer();
                dt.Interval = TimeSpan.FromSeconds(1);
                dt.Tick += Dt_Tick;
                dt.Start();
            }
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            Cocioer = Cocioer + Cps;
            File.WriteAllText(CocioMoney, $"{Cocioer}");
            CocioCounter.Content = Cocioer;
        }

        private void ClickClickUpgradeBtnClick(object sender, RoutedEventArgs e)
        {
            long ClickClickPrice = long.Parse(ClickClickUpgradePrice.Text);
            if (Cocioer >= ClickClickPrice)
            {
                Cocioer = Cocioer - ClickClickPrice;
                Click_v += 2;
                ClickClickUpgrade++;
                CocioCounter.Content = Cocioer;
                ClickClickUpgradeNumber.Content = ClickClickUpgrade;
                File.WriteAllText(ClickSave, $"{Click_v}");
                File.WriteAllText(ClickClickUpgradesSave, $"{ClickClickUpgrade}");

                plus1.Content = "+" + Click_v;
                plus2.Content = "+" + Click_v;
                plus3.Content = "+" + Click_v;

                long NewPrice = ClickClickPrice * 2 + 35;
                ClickClickUpgradePrice.Text = NewPrice.ToString();
                File.WriteAllText(ClickClickPriceSave, $"{NewPrice}");
            }
        }
    }
}

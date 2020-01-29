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
using System.Net.Http;
using HtmlAgilityPack;

namespace GameCatcherWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //StartCrawlerAsync();
            
        }



        List<string> Listen = new List<string>();
        public async Task StartCrawlerAsync()
        {
            DisplayBox.Text = "Loading...";
            var url = "";
            for (int i = 0; i < 6; i++)
            {
                int x = i + 1;
                url = "https://store.steampowered.com/search/?category1=998&specials=1&filter=topsellers&page="+x;

                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("responsive_search_name_combined")).ToList();

                
                Listen.Add($"side {x}");

                foreach (var div in divs)
                {
                    var name = div.Descendants("span").FirstOrDefault().InnerText;
                    var Percent = div.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("col search_discount responsive_secondrow")).FirstOrDefault().Descendants("span").FirstOrDefault().InnerText;

                    var Price = div.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("col search_price discounted responsive_secondrow")).FirstOrDefault().InnerText;
                    var kage = Price.Split(new char[] { '\t', '€' });
                    Price = kage[9];
                    var BeforePrice = kage[8];

                    Listen.Add(name+ ":   "+ Percent + " Før pris " + BeforePrice + "€ Tilbuds pris " + Price + "€");
                    
                }
            }
            DisplayBox.Clear();
                foreach (var item in Listen)
                {
                    DisplayBox.Text += item + "\n \n";
                }
        }


        

        private void DisplayBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DiscountButton_Click(object sender, RoutedEventArgs e)
        {
            StartCrawlerAsync();
        }

        
    }
}

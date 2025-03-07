﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace GameCatcher
{
    class Program
    {
         static void Main(string[] args)
        {

            StartCrawlerAsync();
            Console.ReadLine();
        }

        public static async Task StartCrawlerAsync()
        {
            var url = "";
            for (int i = 0; i < 6; i++)
            {
                int x = i + 1;
                url = "https://store.steampowered.com/search/?category1=998&specials=1&filter=topsellers&page=" + x;

                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("responsive_search_name_combined")).ToList();

                var Games = new List<Games>();

                foreach (var div in divs)
                {
                    var name = div.Descendants("span").FirstOrDefault().InnerText;
                    var Percent = div.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("col search_discount responsive_secondrow")).FirstOrDefault().Descendants("span").FirstOrDefault().InnerText;

                    var Price = div.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("col search_price discounted responsive_secondrow")).FirstOrDefault().InnerText;
                    var kage = Price.Split(new char[] { '\t', '€' });
                    Price = kage[9];
                    var BeforePrice = kage[8];

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(name);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("{0} {1} {2}", Percent, "Fra,", $"Før pris {BeforePrice}, Efter pris {Price} \n");
                }
                    Console.WriteLine($"side {x}");
            }
        }


    }
}

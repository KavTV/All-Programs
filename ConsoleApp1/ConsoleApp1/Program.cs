using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int[] Subnets = {2, 4, 8, 16, 32, 64, 128, 256};
        public static string[] Jens = { "2", "4", "8", "16", "32", "64", "128", "256" };
        static void Main(string[] args)
        {
            List<int> tal = new List<int>();
            


             int rtal = int.Parse( Console.ReadLine());
            tal.Add(rtal);
            Console.Clear();
            tal.Add(3);
            tal.Add(5);
            tal.Add(2);
            tal.Sort();
            tal.Reverse();

            for (int i = 0; i < tal.Count; i++)
            {
                Console.WriteLine(tal[i]);
            }

            

           

            Console.ReadKey();
        }
    }
}

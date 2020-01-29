using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subnet_regning
{
    class Program
    {
           private static byte[] classes = { 0, 127, 128, 191, 192, 223, 224, 239, 240, 255 };
           private static char[] ClassLabel = { 'A', 'B', 'C', 'D', 'E'};
        
        static void Main(string[] args)
        {
            string result = "Null";
            int kk = 0;
            while (kk == 0)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < 10; i += 2)
                {
                    if (number >= classes[i] && number <= classes[i + 1])
                    {
                        result = $" class { ClassLabel[i / 2]}";
                        Console.WriteLine(result);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

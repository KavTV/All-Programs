using System;

namespace Terningkast_der_skifter_farve
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            while (true)
            {

            int terningskast = random.Next(1, 7);
            int randomcolor = random.Next(0, 6);
            System.ConsoleColor[] yeet = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Yellow, ConsoleColor.DarkMagenta };
            Console.ForegroundColor = yeet[randomcolor];
            Console.WriteLine(Environment.NewLine + "Du slog: " + terningskast);
            Console.ReadKey();
            }
        }
    }
}

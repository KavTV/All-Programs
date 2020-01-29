using System;

namespace Array_Øvelse_4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = new string[1000];
            int index = 0;
            while (true)
            {
                Console.WriteLine("tilføj data(1) Se alle indtastede data(2) find element(3) Se statistikker(4) afslut program(5)");
                int inputmenu = int.Parse(Console.ReadLine());

                if (inputmenu == 1)
                {
                    Console.WriteLine("Skriv data");
                    double input = double.Parse(Console.ReadLine());
                    data[index] += input;
                    index++;
                }
                else if (inputmenu == 2)
                {
                    for (int i = 0; i < index; i++)
                    {
                        Console.WriteLine(data[i]);
                        
                    }
                }
                else if (inputmenu == 3)
                {
                    Console.WriteLine("Skriv spil du vil søge på");
                    string input = Console.ReadLine();

                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i] == input)
                        {
                            Console.WriteLine(Environment.NewLine + data[i]);
                        }
                    }
                }
                //Lavet med spil efter aftale med Mikkel
                else if (inputmenu == 4)
                {
                    Console.WriteLine("Antal spil: "+ index);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}

using System;

namespace Variable_og_datatyper
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int tries = 0;
            int guessNumber = random.Next(1, 31);
            int input;
            bool guessRight = false;
            //Kør en while mens tallet ikke er gættet
            while (guessRight == false)
            {
                //tilføj 1 hver gang loopet kører
                tries++;
                Console.WriteLine(Environment.NewLine + "Gæt tallet");
                //Læs input
                input = int.Parse(Console.ReadLine());
                //Tjek hvis input er det samme som genereret nummer
                if (input == guessNumber)
                {
                    //Sæt bool til true så while loop stopper
                    guessRight = true;
                    Console.WriteLine(Environment.NewLine+ "Tillykke! tallet var: "+ guessNumber + " og du brugte: "+tries+" forsøg");
                    if (tries <= 5)
                    {
                        Console.WriteLine("Godt gættet, det er du god til");
                    }
                    else
                    {
                        Console.WriteLine("Du er mega dårlig");
                    }
                }
                //Giv hints hvis input er lavere end random tal
                else if (input < guessNumber)
                {
                    Console.WriteLine(Environment.NewLine + "Tallet er højere");
                }
                //Giv hints hvis input er højere end random tal
                else if (input > guessNumber)
                {
                    Console.WriteLine(Environment.NewLine + "Tallet er lavere");
                }
            }
            //Klik på tast for at lukke consol
            Console.ReadKey();

        }
    }
}

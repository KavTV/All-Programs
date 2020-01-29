using System;

namespace Array_opgave_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Class1 = { "william", "oliver", "noah", "emil", "victor", "magnus", "frederik", "mikkel", "lucas", "alexander"};
            string[] Class2 = { "oscar", "mathias", "sebastian", "malthe", "elias", "christian", "mads", "gustav", "benjamin", "kasper", "woow" };
            float AVG = 0;
            float[,] puntuations = new float[10, 10];
            for (int i = 0; i < 2; i++)
            {
                string[] Class = {};
                if (i == 0)
                {
                    Class = Class1;
                }
                else
                {
                    Class = Class2;
                }
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine("Enter the puntuation {0} group {1}", Class[j], i+1);
                    puntuations[i, j] = Convert.ToSingle(Console.ReadLine());
                }
                for (int f = 0; f < 10; f++)
                {
                    AVG  += puntuations[i, f];
                }
                AVG /= 10;
                if (i== 0)
                {
                Console.WriteLine("Klasse 1 gennemsnit er:"+AVG);
                }
                else
                {
                    Console.WriteLine("Klasse 2 gennemsnit er:" + AVG);
                }
            }
        }
    }
}

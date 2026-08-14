using System;
using System.Diagnostics.CodeAnalysis;

namespace Aufg45
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Wie ist Ihr Name?");
            string user = Console.ReadLine();
            int dtnow = DateTime.Now.Hour; 
            
            if (0 <= dtnow && dtnow <= 10)
            {
                Console.WriteLine($"Guten Morgen {user}");
            }
            else if (10 < dtnow && dtnow < 18)
            {
                Console.WriteLine($"Hallo {user}");
            }
            else if (18 <= dtnow && dtnow < 24)
            {
                Console.WriteLine($"Guten Abend {user}"); 
            }

           

            Console.WriteLine("Farbe? 1: Grün, 2: Gelb, 3: Lila, 4: Eine andere die sie nicht eingeben können lmao");
            string farbe = Console.ReadLine();
            {
               
               what;
                if(farbe == ("1"))
                {
                    Console.WriteLine("bro mag natur");
                    Console.BackgroundColor = ConsoleColor.Green;
                }

                else if
                (farbe ==("2"))
                {
                    Console.WriteLine("Asian?");
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }

                else if
                (farbe == ("3"))
                {
                    Console.WriteLine("Old ahh lady");
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }

                else if
                (farbe == ("4"))
                {
                    Console.WriteLine("Old ahh lady");
                }
                else
                {
                    Console.WriteLine("that is NOT a num lil bro");
                    goto what;
                }
            }

        }
    }

}

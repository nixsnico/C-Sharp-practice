using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

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


        what:
            string farbe = Console.ReadLine();

            if (farbe == "1")
            {
                Console.WriteLine("bro mag natur");
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else if (farbe == "2")
            {
                Console.WriteLine("Asian?");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else if (farbe == "3")
            {
                Console.WriteLine("Old ahh lady");
                Console.BackgroundColor = ConsoleColor.Magenta;
            }
            else if (farbe == "4")
            {
                Console.WriteLine("Old ahh lady");
                
            }
            else
            {
                Console.WriteLine("that is NOT a num lil bro");
                goto what;
            }
            
        }

        private static int getQuestion(int questionNumber)
        {
            int vaquel = 0;
            int vaquelno = 0;

            Console.WriteLine("Magst du Bäume? [y/n]");
            string yn1 = Console.ReadLine();
            if (yn1 == "y")
            {
                Console.WriteLine("du hast safe Grün als Farbe geclickt");
                Thread.Sleep(500);
                valquel =+ 1;
            }
            else
            {
                Console.WriteLine("Natur-hater in the big '26, son");
                Thread.Sleep(500);
            }

            Console.WriteLine("Magst du BlackJack? [y/n]");
            string yn2 = Console.ReadLine();
            if (yn2 == "y")
            {
                Console.WriteLine("Macher");
                Thread.Sleep(500);
                valquel =+ 1;
            }
            else
            {
                Console.WriteLine("yikes bruder");
                Thread.Sleep(500);
                valquelno =- 1;
            }

            Console.WriteLine("Bist du diesen Monat gut finanzielle aufgestellt? [y/n]");
            string yn3 = Console.ReadLine();
            if (yn3 == "y")
            {
                Console.WriteLine("alrrr tut mir leid jeff bezos");
                Thread.Sleep(500);
                valquel =+ 1;
            }
            else
            {
                Console.WriteLine("brokie");
                Thread.Sleep(500);
                valquelno =- 1;
            }

        l911:
            Console.WriteLine("War 9/11 ein Inside Job? [y/n]");
            string yn4 = Console.ReadLine();
            if (yn4 == "y")
            {
                Console.WriteLine("Real");
                Thread.Sleep(500);
                valquel =+ 1;
            }
            else
            {
                Console.WriteLine("try again");
                Thread.Sleep(500);
                valquelno =- 1;
                goto l911;
            }

            Console.WriteLine("Waren das jzt 5 fragen? [y/n]");
            string yn5 = Console.ReadLine();
            if (yn5 == "y")
            {
                Console.WriteLine("i mean theoretisch eig nur 4, du bist grade bei der 5ten");
                Thread.Sleep(500);
                valquel =+ 1;
            }
            else
            {
                Console.WriteLine("Sohnemann das ist die 5te frage");
                Thread.Sleep(500);
                valquelno =- 1;


                Console.WriteLine($"you had {vaquel} right and {vaquelno} wrong");
            }     
        
            


        }
    }
}

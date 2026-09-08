using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace OOP_training
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Welche Aufg. willst du Testen:");

            int x = Convert.ToInt32(Console.ReadLine());

            if (x == 1) 
            {
                 List<Tier> Tierlist = new List<Tier>()
                 {
                    new Hund("Bello"),
                    new Katze("Minka"),
                    new Hund("Rex"),
                    new Vogel("Tweety")
                 };



                foreach (var tier in Tierlist.OfType<Katze>()) //Katzen typ isoliert um Interface Fressen zu testen
                {
                    Console.WriteLine($"{tier.Name}");
                    tier.MakeSound();
                    if (tier is IBewegung bewegung)
                    {
                        bewegung.Bewegen();
                    }
                    if (tier is IFressbar fressbar)
                    {
                        Console.WriteLine("Welches Futter:");
                        fressbar.Fressen("Futter");
                    }
                }
            }


            Auto myAuto = new Auto("Porsche", "Benzinmotor");

            if (x == 2)
            {
                zzz:

                myAuto.Starten();
                Console.WriteLine("Auto Stoppen? [y/n]");
                string yn = Console.ReadLine();

                
                if (yn == "n")
                {
                    Console.WriteLine("Auto ist weiterhin Fahrt bereit");
                }
                else if (yn == "y")
                {
                    myAuto.Stoppen();
                }
                else if (!(yn == "n" || yn == "y"))
                {
                    goto zzz;
                }
            }
        }
    }
}
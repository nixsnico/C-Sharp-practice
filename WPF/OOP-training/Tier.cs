using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_training
{
    public abstract class Tier 
    {

        public Tier(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value;

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name darf nicht leer sein.");
                }
                name = value;
            }
        }
        private string name;
        public abstract void MakeSound();

    }

    interface IBewegung
    {
        void Bewegen();
    }

    interface IFressbar
    {
        void Fressen(string nahrung);
    }

    class Hund : Tier , IBewegung
    {
        public Hund(string name) : base(name)
        {
        }
        
        public void Bewegen()
        {
            Console.WriteLine($"{Name} bewegt sich.");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Wuff Wuff");
        }

        public void Fressen(string nahrung)
        {
            nahrung = Console.ReadLine();
            Console.WriteLine($"{Name} frisst {nahrung}.");
        }
    } 

    class Katze : Tier, IFressbar 
    {
        public void Fressen(string nahrung)
        {
            nahrung = Console.ReadLine();
            Console.WriteLine($"{Name} frisst {nahrung}.");
        }

        public Katze(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Miau Miau");
        }
    }

    class Vogel : Tier , IBewegung
    {
        public void Bewegen()
        {
            Console.WriteLine($"{Name} fliegt.");
        }
        public void Fressen(string nahrung)
        {
            nahrung = Console.ReadLine();
            Console.WriteLine($"{Name} frisst {nahrung}.");
        }

        public Vogel(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zwitscher Zwitscher");
        }
       
    }



    public class Zoo
    {

        public void ManagmentZoo(Zoo zoo)
        {
            Console.WriteLine("Options: 1 = Add, 2 = Remove");
            if (!int.TryParse(Console.ReadLine(), out int AddorRemove)) 
            {
                Console.WriteLine("Ungültige Eingabe! Bitte gib eine Zahl ein.");
                return;
            }

            switch (AddorRemove)
            {
                case 1: //add
                    {
                        Console.WriteLine("available animals in the zoo");
                        for (int i = 0; i < zoo.TiereListe.Count; i++)
                        {
                            Console.WriteLine($"{i}: {zoo.TiereListe[i].Name} ({zoo.TiereListe[i]})");
                        }

                        Console.WriteLine("Input num to choose which animal to add:");
                        int inputpicker = Convert.ToInt32(Console.ReadLine());

                        if (inputpicker >= 0 && inputpicker < zoo.TiereListe.Count)
                        {
                            var abfrageTier = zoo.TiereListe[inputpicker];
                            string welchesTier = zoo.TiereListe[inputpicker].ToString();

                            Console.WriteLine($"Add {welchesTier} to the List?  [y/n]");
                            string x1 = Console.ReadLine();
                            if (x1 == "y")
                            {
                                zoo.AddTiere(abfrageTier);
                                Console.WriteLine("added");
                            }
                            else
                            {
                                Console.WriteLine("alr, didnt add it");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Fehler: Diese Nummer gibt es nicht in der Liste!");
                        }
                    }
                break;



                case 2: //remove
                    {
                        Console.WriteLine("Input num to choose which animal to remove:");
                        int inputpicker = Convert.ToInt32(Console.ReadLine());

                        if (inputpicker >= 0 && inputpicker < zoo.TiereListe.Count)
                        {
                            var abfrageTier = zoo.TiereListe[inputpicker];
                            string welchesTier = abfrageTier.ToString();

                            Console.WriteLine($"Remove {welchesTier} from the List? [y/n]");
                            string x1 = Console.ReadLine();
                            if (x1 == "y")
                            {
                                zoo.RemoveTiere(abfrageTier);
                                Console.WriteLine("removed");
                            }
                            else
                            {
                                Console.WriteLine("alr, didnt remove it");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fehler: Diese Nummer gibt es nicht in der Liste!");
                        }
                    }
                break;
            }
        }

        public List<Tier> TiereListe = new List<Tier>();

        public void AddTiere(Tier tiere)
        {

            TiereListe.Add(tiere);
        }

        public void RemoveTiere(Tier tiere)
        {

            TiereListe.Remove(tiere);
        }

        public void FeedAll()
        {
            foreach (Tier t in TiereListe)
            {
                t.MakeSound();

            }
        }
    } 
}

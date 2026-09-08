using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_training
{
    abstract class Tier
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

        public Vogel(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zwitscher Zwitscher");
        }
    }
}

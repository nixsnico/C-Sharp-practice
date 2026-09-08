using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_training
{
    class Motor
    {
        public string Typ { get; set; }   // <- Auto-Property: ergo kann keine Logik in set o. get eingeben. Muss dafür nh private string machen

        public Motor(string typ)
        {
            Typ = typ;      // <- das ist im Prinzip schon "this.Typ = typ"
        }

        public void Starten()
        {
            Console.WriteLine($"{Typ} wird gestartet... Brumm brumm!");
        }
    }

    public class Auto
    {
        private Motor motor;

        public string Marke { get; set; }

        public Auto(string marke, string motorTyp)
        {
            Marke = marke;
            motor = new Motor(motorTyp);
        }

        public void Starten()
        {
            Console.WriteLine($"{Marke} wird gestartet.");
            motor.Starten();
        }

        public void Stoppen()
        {
            Console.WriteLine("Motor stoppt.");
        }
    }
}

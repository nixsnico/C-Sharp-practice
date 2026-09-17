using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static OOP_training.Person;

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

            if (x == 3)
            {
                Lagerbestand<string> lagerNamen = new Lagerbestand<string>();
                lagerNamen.AddElement("Schraube");
                lagerNamen.AddElement("Hammer");
                Console.WriteLine(lagerNamen.ToString());   

                Lagerbestand<Person> lagerPerson = new Lagerbestand<Person>();
                Console.WriteLine("Input new Person:");
                string new_person_name = Console.ReadLine();
                var newP = new Person();

                newP.Introduce(new_person_name, 30);
                lagerPerson.AddElement(newP);
                Console.WriteLine(lagerPerson.ToString());
            }


            if (x == 4)
            {
                string rightnow = DateTime.Now.ToString();

                if (!(File.Exists("Exception_log.json")))
                {
                    File.WriteAllText("Exception_log.json", "[]");
                }

                string json = File.ReadAllText("Exception_log.json");

                List<ExceptionLogEntry> logEntries = string.IsNullOrWhiteSpace(json)
                    ? new List<ExceptionLogEntry>()                                 // Datei leer? -> neue leere Liste
                    : JsonSerializer.Deserialize<List<ExceptionLogEntry>>(json)     // sonst: JSON einlesen
                    ?? new List<ExceptionLogEntry>();                               // falls das "null" ergibt -> auch leere Liste

                var person = new Person();

                try
                {
                    person.Age = -30;                                                // Exception test
                }
                catch (Person.InvalidAge ex)
                {
                    Console.Write("Fehler: " + ex.ToString() + Environment.NewLine);
                    person.Age = 0;

                    logEntries.Add(new ExceptionLogEntry
                    {
                        Timestamp = DateTime.Now.ToString(),
                        Message = ex.ToString()
                    });

                    File.WriteAllText("Exception_log.json",
                        JsonSerializer.Serialize(logEntries, new JsonSerializerOptions { WriteIndented = true }));
                }

                Console.WriteLine($"Alter ist jetzt: {person.Age}");
            }

            if (x == 5)
            {
                Zoo zoo = new Zoo();
                var hund = new Hund("Chop");
                var katze = new Katze("Void");
                zoo.AddTiere(hund);
                zoo.AddTiere(katze);

                zoo.ManagmentZoo(zoo);
            }
        }
    }
}
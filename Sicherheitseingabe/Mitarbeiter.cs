using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sicherheitseingabe;


namespace Sicherheitseingabe
{

    public enum Freigabe
    {
        grün = 1,
        blau = 2,
        rot = 3,
    }

    public class Mitarbeiter
    {
        public int MitarbeiterID { get; init; }
        public string Nachname { get; set; } = string.Empty;
        public string Vorname { get; set; } = string.Empty;
        public DateOnly StartofEmployment { get; set; }
        public DateOnly Birth { get; set; }
        public bool OnHoliday { get; set; }
        public bool OnWorkTrip { get; set; }
        public Abteilung Abteilung {get; set;}

        public SicherheitsKarte? Karte { get; set; }


        public void CreateMitarbeiter(SicherheitskartenDatenbank kartenDB)
        {
            var mdb = new Mitarbeiterdatenbank();
            string x = Console.ReadLine() ?? "";

            Console.Write("Neuer Mitarbeiter wird Erstellt.");

            int id = mdb.NaechsteID();
            Console.WriteLine($"Vergebene ID: {id}");

            Console.Write("Vorname: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Nachname: ");
            string nachname = Console.ReadLine() ?? "";

            DateOnly birth;
            Console.Write("Birthday (TT.MM.JJJJ): ");
            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", out birth))
                Console.WriteLine("Ungültig, bitte im Format TT.MM.JJJJ eingeben: ");

            DateOnly SoE;
            Console.Write("Start of Employment (TT.MM.JJJJ): ");
            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", out SoE))
                Console.WriteLine("Ungültig, bitte im Format TT.MM.JJJJ eingeben: ");

            Abteilung abteilung = AbteilungAuswahl.Waehlen();

            var neu = new Mitarbeiter
            { MitarbeiterID = id, Vorname = name, Birth = birth, Nachname = nachname,
            StartofEmployment = SoE, Abteilung = abteilung};

            if (mdb.AddMitarbeiter(neu))
            {
                Console.WriteLine("Mitarbeiter gespeichert.");

                mdb.SetKarte(id, new SicherheitsKarte
                {
                    KartenID = id,
                    MitarbeiterID = id,
                    Freigabe = new FreigabeViaAbteilung().GetMaxFreigabe(abteilung)
                });
            }

            kartenDB.AddCard(new SicherheitsKarte
            {
                KartenID = id,
                MitarbeiterID = id,
                Freigabe = new FreigabeViaAbteilung().GetMaxFreigabe(abteilung)
            });
        }
    }
}
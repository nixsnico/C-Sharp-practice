using Sicherheitseingabe;
using System.Text.Json;
using System.Collections.Generic;
using System.Data.Common;
using System.ComponentModel.Design.Serialization;
using System.Security.Authentication.ExtendedProtection;


class Program
{
    static void Main()
    {
        var mdb = new Mitarbeiterdatenbank();
        var m = new Mitarbeiter();
        var kartenDB = new SicherheitskartenDatenbank();
        var terminal = new Terminal(kartenDB, mdb);
        A:


        Console.Write($"Alle Mitarbeiter {Environment.NewLine}");
        mdb.ListMitarbeiter();
        Console.Write($"Existiert der Mitarbeiter?: [y/n] {Environment.NewLine}");
        string x = Console.ReadLine() ?? "";



        if (x == "n")
        {
            m.CreateMitarbeiter(kartenDB);
        }

        else if (x == "y")
        {

            mdb.ListMitarbeiter();
            int whosID;

            while (true)
            {
                Console.Write($"Welchen Mitarbeiter:{Environment.NewLine}");

                if (!int.TryParse(Console.ReadLine(), out whosID))
                {
                   Console.WriteLine("Input ist keine ID.");
                }
                else if (!mdb.ExistiertID(whosID))
                {
                    Console.WriteLine("MitarbeiterID gibts nicht.");
                }
                else
                {
                    break;
                }    
                
            }
            //mGet ist der ausgewählte Mitarbeiter
            var mGet = mdb.GetMitarbeiter(whosID)!;
            var abtl = new FreigabeViaAbteilung();

            if (mGet.Karte == null)
            {
                mdb.SetKarte(whosID, new SicherheitsKarte
                {
                    KartenID = whosID,
                    MitarbeiterID = whosID,
                    Freigabe = abtl.GetMaxFreigabe(mGet.Abteilung)
                });
            }

            //was tun wenn die person schon existiert4
            Console.WriteLine($"Ausgewählt: {mGet.Vorname} {mGet.Nachname}");
            Console.WriteLine("Wo wollen Sie hin?");

            //CanAceess() nutzen um zu sehen ob er die rechte hat

            // basierend darauf welche abteilung er ist = freigabe stufe
            Abteilung gewaelt = AbteilungAuswahl.Waehlen();
            abtl.CheckAccess(mGet.Abteilung, abtl.GetMaxFreigabe(gewaelt));
            //TryAccess() um des zu probieren und zu loggen
            if (terminal.TryAccess(whosID, abtl.GetMaxFreigabe(gewaelt)))
            {
                Console.WriteLine("Eintritt erlaubt.");
            }
            else
            {
                Console.WriteLine("Eintritt verweigert.");
            }

        }

        else
        {
            goto A;
        }

            

    }
}

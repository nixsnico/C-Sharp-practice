using Sicherheitseingabe;
using System.Text.Json;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        var mdb = new Mitarbeiterdatenbank();

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
            Console.WriteLine("Mitarbeiter gespeichert.");
    }
}

using Sicherheitseingabe;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Mitarbeiter abfragemitarbeiter = new();


        Console.WriteLine("Welcher Mitarbeiter sind Sie?");
        Console.ReadLine();



        string pfad = "MitarbeiterInfo.json";
        string jsonLaden = File.ReadAllText(pfad);

        var geladenePersonen = JsonSerializer.Deserialize<Mitarbeiter>(jsonLaden);

        Console.ReadLine();


        var mdb = new Mitarbeiterdatenbank();
        mdb.AddMitarbeiter(new Mitarbeiter { MitarbeiterID = 1,
                                             Nachname = "Mustermann",
                                             Vorname = "Max",
                                             StartofEmployment = new DateTime(2020, 1, 1),
                                             Birth = new DateOnly(1990, 5, 15),
                                             OnHoliday = false,
                                             OnWorkTrip = false });


        

    }
}
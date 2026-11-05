using Sicherheitseingabe;
using System.Text.Json;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        var neu = new Mitarbeiter();

        

         EmployeeData daten = EmployeeStore.Load();

        if (!daten.MitarbeiterListe.Any(m => m.MitarbeiterID == neu.MitarbeiterID))
        {
            daten.MitarbeiterListe.Add(new Mitarbeiter { /* ... */ });
            EmployeeStore.Save(daten);
        }
        
        daten.MitarbeiterListe.Add(new Mitarbeiter
        {
            MitarbeiterID = 1,
            Nachname = "Person",
            Vorname = "Test",
            StartofEmployment = DateTime.Now,
            Birth = new DateOnly(1990, 5, 12)

        });

        Console.WriteLine("");
        Console.WriteLine("Existiert der Mitarbeiter? [y/n]");
        
        
        EmployeeStore.Save(daten);
        // Console.WriteLine("Welcher Mitarbeiter sind Sie?");
        // Console.ReadLine();
    }
}

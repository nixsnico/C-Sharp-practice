using Sicherheitseingabe;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string pfad = "MitarbeiterInfo.json";
        string jsonLaden = File.ReadAllText(pfad);

        var geladenePersonen = JsonSerializer.Deserialize<Mitarbeiter>(jsonLaden);

        Console.ReadLine();

    }
}
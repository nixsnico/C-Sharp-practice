namespace Sicherheitseingabe
{
    public static class AbteilungAuswahl
    {
        public static Abteilung Waehlen()
        {
            Abteilung[] alle = Enum.GetValues<Abteilung>();
            
            //Liste von 1 aus wiedergeben
            Console.WriteLine("Abteilung wählen:");
            for (int i = 0; i < alle.Length; i++)
                Console.WriteLine($"{i + 1}) {alle[i]}");

            int auswahl;
            Console.Write("Nummer: ");
            //loop einf bis die zahl in dem bereich der Abteilungen sind. ergo 1-7
            while (!int.TryParse(Console.ReadLine(), out auswahl) || auswahl < 1 || auswahl > alle.Length)
                Console.Write("Ungültig, bitte neu eingeben: ");

            return alle[auswahl - 1];
        }
    }
}
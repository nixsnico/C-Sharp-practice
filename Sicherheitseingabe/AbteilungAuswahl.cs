namespace Sicherheitseingabe
{
    public static class AbteilungAuswahl
    {
        public static Abteilung Waehlen()
        {
            Abteilung[] alle = Enum.GetValues<Abteilung>();

            Console.WriteLine("Abteilung wählen:");
            for (int i = 0; i < alle.Length; i++)
                Console.WriteLine($"{i + 1}) {alle[i]}");

            int auswahl;
            Console.Write("Nummer: ");
            while (!int.TryParse(Console.ReadLine(), out auswahl) || auswahl < 1 || auswahl > alle.Length)
                Console.Write("Ungültig, bitte neu eingeben: ");

            return alle[auswahl - 1];
        }
    }
}
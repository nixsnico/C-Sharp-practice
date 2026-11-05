namespace Sicherheitseingabe
{
    
    public class SicherheitskartenDatenbank
    {
        private readonly Dictionary<int, SicherheitsKarte> _karten = new(); // Speicher: Karten-ID -> Karte

        public SicherheitsKarte? GetCardByOwner(int mitarbeiterID)
        {
                                                            // Geht alle Karten durch und nimmt die erste, deren Besitzer passt. Sonst null.
            return _karten.Values.FirstOrDefault(k => k.MitarbeiterID == mitarbeiterID);
        }

        public void AddCard(SicherheitsKarte karte)         // Karte hinzufügen
        {
            _karten[karte.KartenID] = karte;                // unter ihrer ID ablegen
        }

        public bool HasCard(int kartenID)                   // gibts die Karte?
        {
            return _karten.ContainsKey(kartenID);           // true=ja / false=no
        }

        public SicherheitsKarte? GetCard(int kartenID)      // Karte holen (oder null)
        {
            _karten.TryGetValue(kartenID, out var karte);   // suchen
            return karte;                                   // Karte oder null zurückgeben
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public DateTime StartofEmployment { get; set; }
        public DateTime Birth { get; set; }
        public bool OnHoliday { get; set; }
        public bool OnWorkTrip { get; set; }
    }

    public class SicherheitsKarte
    {
        public required int KartenID { get; init; }
        public required Freigabe Freigabe { get; init; }
        public DateTime? lastCardUse { get; set; }
        public required int MitarbeiterID { get; init; }

    }

    //ich muss alles kommentieren sonst checke ich es bald selber nicht mehr 

    public class SicherheitskartenDatenbank 
    {
        private readonly Dictionary<int, SicherheitsKarte> _karten = new(); // Speicher: Karten-ID -> Karte

        public SicherheitsKarte? GetCardByOwner(int mitarbeiterID)
        {
            // Geht alle Karten durch und nimmt die erste, deren Besitzer passt. Sonst null.
            return _karten.Values.FirstOrDefault(k => k.MitarbeiterID == mitarbeiterID);
        }

        public void AddCard(SicherheitsKarte karte) // Karte hinzufügen
        {
            _karten[karte.KartenID] = karte;        // unter ihrer ID ablegen
        }

        public bool HasCard(int kartenID)           // gibts die Karte?
        {
            return _karten.ContainsKey(kartenID);   // true=ja / false=no
        }

        public SicherheitsKarte? GetCard(int kartenID)  // Karte holen (oder null)
        {
            _karten.TryGetValue(kartenID, out var karte);   // suchen
            return karte;                                   // Karte oder null zurückgeben
        }
    }

    public class Mitarbeiterdatenbank
    {
        private readonly Dictionary<int, Mitarbeiter> _mitarbeiter = new();

        public void AddMitarbeiter(Mitarbeiter m)
        {
            _mitarbeiter[m.MitarbeiterID] = m;
        }

        public bool HasMitarbeiter(int id)
        {
            return _mitarbeiter.ContainsKey(id);
        }

        public Mitarbeiter? GetMitarbeiter(int id)
        {
            _mitarbeiter.TryGetValue(id, out var m);
            return m;   // null if not found
        }
    }

    public class Terminal
    {
        private readonly SicherheitskartenDatenbank _kartenDB;
        private readonly Mitarbeiterdatenbank _mitarbeiterDB;

        private const Freigabe Accesslvl = Freigabe.rot;

        public Terminal(SicherheitskartenDatenbank kartenDB, Mitarbeiterdatenbank mitarbeiterDB )
        {
            _kartenDB = kartenDB;
            _mitarbeiterDB = mitarbeiterDB;
        }

        public bool CanAccess(int mitarbeiterID)
        {
            var mitarbeiter = _mitarbeiterDB.GetMitarbeiter(mitarbeiterID);
            if (mitarbeiter == null) return false;

            if (mitarbeiter.OnHoliday || mitarbeiter.OnWorkTrip) return false;

            var karte = _kartenDB.GetCardByOwner(mitarbeiterID);
            if (karte == null) return false;

            return karte.Freigabe >= Accesslvl;

        }

        public void AccessAccepted() 
        {
            Console.WriteLine("Access Accepted");
        }

        public void AccessDenied()
        {
            Console.WriteLine("Access Denied");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicherheitseingabe
{
    public class Terminal
    {
        private readonly SicherheitskartenDatenbank _kartenDB;
        private readonly Mitarbeiterdatenbank _mitarbeiterDB;

        private const Freigabe Accesslvl = Freigabe.rot;

        public Terminal(SicherheitskartenDatenbank kartenDB, Mitarbeiterdatenbank mitarbeiterDB)
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

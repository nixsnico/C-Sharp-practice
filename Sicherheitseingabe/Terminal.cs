using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        
        public bool CanAccess(int mitarbeiterID, Freigabe benoetigt)
        {
            var mitarbeiter = _mitarbeiterDB.GetMitarbeiter(mitarbeiterID);
            if (mitarbeiter == null) return false;

            if (mitarbeiter.OnHoliday || mitarbeiter.OnWorkTrip) return false;

            var karte = mitarbeiter.Karte; 
            //Console.WriteLine($"DEBUG: Mitarbeiter={mitarbeiter.Vorname}, Karte={(karte == null ? "null" : karte.Freigabe.ToString())}, benötigt={benoetigt}");
            if (karte == null) return false;

            return karte.Freigabe >= benoetigt;

        }

        public bool TryAccess(int mitarbeiterID, Freigabe benoetigt)
        {
            bool erlaubt = CanAccess(mitarbeiterID, benoetigt);
            var eintrag = new LogEintrag
            {
              Zeit = DateTime.Now,
              MitarbeiterID = mitarbeiterID,
              Erlaubt = erlaubt
            };

            TerminalStore.Add(eintrag);
            
            return erlaubt;
        }
    }
}

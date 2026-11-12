using System.Reflection.Metadata.Ecma335;
using System;
using System.Linq;


namespace Sicherheitseingabe
{
    public class Mitarbeiterdatenbank
    {
        private readonly EmployeeData _daten;
        private readonly Dictionary<int, Mitarbeiter> _mitarbeiter = new();

        public Mitarbeiterdatenbank()
        {
            _daten = EmployeeStore.Load();
            _mitarbeiter = _daten.MitarbeiterListe.ToDictionary(m => m.MitarbeiterID);
        }

        public bool AddMitarbeiter(Mitarbeiter m)
        {
            if (!_mitarbeiter.TryAdd(m.MitarbeiterID, m))
                return false; 

            _daten.MitarbeiterListe.Add(m);
            EmployeeStore.Save(_daten);
            return true;
        }

        public bool ExistiertID(int id) => _mitarbeiter.ContainsKey(id);

        public bool HasMitarbeiter(int id)
        {
            return _mitarbeiter.ContainsKey(id);
        }

        public Mitarbeiter? GetMitarbeiter(int id)
        {
            _mitarbeiter.TryGetValue(id, out var m);
            return m;
        }

        public int NaechsteID()
        {
        //return _mitarbeiter.Count == 0 ? 1 : _mitarbeiter.Keys.Max() + 1;
        
            if (_mitarbeiter.Count == 0)
            return 1;
        else
            return _mitarbeiter.Keys.Max() + 1;
            
        }

    }
}


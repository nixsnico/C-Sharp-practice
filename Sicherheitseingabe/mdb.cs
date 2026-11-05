using System.Reflection.Metadata.Ecma335;
using System;


namespace Sicherheitseingabe
{
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
            return m;
        }
    }
}


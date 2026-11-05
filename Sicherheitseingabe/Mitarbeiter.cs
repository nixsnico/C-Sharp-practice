using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
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
        public DateOnly Birth { get; set; }
        public bool OnHoliday { get; set; }
        public bool OnWorkTrip { get; set; }
    }
}


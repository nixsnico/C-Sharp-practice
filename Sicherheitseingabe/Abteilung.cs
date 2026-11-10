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
    public enum Abteilung
    {
        IT,
        Personal,
        Marketing,
        Security,
        Engineers,
        Admins
    }

    class FreigabeViaAbteilung
    {
        public Freigabe GetMaxFreigabe(Abteilung abteilung)
        {
            switch(abteilung)
            {
                case Abteilung.IT:
                    return Freigabe.blau;
                case Abteilung.Security:
                    return Freigabe.blau;
                case Abteilung.Personal:
                    return Freigabe.grün;
                case Abteilung.Marketing:
                    return Freigabe.grün;
                case Abteilung.Admins:
                    return Freigabe.rot;
                case Abteilung.Engineers:
                    return Freigabe.rot;
                default:
                    return Freigabe.grün;
            }
        }

        public void CheckAccess(Abteilung abteilung, Freigabe neededfreigabe)
        {
            Freigabe abteilungsFreigabe = GetMaxFreigabe(abteilung);

            if (abteilungsFreigabe >= neededfreigabe)
            {
                Console.WriteLine($"Zugriff ERLAUBT für {abteilung} (Besitzt: {abteilungsFreigabe}, Benötigt: {neededfreigabe})");
            }
            else
            {
                Console.WriteLine($"Zugriff VERWEIGERT für {abteilung} (Besitzt: {abteilungsFreigabe}, Benötigt: {neededfreigabe})");
            }
        }
    }
}

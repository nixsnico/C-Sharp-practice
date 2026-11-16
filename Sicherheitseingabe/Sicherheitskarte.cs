using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicherheitseingabe
{
    public class SicherheitsKarte
    {
        public int KartenID { get; set; }
        public required Freigabe Freigabe { get; init; }
        public DateTime? lastCardUse { get; set; }
        public required int MitarbeiterID { get; init; }
    }
}
 
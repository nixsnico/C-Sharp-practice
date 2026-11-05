using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicherheitseingabe
{
    public class SicherheitsKarte
    {
        public required int KartenID { get; init; }
        public required Freigabe Freigabe { get; init; }
        public DateTime? lastCardUse { get; set; }
        public required int MitarbeiterID { get; init; }


        // public void SecurityAccess(Freigabe freigabe)
        // {
        //     switch (freigabe)
        //     {
        //         case Freigabe.grün:
        //             // logik für grünes Licht

        //             break;

        //         case Freigabe.blau:
        //             // logik für blaues Licht

        //             break;

        //         case Freigabe.rot:
        //             // logik für rotes Licht

        //             break;
        //     }
        // }
    }
}
 
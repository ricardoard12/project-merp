using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace DAL.Selections.Stammdaten.Quattro {
    public class QuattroDataFactory : ASelection {

        public static void AddPurchaseHeader(tbl_Puh header) {
            MerpDatabase().tbl_Puh.AddObject(header);
        }

    }
}

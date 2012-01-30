using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Selections.Stammdaten.Product {
    public class ProductDataFactory : ASelection {

        public static void AddUser(IProductView usr) {
            tbl_Usr User = new tbl_Usr {
                Usr_ = usr.UsrId,
                UsrName = usr.UsrName,
                UsrLogedin = usr.UsrLogedIn,
                UsrPassword = usr.UsrPassword,
                UsrIdent = usr.UsrIdent
            };

            MerpDatabase().tbl_Usr.AddObject(User);
            try {
                MerpDatabase().SaveChanges();
            } catch (Exception e) {

            }

        }
    }
}

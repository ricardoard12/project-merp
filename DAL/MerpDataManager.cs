using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Views;
using Views.Stammdaten.User;


namespace DAL
{
    public class MerpDataManager
    {
        readonly db_MERPEntities1 _modell = new db_MERPEntities1();

        public List<Database.tbl_Prd> GetProducts(int PrdCat, int Anzahl, int Start)
        {
            return (from P in _modell.tbl_Prd where P.PrdPrdcat_ == PrdCat orderby P.Prd_ select P).Skip(Start).Take(Anzahl).ToList();
        }

        public Int32 GetProductCategorieCount(int PrdCat)
        {
            return (from P in _modell.tbl_Prd where P.PrdPrdcat_ == PrdCat orderby P.Prd_ select P).Count();
        }

        public List<Database.tbl_Prdcat> GetAllProductCategories() {
            return (from P in _modell.tbl_Prdcat orderby P.Prdcat_ select P).ToList();
        }

        public Int32 GetProductCategorieCount() {
            return (from P in _modell.tbl_Prdcat select P).Count();
        }


        public List<Database.tbl_Usr> GetUserByIdent(string usrident, int Anzahl, int Start) {
            return (from u in _modell.tbl_Usr where u.UsrIdent == usrident select u).Skip(Start).Take(Anzahl).ToList();
        }

        public Int32 GetUserCountByIdent(string usrident) {
            return (from u in _modell.tbl_Usr where u.UsrIdent == usrident select u).Count();
        }

        public void UpdateUser(IUserView usr) {
            tbl_Usr User = (from u in _modell.tbl_Usr where u.Usr_ == usr.UsrId select u).Single();
            User.Usr_ = usr.UsrId;
            User.UsrName = usr.UsrName;
            User.UsrLogedin = usr.UsrLogedIn;
            User.UsrPassword = usr.UsrPassword;
            User.UsrIdent = usr.UsrIdent;
            _modell.SaveChanges();
        }

        public void AddUser(IUserView usr) {
            tbl_Usr User = new tbl_Usr();
            User.Usr_ = usr.UsrId;
            User.UsrName = usr.UsrName;
            User.UsrLogedin = usr.UsrLogedIn;
            User.UsrPassword = usr.UsrPassword;
            User.UsrIdent = usr.UsrIdent;

            _modell.tbl_Usr.AddObject(User);
            try {
                _modell.SaveChanges();
            } catch(Exception e) {
                
            }

        }
    }
}

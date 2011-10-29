using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DL;
using Views;
using Controls;
using System.Xaml;



namespace DAL
{
    public class MerpDataManager
    {
        DL.db_MERPEntities1 modell = new db_MERPEntities1();

        public List<DL.tbl_Prd> GetProducts(int PrdCat, int Anzahl, int Start)
        {
            return (from P in modell.tbl_Prd where P.PrdPrdcat_ == PrdCat orderby P.Prd_ select P).Skip(Start).Take(Anzahl).ToList();
        }

        public Int32 GetProductCategorieCount(int PrdCat)
        {
            return (from P in modell.tbl_Prd where P.PrdPrdcat_ == PrdCat orderby P.Prd_ select P).Count();
        }

        public List<DL.tbl_Prdcat> GetAllProductCategories() {
            return (from P in modell.tbl_Prdcat orderby P.Prdcat_ select P).ToList();
        }

        public Int32 GetProductCategorieCount() {
            return (from P in modell.tbl_Prdcat select P).Count();
        }


        public List<DL.tbl_Usr> GetUserByIdent(string usrident, int Anzahl, int Start) {
            return (from u in modell.tbl_Usr where u.usrIdent == usrident select u).Skip(Start).Take(Anzahl).ToList();
        }

        public Int32 GetUserCountByIdent(string usrident) {
            return (from u in modell.tbl_Usr where u.usrIdent == usrident select u).Count();
        }

        public void UpdateUser(User usr) {
            tbl_Usr User = (from u in modell.tbl_Usr where u.usr_ == usr.UsrId select u).Single();
            User.usr_ = usr.UsrId;
            User.usrName = usr.UsrName;
            User.usrLogedin = usr.UsrLogin;
            User.usrPassword = usr.UsrPassword;
            User.usrIdent = usr.UsrIdent;
            modell.SaveChanges();
        }

        public void AddUser(User usr) {
            tbl_Usr User = new tbl_Usr();
            User.usr_ = usr.UsrId;
            User.usrName = usr.UsrName;
            User.usrLogedin = usr.UsrLogin;
            User.usrPassword = usr.UsrPassword;
            User.usrIdent = usr.UsrIdent;

            modell.tbl_Usr.AddObject(User);
            try {
                modell.SaveChanges();
            } catch(Exception e) {
                
            }

        }
    }
}

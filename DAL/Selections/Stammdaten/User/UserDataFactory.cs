using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Views.Stammdaten.User;

namespace DAL.Selections.Stammdaten.User
{
    public class UserDataFactory
    {
        private static readonly db_MERPEntities1 _database = new db_MERPEntities1();

        public static void AddUser(IUserView usr) {
            tbl_Usr User = new tbl_Usr {
                                           Usr_ = usr.UsrId,
                                           UsrName = usr.UsrName,
                                           UsrLogedin = usr.UsrLogedIn,
                                           UsrPassword = usr.UsrPassword,
                                           UsrIdent = usr.UsrIdent
                                       };

            _database.tbl_Usr.AddObject(User);
            try {
                _database.SaveChanges();
            }
            catch (Exception e) {

            }

        }

        public static List<IUserView> AllUsers() {
            var query = from usr in _database.tbl_Usr select usr;
            List<IUserView> usrs = new List<IUserView>();
            IUserView Usrli = UserFactory.CreateNewUser();

            foreach (var tblUsr in query) {
                Usrli.UsrId = tblUsr.Usr_;
                Usrli.UsrIdent = tblUsr.UsrIdent;
                Usrli.UsrIsEmployer = tblUsr.UsrIsEmployer;
                Usrli.UsrName = tblUsr.UsrName;
                Usrli.UsrNumber = tblUsr.UsrNumber;
                Usrli.UsrPassword = tblUsr.UsrPassword;
                Usrli.UsrLogedIn = tblUsr.UsrLogedin;
                usrs.Add(Usrli);
            }
            return usrs;

            //return query.Select(tblUsr => (Views.Stammdaten.User.UserView)UserFactory.CreateUser(tblUsr.UsrNumber, tblUsr.UsrName, tblUsr.UsrIdent, tblUsr.UsrIsEmployer, tblUsr.UsrPassword)).ToList();
        }

        public static IUserView UserByIdent(string usrident) {
            var Userli = _database.tbl_Usr.Single(usr => usr.UsrIdent == usrident);
            IUserView Userli2 = UserFactory.CreateUser(Userli.UsrNumber, Userli.UsrName, Userli.UsrIdent,
                                                       Userli.UsrIsEmployer,
                                                       Userli.UsrPassword);
            return Userli2;
        }


    }


}


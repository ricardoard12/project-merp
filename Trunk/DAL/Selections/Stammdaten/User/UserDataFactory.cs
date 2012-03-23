using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Views.Stammdaten.User;

namespace DAL.Selections.Stammdaten.User
{
    public class UserDataFactory : ASelection
    {
       

        public static void AddUser(IUserView usr) {
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
            }
            catch (Exception e) {

            }

        }

        public static List<IUserView> AllUsers() {
            var query = from usr in MerpDatabase().tbl_Usr select usr;
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
            var query = (from usr in MerpDatabase().tbl_Usr where usr.UsrIdent == usrident select usr);

            tbl_Usr usre = query.FirstOrDefault();

            if (usre != null) {
                IUserView Userli2 = UserFactory.CreateUser(usre.Usr_,usre.UsrNumber, usre.UsrName, usre.UsrIdent, usre.UsrIsEmployer,
                                                           usre.UsrPassword, usre.UsrLogedin);
                return Userli2;
            }
            return null;
        }
    }


}


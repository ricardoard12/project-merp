using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Views.Stammdaten.User;

namespace DAL.Selections.Stammdaten.User {
    public class UserDataManager
    {
        private db_MERPEntities1 _database = new db_MERPEntities1();
        
        public void AddUser(UserView usr) {
            tbl_Usr User = new tbl_Usr();
            User.Usr_ = usr.UsrId;
            User.UsrName = usr.UsrName;
            User.UsrLogedin = usr.UsrLogedIn;
            User.UsrPassword = usr.UsrPassword;
            User.UsrIdent = usr.UsrIdent;

            _database.tbl_Usr.AddObject(User);
            try {
                _database.SaveChanges();
            } catch(Exception e) {
                
            }

        }

        public List<UserView> AllUsers() {
            var query = from usr in _database.tbl_Usr select usr;
            return query.Select(tblUsr => UserFactory.CreateUser(tblUsr.UsrNumber, tblUsr.UsrName, tblUsr.UsrIdent, tblUsr.UsrIsEmployer, tblUsr.UsrPassword)).ToList();
        }

   


    }
}

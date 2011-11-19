using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Selections.Stammdaten.User;
using Views;
using Views.Stammdaten.User;


namespace BL.Service.Stammdaten.User {
   public class UserService : IUserService {
      
        readonly PagedResult<IUserView> _result = new PagedResult<IUserView>();
        
         public void AddUser(IUserView usr) {
            UserDataFactory.AddUser(usr);
        }

        public PagedResult<UserView> AllUsers() {
            PagedResult<UserView> p = new PagedResult<UserView>();
            p.Rows = Enumerable.ToList<UserView>((from u in UserDataFactory.AllUsers().ToList()
                                                  select new UserView {
                                                                          UsrId = u.UsrId,
                                                                          UsrIdent = u.UsrIdent,
                                                                          UsrIsEmployer = u.UsrIsEmployer,
                                                                          UsrName = u.UsrName,
                                                                          UsrPassword = u.UsrPassword,
                                                                          UsrNumber = u.UsrNumber,
                                                                          UsrLogedIn = false
                                                                      }));


   

            p.Total = p.Rows.Count;
            return p;
        }

        public PagedResult<IUserView> UsersByIdent() {
            throw new NotImplementedException();
        }


        public Boolean TestConnection() {
            return true;
        }
    }
}

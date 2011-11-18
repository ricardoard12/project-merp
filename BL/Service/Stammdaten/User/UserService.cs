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

        public PagedResult<IUserView> AllUsers() {
            _result.Rows = UserDataFactory.AllUsers().ToList();
            _result.Total = _result.Rows.Count();
            return _result;
        }

        public PagedResult<IUserView> UsersByIdent() {
            throw new NotImplementedException();
        }
    }
}

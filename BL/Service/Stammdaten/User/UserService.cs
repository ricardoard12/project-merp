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

        PagedResult<UserView> result = new PagedResult<UserView>();
            
        readonly UserDataManager _dataLayerAccess = new UserDataManager();

        public void AddUser(UserView usr) {
            _dataLayerAccess.AddUser(usr);
        }

        public PagedResult<UserView> AllUsers() {
            result.Rows = _dataLayerAccess.AllUsers();
            result.Total = _dataLayerAccess.AllUsers().Count;
            return result;
        }

        public PagedResult<UserView> UsersByIdent() {
            throw new NotImplementedException();
        }
    }
}

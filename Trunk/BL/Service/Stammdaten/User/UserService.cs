using System;
using System.Linq;
using DAL.Selections.Stammdaten.User;
using Views;
using Views.Stammdaten.User;


namespace BL.Service {
    public partial class RootService : IUserService
    {
        private readonly PagedResult<IUserView> _result = new PagedResult<IUserView>();

        public void AddUser(IUserView usr)
        {
            UserDataFactory.AddUser(usr);
        }

        public PagedResult<IUserView> AllUsers()
        {
            PagedResult<IUserView> p = new PagedResult<IUserView>();
            p.Rows = UserDataFactory.AllUsers();
            p.Total = p.Rows.Count;
            return p;
        }

        public IUserView UsersByIdent(string ident)
        {
            return UserDataFactory.UserByIdent(ident);
        }


        public Boolean TestConnection()
        {
            var auth = new Boolean();
            auth = true;
            return auth;
        }
    }
}

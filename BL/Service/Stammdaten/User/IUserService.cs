using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Views;
using Views.Stammdaten.User;

namespace BL.Service.Stammdaten.User {

    [ServiceContract]
    public interface IUserService : IRootInterface
    {
        [OperationContract]
        void AddUser(UserView usr);

        [OperationContract]
        PagedResult<UserView> AllUsers();

        [OperationContract]
        PagedResult<UserView> UsersByIdent();
    }
}

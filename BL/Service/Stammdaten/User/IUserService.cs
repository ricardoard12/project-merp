using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
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
        void AddUser(IUserView usr);

        [OperationContract]
        PagedResult<UserView> AllUsers();

        [OperationContract]
        PagedResult<IUserView> UsersByIdent();

        [OperationContract]
        [FaultContract(typeof(SecurityTokenAuthenticator))]
        Boolean TestConnection();

        /*
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetAllUsers(AsyncCallback callback, AsyncState s);

        [OperationContract]
        PagedResult<UserView> EndGetAllUsers(IAsyncResult r);
         */

    }
}

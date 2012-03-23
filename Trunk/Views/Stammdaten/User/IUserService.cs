using System;
using System.ServiceModel;
using Views.Security.ErrorException;

namespace Views.Stammdaten.User
{
    
    [ServiceContract]
    [ServiceKnownType(typeof(UserView))]
    public interface IUserService 
    {
        [OperationContract]
        void AddUser(IUserView usr);

        [OperationContract]
        PagedResult<IUserView> AllUsers();

        [OperationContract]
        IUserView UsersByIdent(string ident);

        [OperationContract]
        [FaultContract(typeof(LoginError))]
        Boolean TestConnection();

       
    }
}

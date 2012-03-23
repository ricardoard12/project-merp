using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Views.Security.ErrorException;

namespace Views.Stammdaten.User
{
    
         [ServiceContract]
    public interface IUserService 
    {
        [OperationContract]
        void AddUser(IUserView usr);

        [OperationContract]
        PagedResult<UserView> AllUsers();

        [OperationContract]
        PagedResult<IUserView> UsersByIdent();

        [OperationContract]
        [FaultContract(typeof(LoginError))]
        Boolean TestConnection();

       
    }
}

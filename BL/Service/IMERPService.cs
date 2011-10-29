using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Views;

namespace BL.Service
{
   
    [ServiceContract]
    public interface IMERPService
    {
        [OperationContract]
        PagedResult<Product> GetProducts(int Prdcat, int Anzahl, int Start);

        [OperationContract]
        PagedResult<User> GetUserByIdent(string ident, int Anzahl, int Start);

        [OperationContract]
        void UpdateUser(User usr);

        [OperationContract]
        void AddUser(User usr);
    }
}

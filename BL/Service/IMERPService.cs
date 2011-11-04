using System.ServiceModel;
using Views;
using Views.Stammdaten.Product;
using Views.Stammdaten.User;

namespace BL.Service
{
   
    [ServiceContract]
    public interface IMERPService
    {
        [OperationContract]
        PagedResult<ProductView> GetProducts(int Prdcat, int Anzahl, int Start);

        [OperationContract]
        PagedResult<UserView> GetUserByIdent(string ident, int Anzahl, int Start);

        [OperationContract]
        void UpdateUser(UserView usr);

        [OperationContract]
        void AddUser(UserView usr);
    }
}

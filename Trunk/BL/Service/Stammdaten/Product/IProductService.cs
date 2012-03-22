
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Views;
using Views.Stammdaten.Product;

namespace BL.Service.Stammdaten.Product {

    [ServiceContract]
    public interface IProductService : IRootInterface
    {
       [OperationContract]
       void AddProduct(IProductView product);

       [OperationContract]
       PagedResult<IProductView> GetProducts(int Prdcat, int Anzahl, int Start);

        [OperationContract]
        PagedResult<IProductView> AllProducts();

    }
}

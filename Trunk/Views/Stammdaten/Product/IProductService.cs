using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Views.Stammdaten.Product
{
   
        [ServiceContract]
        [ServiceKnownType(typeof(ProductView))]
        public interface IProductService
        {
            [OperationContract]
            void AddProduct(IProductView product);

            [OperationContract]
            PagedResult<IProductView> GetProducts(int Prdcat, int Anzahl, int Start);

            [OperationContract]
            PagedResult<IProductView> AllProducts();

        
    }
}

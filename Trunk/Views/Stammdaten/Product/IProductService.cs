using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.Product
{
    public interface IProductService
    {
        PagedResult<IProductView> GetProducts(int Prdcat, int Anzahl, int Start);
        PagedResult<IProductView> AllProducts();
        void AddProduct(IProductView product);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Selections.Stammdaten.Product;
using Views;
using Views.Stammdaten.Product;

namespace BL.Service {
    public partial class RootService : IProductService
    {

        public void AddProduct(IProductView product)
        {
            ProductDataFactory.AddProduct(product);
        }

        public PagedResult<IProductView> GetProducts(int Prdcat, int Anzahl, int Start)
        {
            PagedResult<IProductView> resultSet = new PagedResult<IProductView>();
            resultSet.Rows = ProductDataFactory.GetProducts(Prdcat, Anzahl, Start);
            resultSet.Total = resultSet.Rows.Count;

            return resultSet;
        }

        public PagedResult<IProductView> AllProducts()
        {
            var resultSet = new PagedResult<IProductView>();
            resultSet.Rows = ProductDataFactory.AllProducts().ToList();
            resultSet.Total = resultSet.Rows.Count;

            return resultSet;
        }

        public PagedResult<IPrdcatView> AllProductCategorys()
        {
            var resultSet = new PagedResult<IPrdcatView>
                                {
                                    Rows = ProductDataFactory.AllProductsCategorys().ToList(),
                                };
            resultSet.Total = resultSet.Rows.Count;

            return resultSet;
        }

        public void AddPrdcat(IPrdcatView productCat)
        {
            ProductDataFactory.AddPrdcat(productCat);
        }

        public IPrdcatView GetPrdcatByPrimaryKey(int prdcatId)
        {
            return ProductDataFactory.GetPrdcatByPrimaryKey(prdcatId);
        }
    }
}               


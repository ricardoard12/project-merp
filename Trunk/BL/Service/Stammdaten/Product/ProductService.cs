using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Service.Stammdaten.Product;
using DAL.Selections.Stammdaten.Product;
using Views;
using Views.Stammdaten.Product;
using IProductService = BL.Service.Stammdaten.Product.IProductService;

namespace BL.Service {
    public partial class RootService : IProductService {
        
        public void AddProduct(IProductView product) {
            ProductDataFactory.AddProduct(product);
        }

        public PagedResult<IProductView> GetProducts(int Prdcat, int Anzahl, int Start) {
            PagedResult<IProductView> resultSet  = new PagedResult<IProductView>();
            resultSet.Rows = ProductDataFactory.GetProducts(Prdcat, Anzahl, Start);
            resultSet.Total = resultSet.Rows.Count;
            
            return resultSet;
        }

        public PagedResult<IProductView> AllProducts()
        {
            PagedResult<IProductView> resultSet = new PagedResult<IProductView>();
            resultSet.Rows = ProductDataFactory.AllProducts().ToList();
            resultSet.Total = resultSet.Rows.Count;

            return resultSet;
        }
    }
}

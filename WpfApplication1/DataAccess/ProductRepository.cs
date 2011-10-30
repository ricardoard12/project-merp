using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views;
using WpfApplication1.Data.Channel;

namespace WpfApplication1.DataAccess {
    public class ProductRepository
    {
        private PagedResult<Product> _productsView;
        private readonly List<Model.Stammdaten.ProductModel> _productsModel;

        public ProductRepository()
        {
            _productsModel = new List<Model.Stammdaten.ProductModel>();
        }


        public List<Model.Stammdaten.ProductModel> ProductsModel
        {
            get
            {
                if (_productsModel.Count == 0)
                {
                    foreach (var p in ProductsView)
                    {
                        _productsModel.Add(Model.Stammdaten.ProductModel.CreateProduct(p.Name, p.Ean, p.PricePurchase,
                                                                                  p.PriceSale));
                    }
                }

                return _productsModel;
            }
        }

        private IEnumerable<Product> ProductsView {
            get {
                if (_productsView == null)
                    _productsView = Channel.ConnectionToBL.GetProducts(1, 1, 0);

                return _productsView.Rows.ToList();
            }
        }
    }
}

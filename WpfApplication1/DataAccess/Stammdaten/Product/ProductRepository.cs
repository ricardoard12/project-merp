using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using FrontEnd.Data.Channel;
using FrontEnd.Model.Stammdaten;
using Views;
using Views.Security.Connection;
using Views.Stammdaten.Product;
using BL.Service;

namespace FrontEnd.DataAccess.Stammdaten.Product {
    public class ProductRepository
    {
        private IConnection<IMERPService> _connection;
        private IMERPService _merpService;
        private PagedResult<ProductView> _productsView;
        private readonly List<ProductView> _products;
        

        public ProductRepository()
        {
            _connection = ConnectionFactory<IMERPService>.CreateConnection("MerpService","net.tcp://localhost:2526/Service/");
            _merpService = _connection.CreateService;
            _products = new List<ProductView>();
        }


        public List<ProductView> ProductsList
        {
            get
            {
                if (_products.Count == 0)
                {
                    foreach (var p in ProductsView)
                    {
                        _products.Add(ProductFactory.CreateProduct(p.Name, p.Ean, p.PricePurchase,
                                                                                  p.PriceSale));
                    }
                }

                return _products;
            }
        }

        private IEnumerable<ProductView> ProductsView {
            get {
                if (_productsView == null)
                    if(_connection.ChannelFactory.State != CommunicationState.Opened)
                            _connection.ChannelFactory.Open();
                    _productsView = _merpService.GetProducts(1, 1, 0);
                    

                return _productsView.Rows.ToList();
            }
        }
    }
}

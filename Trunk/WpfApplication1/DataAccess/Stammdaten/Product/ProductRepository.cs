using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using BL.Service.Stammdaten.Product;
using BL.Service.Stammdaten.User;
using FrontEnd.Data.Channel;
using Views;
using Views.Security.Connection;
using Views.Stammdaten.Product;
using BL.Service;
using IProductService = Views.Stammdaten.Product.IProductService;

namespace FrontEnd.DataAccess.Stammdaten.Product
{
    public class ProductRepository
    {
        private IConnection<IProductService> _productServiceConnection;
        private PagedResult<IProductView> _productsView;
        private IProductService _productService;
        private readonly List<ProductView> _products;


        public ProductRepository() {
              _products = new List<ProductView>();
        }


        public void AddProduct(IProductView product) {
            Service.AddProduct(product);
        }

        public List<IProductView> ProductsList {
            get {
                _productsView = Service.GetProducts(1, 1, 0);
                return _productsView.Rows.ToList();
            }
        }

        public IConnection<IProductService> Connection {
            get {
                if (_productServiceConnection == null) {
                    _productServiceConnection =
                    ConnectionFactory<IProductService>.CreateConnection("ProductService",
                                                                           "net.tcp://10.12.10.150:2526/Service/Stammdaten/Product");
                }
                if (_productServiceConnection.ChannelFactory.Credentials != null) {
                    _productServiceConnection.ChannelFactory.Credentials.UserName.UserName = Session.Username;
                    _productServiceConnection.ChannelFactory.Credentials.UserName.Password = Session.Password;
                }
                if (_productServiceConnection.ChannelFactory.State != CommunicationState.Opened)
                    _productServiceConnection.ChannelFactory.Open();
                return _productServiceConnection;
            }
        }

        public IProductService Service {
            get { return _productService ?? (_productService = Connection.ChannelFactory.CreateChannel()); }
        }

    }
}
    


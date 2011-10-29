using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views;
using WpfApplication1.Data.Channel;

namespace WpfApplication1.DataAccess {
    class ProductRepository
    {
        private PagedResult<Product> _products;

        public List<Product> Products
        {
            get
            {
                if(_products == null)
                    _products = Channel.ConnectionToBL.GetProducts(1, 1, 0);
                return _products.Rows.ToList();
            }
        }

    }
}

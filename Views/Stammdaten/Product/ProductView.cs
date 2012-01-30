using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.Product {
    public class ProductView : IProductView {

        public int ProductId { get; set; }

        public int ProductNumber { get; set; }

        public string ProductName { get; set; }

        public double PricePurchase { get; set; }

        public double PriceSale { get; set; }
    }
}

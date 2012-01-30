using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.Product {
    public class ProductView : IProductView {


        public ProductView() {

        }


        public ProductView(int id, int? productNumber, string productName, string ean, double? pricePurchase, double? priceSsale, int? produktCategory, int? productSup) {
            ProductId = id;
            ProductNumber = productNumber;
            ProductName = productName;
            Ean = ean;
            PricePurchase = pricePurchase;
            PriceSale = priceSsale;
            ProductCategory = produktCategory;
            ProductSupplier = productSup;
        }

        public int ProductId { get; set; }

        public int? ProductNumber { get; set; }

        public string Ean { get; set; }

        public string ProductName { get; set; }

        public double? PricePurchase { get; set; }

        public double? PriceSale { get; set; }

        public int? ProductCategory { get; set; }

        public int? ProductSupplier { get; set; }
    }
}

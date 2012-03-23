using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Stammdaten.Product {

    [Serializable]
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

        protected ProductView( SerializationInfo info, 
           StreamingContext context)
        {
            ProductId = (int)info.GetValue("ProductId", typeof(int)); 
            ProductNumber = (int?)info.GetValue("ProductNumber", typeof(int));
            ProductName = (string)info.GetValue("ProductName", typeof(string));
            Ean = (string)info.GetValue("Ean", typeof(string));
            PricePurchase = (double?)info.GetValue("PricePurchase", typeof(double?));
            PriceSale = (double?)info.GetValue("PriceSale", typeof(double?)); 
            ProductCategory = (int)info.GetValue("ProductCategory", typeof(int)); 
            ProductSupplier = (int)info.GetValue("ProductSupplier", typeof(int));
            
        }


        public int ProductId { get; set; }

        public int? ProductNumber { get; set; }

        public string Ean { get; set; }

        public string ProductName { get; set; }

        public double? PricePurchase { get; set; }

        public double? PriceSale { get; set; }

        public int? ProductCategory { get; set; }

        public int? ProductSupplier { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ProductId", ProductId);
            info.AddValue("ProductNumber", ProductNumber);
            info.AddValue("ProductName", ProductName);
            info.AddValue("Ean", Ean);
            info.AddValue("PricePurchase", PricePurchase);
            info.AddValue("PriceSale", PriceSale);
            info.AddValue("ProductCategory", PriceSale);
            info.AddValue("ProductSupplier", PriceSale);
        }
    }
}

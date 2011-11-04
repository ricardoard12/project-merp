using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Views.Stammdaten.Product;

namespace WpfApplication1.Model.Stammdaten {
    public class ProductFactory 
    {

        public static ProductView CreateNewProduct()
        {
            return new ProductView();
        }

        public static ProductView CreateProduct(string name, string ean, double pricePurchase, double priceSale)
        {
            return new ProductView
                       {
                           Name = name,
                           Ean = ean,
                           PricePurchase = pricePurchase,
                           PriceSale = priceSale
                       };


        }

        public ProductFactory() {
            
        }




  

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.Product {
    public class ProductFactory
    {

        public static IProductView createNewProduct() {
            return new ProductView();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.Product {
  public interface IProductView {

          int ProductId { get; set; }
          int ProductNumber { get; set; }
          string ProductName { get; set; }
          double PricePurchase { get; set; }
          double PriceSale { get; set; }


      }
    }
}

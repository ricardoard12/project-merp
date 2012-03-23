using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Stammdaten.Product
{
    public interface IProductView : ISerializable
    {

        int ProductId { get; set; }
        int? ProductNumber { get; set; }
        string Ean { get; set; }
        string ProductName { get; set; }
        double? PricePurchase { get; set; }
        double? PriceSale { get; set; }
        int? ProductCategory { get; set; }
        int? ProductSupplier { get; set; }

    }
}


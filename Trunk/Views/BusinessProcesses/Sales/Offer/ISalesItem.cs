using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Views.Stammdaten.Product;

namespace Views.BusinessProcesses.Sales.Offer
{
   public  interface ISalesItem : ISerializable 
   {
       int SaiId { get; set; }
       int? SaiNumber { get; set; }
       int? SaiSahId { get; set; }
       int? SaiPrdId { get; set; }
       double? Saivat { get; set; }
       double? SaiDiscount { get; set; }


   }
}

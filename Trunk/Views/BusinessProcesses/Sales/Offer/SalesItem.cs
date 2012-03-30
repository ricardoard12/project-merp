using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Views.Stammdaten.Product;

namespace Views.BusinessProcesses.Sales.Offer
{
    [Serializable]
    class SalesItem : ISalesItem
    {
        
        public SalesItem()
        {
        }

        public SalesItem(int id, int? Number, int? SahId, int? PrdId, double? vat, double? discount)
        {
            this.SaiId = id;
            this.SaiNumber = Number;
            this.SaiSahId = SahId;
            this.Saivat = vat;
            this.SaiPrdId = PrdId;
            this.SaiDiscount = discount;
        }

        protected SalesItem(SerializationInfo info, StreamingContext context)
        {
            SaiId = (int)info.GetValue("SaiId", typeof(int));
            SaiNumber = (int)info.GetValue("SaiNumber", typeof(int));
            SaiSahId = (int)info.GetValue("SaiSahId", typeof(int));
            SaiPrdId = (int)info.GetValue("SaiPrdId", typeof(int));
            Saivat = (float)info.GetValue("Saivat", typeof(float));
            SaiDiscount = (float)info.GetValue("SaiDiscount", typeof(float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SaiId", SaiId);
            info.AddValue("SaiNumber", SaiNumber);
            info.AddValue("SaiSahId", SaiSahId);
            info.AddValue("SaiPrdId", SaiPrdId);
            info.AddValue("Saivat", Saivat);
            info.AddValue("SaiDiscount", SaiDiscount);
        }

        public int SaiId { get; set; }
        public int? SaiNumber { get; set; }
        public int? SaiSahId { get; set; }
        public int? SaiPrdId { get; set; }
        public double? Saivat { get; set; }
        public double? SaiDiscount { get; set; }

      
    }
}

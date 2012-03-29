using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    [Serializable]
    class SalesItem : ISalesItem
    {

        public SalesItem()
        {
        }

        public SalesItem(int id, int Number, int SahId, int PrdId, float vat, float discount)
        {
            this.SaiId = id;
            this.SaiNumber = Number;
            this.SaiSahId = SahId;
            this.Saivat = vat;
            this.SaiPrdId = PrdId;
            this.SaiDiscount = discount;
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(SaiId, "SaiId", typeof(int));
        }

        public int SaiId { get; set; }
        public int SaiNumber { get; set; }
        public int SaiSahId { get; set; }
        public int SaiPrdId { get; set; }
        public float Saivat { get; set; }
        public float SaiDiscount { get; set; }
    }
}

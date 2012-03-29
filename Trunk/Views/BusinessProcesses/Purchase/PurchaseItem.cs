using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Purchase
{
    [Serializable]
    internal class PurchaseItem : IPurchaseItem
    {

        public int PuiId { get; set; }
        public int? PuiNumber { get; set; }
        public int? PuiPuhId { get; set; }
        public int? PuiPrdId { get; set; }
        public double? Puivat { get; set; }
        public double? PuiDiscount { get; set; }


        public PurchaseItem()
        {
        }

        public PurchaseItem(int id, int? Number, int? SahId, int? PrdId, double? vat, double? discount)
        {
            this.PuiId = id;
            this.PuiNumber = Number;
            this.PuiPuhId = SahId;
            this.Puivat = vat;
            this.PuiPrdId = PrdId;
            this.PuiDiscount = discount;
        }

        protected PurchaseItem(SerializationInfo info, StreamingContext context)
        {
            PuiId = (int) info.GetValue("PuiId", typeof (int));
            PuiNumber = (int?) info.GetValue("PuiNumber", typeof (int));
            PuiPuhId = (int?) info.GetValue("PuiPuhId", typeof (int));
            PuiPrdId = (int?) info.GetValue("PuiPrdId", typeof (int));
            Puivat = (double?)info.GetValue("Puivat", typeof(double));
            PuiDiscount = (double?)info.GetValue("PuiDiscount", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PuiId", PuiId);
            info.AddValue("PuiNumber", PuiNumber);
            info.AddValue("PuiPuhId", PuiPuhId);
            info.AddValue("PuiPrdId", PuiPrdId);
            info.AddValue("Puivat", Puivat);
            info.AddValue("PuiDiscount", PuiDiscount);
        }


    }
}

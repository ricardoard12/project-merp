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
        public int PuiNumber { get; set; }
        public int PuiSahId { get; set; }
        public int PuiPrdId { get; set; }
        public float Puivat { get; set; }
        public float PuiDiscount { get; set; }


        public PurchaseItem()
        {
        }

        public PurchaseItem(int id, int Number, int SahId, int PrdId, float vat, float discount)
        {
            this.PuiId = id;
            this.PuiNumber = Number;
            this.PuiSahId = SahId;
            this.Puivat = vat;
            this.PuiPrdId = PrdId;
            this.PuiDiscount = discount;
        }

        protected PurchaseItem(SerializationInfo info, StreamingContext context)
        {
            PuiId = (int) info.GetValue("PuiId", typeof (int));
            PuiNumber = (int) info.GetValue("PuiNumber", typeof (int));
            PuiSahId = (int) info.GetValue("PuiSahId", typeof (int));
            PuiPrdId = (int) info.GetValue("PuiPrdId", typeof (int));
            Puivat = (float) info.GetValue("Puivat", typeof (float));
            PuiDiscount = (float) info.GetValue("PuiDiscount", typeof (float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PuiId", PuiId);
            info.AddValue("PuiNumber", PuiNumber);
            info.AddValue("PuiSahId", PuiSahId);
            info.AddValue("PuiPrdId", PuiPrdId);
            info.AddValue("Puivat", Puivat);
            info.AddValue("PuiDiscount", PuiDiscount);
        }


    }
}

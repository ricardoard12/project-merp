using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Purchase
{
    internal class PurchaseHeaderView : IPurchaseHeaderView
    {

        public PurchaseHeaderView()
        {
        }

        public PurchaseHeaderView(int purchaseId, int? purchaseNumber, int? purchaseCustomer,
                                  DateTime? purchaseCreateDate, int? purchasetype)
        {
            this.PurchaseHeaderId = purchaseId;
            this.PurchaseHeaderNumber = purchaseNumber;
            this.PurchaseHeaderCustomer = purchaseCustomer;
            this.PurchaseHeaderCreateDate = purchaseCreateDate;
            this.PurchaseHeaderType = purchasetype;
        }


        public int PurchaseHeaderId { get; set; }
        public int? PurchaseHeaderNumber { get; set; }
        public int? PurchaseHeaderCustomer { get; set; }
        public DateTime? PurchaseHeaderCreateDate { get; set; }
        public int? PurchaseHeaderType { get; set; }
        public bool IsValid { get; private set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PurchaseHeaderId", PurchaseHeaderId);
            info.AddValue("PurchaseHeaderNumber", PurchaseHeaderNumber);
            info.AddValue("PurchaseHeaderCustomer", PurchaseHeaderCustomer);
            info.AddValue("PurchaseHeaderCreateDate", PurchaseHeaderCreateDate);
            info.AddValue("PurchaseHeaderType", PurchaseHeaderType);
        }

        protected PurchaseHeaderView(SerializationInfo info, StreamingContext context)
        {
            PurchaseHeaderId = (int)info.GetValue("PurchaseHeaderId", typeof(int));
            PurchaseHeaderNumber = (int?)info.GetValue("PurchaseHeaderNumber", typeof(int));
            PurchaseHeaderCustomer = (int?)info.GetValue("PurchaseHeaderCustomer", typeof(int?));
            PurchaseHeaderCreateDate = (DateTime?)info.GetValue("PurchaseHeaderCreateDate", typeof(DateTime?));
            PurchaseHeaderType = (int?)info.GetValue("PurchaseHeaderType", typeof(int?));
        }

    }
}

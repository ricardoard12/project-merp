using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Purchase
{
    public interface IPurchaseHeaderView : ISerializable
    {
        int PurchaseHeaderId { get; set; }
        int? PurchaseHeaderNumber { get; set; }
        int? PurchaseHeaderCustomer { get; set; }
        DateTime? PurchaseHeaderCreateDate { get; set; }
        int? PurchaseHeaderType { get; set; }
        bool IsValid { get; }
    }
}

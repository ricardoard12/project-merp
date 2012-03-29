using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    public interface ISalesHeaderView : ISerializable
    {
        int SalesHeaderId { get; set; }
        int? SalesHeaderNumber { get; set; }
        int? SalesHeaderCustomer { get; set; }
        DateTime? SalesHeaderCreateDate { get; set; }
        int? SalesHeaderType { get; set; }
        bool IsValid { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    public interface ISalesHeaderView : ISerializable
    {
        int OfferId { get; set; }
        int? OfferNumber { get; set; }
        int? OfferCustomer { get; set; }
        DateTime? OfferCreateDate { get; set; }
        int? SalesType { get; set; }
        bool IsValid { get; }
    }
}

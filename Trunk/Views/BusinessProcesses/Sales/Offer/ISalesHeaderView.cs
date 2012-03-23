using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    public interface ISalesHeaderView
    {
        int OfferId { get; set; }
        int? OfferNumber { get; set; }
        int? OfferCustomer { get; set; }
        DateTime? OfferCreateDate { get; set; }
    }
}

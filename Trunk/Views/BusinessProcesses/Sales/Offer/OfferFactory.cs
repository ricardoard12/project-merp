using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.Stammdaten.Supplier;

namespace Views.BusinessProcesses.Sales.Offer
{
    public class OfferFactory
    {
        public static ISalesHeaderView createNew()
        {
            return new SalesHeaderView();
        }

        public static ISalesHeaderView createNew(int offerId, int offerNumber, int offerCustomer, DateTime offerCreateDate)
        {
            return new SalesHeaderView(offerId, offerNumber, offerCustomer, offerCreateDate);
        }
    }
}

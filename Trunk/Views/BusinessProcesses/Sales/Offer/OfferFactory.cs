using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.Stammdaten.Supplier;

namespace Views.BusinessProcesses.Sales.Offer
{
    public class OfferFactory
    {
        public static IOfferView createNew()
        {
            return new OfferView();
        }

        public static IOfferView createNew(int offerId, int offerNumber, int offerCustomer, DateTime offerCreateDate)
        {
            return new OfferView(offerId, offerNumber, offerCustomer, offerCreateDate);
        }
    }
}

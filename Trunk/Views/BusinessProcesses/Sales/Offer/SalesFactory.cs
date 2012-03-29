using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.Stammdaten.Supplier;

namespace Views.BusinessProcesses.Sales.Offer
{
    public class SalesFactory
    {
        public static ISalesHeaderView createNewSalesHeader()
        {
            return new SalesHeaderView();
        }

        public static ISalesHeaderView createNewSalesHeader(int offerId, int? offerNumber, int? offerCustomer, DateTime? offerCreateDate, int? salestype)
        {
            return new SalesHeaderView(offerId, offerNumber, offerCustomer, offerCreateDate, salestype);
        }

        public static ISalesItem createNewSalesItem(int id, int? Number, int? SahId, int? PrdId, double? vat, double? discount)
        {
            return new SalesItem(id, Number, SahId, PrdId, vat, discount);
        }

        public static ISalesItem createNewSalesItem()
        {
            return new SalesItem();
        }
    }
}

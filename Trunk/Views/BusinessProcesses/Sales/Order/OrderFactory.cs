using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Sales.Order;

namespace Views.BusinessProcesses.Sales.Order
{
    public class OrderFactory
    {
        public static IOrderView createNew()
        {
            return new OrderView();
        }

        public static IOrderView createNew(int offerId, int offerNumber, int offerCustomer, DateTime offerCreateDate)
        {
            return new OrderView(offerId, offerNumber, offerCustomer, offerCreateDate);
        }
    }
}

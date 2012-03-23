using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.BusinessProcesses.Sales.Order
{
    class OrderView: IOrderView
    {
        private int offerId;
        private int offerNumber;
        private int offerCustomer;
        private DateTime offerCreateDate;

        public OrderView(int offerId, int offerNumber, int offerCustomer, DateTime offerCreateDate)
        {
            // TODO: Complete member initialization
            this.offerId = offerId;
            this.offerNumber = offerNumber;
            this.offerCustomer = offerCustomer;
            this.offerCreateDate = offerCreateDate;
        }

        public OrderView()
        {
            // TODO: Complete member initialization
        }

    }
}

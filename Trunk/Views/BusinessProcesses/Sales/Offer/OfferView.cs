using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    [Serializable]
    class OfferView : IOfferView
    {

        public OfferView()
        {
        }

        public OfferView(int offerId, int offerNumber, int offerCustomer, DateTime offerCreateDate)
        {
            this.OfferId = offerId;
            this.OfferNumber = offerNumber;
            this.OfferCustomer = offerCustomer;
            this.OfferCreateDate = offerCreateDate;
        }


        public int OfferId { get; set; }
        public int OfferNumber { get; set; }
        public int OfferCustomer { get; set; }
        public DateTime OfferCreateDate { get; set; }
    }



}

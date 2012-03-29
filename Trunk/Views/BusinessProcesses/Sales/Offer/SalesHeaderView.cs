using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    [Serializable]
    class SalesHeaderView : ISalesHeaderView
    {

        public SalesHeaderView()
        {
        }

        public SalesHeaderView(int offerId, int? offerNumber, int? offerCustomer, DateTime? offerCreateDate, int? salestype)
        {
            this.OfferId = offerId;
            this.OfferNumber = offerNumber;
            this.OfferCustomer = offerCustomer;
            this.OfferCreateDate = offerCreateDate;
            this.SalesType = salestype;
        }


        public int OfferId { get; set; }
        public int? OfferNumber { get; set; }
        public int? OfferCustomer { get; set; }
        public DateTime? OfferCreateDate { get; set; }
        public int? SalesType { get; set; }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OfferId", OfferId);
            info.AddValue("OfferNumber", OfferNumber);
            info.AddValue("OfferCustomer", OfferCustomer);
            info.AddValue("OfferCreateDate", OfferCreateDate);
            info.AddValue("SalesType", SalesType);
        }


    }



}

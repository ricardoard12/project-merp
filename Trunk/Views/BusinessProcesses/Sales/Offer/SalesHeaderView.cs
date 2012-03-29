using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.BusinessProcesses.Sales.Offer
{
    [Serializable]
    class SalesHeaderView : ISalesHeaderView, IDataErrorInfo
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


        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "OfferNumber":
                    error = this.ValidateOfferNumber();
                    break;

                case "OfferCustomer":
                    error = this.ValidateOfferCustomer();
                    break;

                case "OfferCreateDate":
                    error = this.ValidateOfferCreateDate();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Offer: " + propertyName);
                    break;
            }

            return error;
        }

        private string ValidateOfferNumber()
        {
            if (IsStringMissing(Convert.ToString(OfferNumber)))
                return "Missing Offer Number";

            return null;
        }

        private string ValidateOfferCustomer()
        {
            if (IsStringMissing(Convert.ToString(OfferCustomer)))
                return "Missing Offer Customer";

            return null;
        }

        private string ValidateOfferCreateDate()
        {
            if (IsStringMissing(Convert.ToString(OfferCreateDate)))
                return "Missing Offer create date";

            return null;
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        static readonly string[] ValidatedProperties = 
        { 
            "OfferNumber", 
            "OfferCustomer", 
            "OfferCreateDate"
        };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }
    }



}

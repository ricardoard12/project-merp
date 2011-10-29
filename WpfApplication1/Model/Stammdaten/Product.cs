using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WpfApplication1.Model.Stammdaten {
    public class Product : IDataErrorInfo
    {



        public static Product CreateNewProduct()
        {
            return new Product();
        }

        public static Product CreateProduct(string name, string ean, double pricePurchase, double priceSale)
        {
            return new Product
                       {
                           Name = name,
                           Ean = ean,
                           PricePurchase = pricePurchase,
                           PriceSale = priceSale
                       };


        }
        protected Product() {
            
        }


        #region Properties

        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Ean { get; set; }
        public Double PricePurchase { get; set; }
        public Double PriceSale { get; set; }

        #endregion


        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get { return this.ValidationError(propertyName); }
        }


        private static readonly string[] ValidatedProperties =
            {
                "Name",
                "Ean",
                "PricePurchase",
                "PriceSale"
            };

        private string ValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Name":
                    error = this.ValidateName();
                    break;

                case "Ean":
                    error = this.ValidateEan();
                    break;

                case "PricePurchase":
                    error = this.ValidatePricePurchase();
                    break;

                case "PriceSale":
                    error = this.ValidatePriceSale();
                    break;
                default:
                    Debug.Fail("Unexpected property being validated on Product: " + propertyName);
                    break;
            }

            return error;
        }

        private string ValidateName()
        {
            return IsStringMissing(this.Name) ? "Missing Name" : null;
        }

        private string ValidateEan()
        {
            return IsStringMissing(this.Ean) ? "Missing Ean" : null;
        }

        private string ValidatePricePurchase()
        {
            return !IsStringMissing(Convert.ToString(this.PricePurchase)) ? "Missing PricePurchase" : null;
        }

         private string ValidatePriceSale()
        {
            return !IsStringMissing(Convert.ToString(this.PriceSale)) ? "Missing PricePurchase" : null;
        }


        private static bool IsStringMissing(string value)
        {
            return String.IsNullOrEmpty(value) || value.Trim() == String.Empty;
        }

    }
}

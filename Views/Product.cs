using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views
{
    public class Product
    {
        private Int32 _id;
        private string name;
        private string ean;
        private Double pricePurchase;
        private Double priceSale;

        public Int32 Id {
            get { return _id; }
            set { _id = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

 

        public string Ean
        {
            get { return ean; }
            set { ean = value; }
        }

        public Double PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public Double PriceSale
        {
            get { return priceSale; }
            set { priceSale = value; }
        }
    }
}

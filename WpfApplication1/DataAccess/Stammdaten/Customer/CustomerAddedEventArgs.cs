using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication1.Model.Stammdaten;

namespace WpfApplication1.DataAccess {
    public class CustomerAddedEventArgs : EventArgs {

        public CustomerAddedEventArgs(CustomerModel newCustomerModel) {
            this.NewCustomerModel = newCustomerModel;
        }

        public CustomerModel NewCustomerModel { get; private set; }
    }
}

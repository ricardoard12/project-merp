using System;
using WpfApplication1.Model.Stammdaten;

namespace WpfApplication1.DataAccess.Stammdaten.Customer {
    public class CustomerAddedEventArgs : EventArgs {

        public CustomerAddedEventArgs(CustomerModel newCustomerModel) {
            this.NewCustomerModel = newCustomerModel;
        }

        public CustomerModel NewCustomerModel { get; private set; }
    }
}

using System;
using FrontEnd.Model.Stammdaten;

namespace FrontEnd.DataAccess.Stammdaten.Customer {
    public class CustomerAddedEventArgs : EventArgs {

        public CustomerAddedEventArgs(CustomerModel newCustomerModel) {
            this.NewCustomerModel = newCustomerModel;
        }

        public CustomerModel NewCustomerModel { get; private set; }
    }
}

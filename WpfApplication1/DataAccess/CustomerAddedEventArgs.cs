using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication1.Model;

namespace WpfApplication1.DataAccess {
    public class CustomerAddedEventArgs : EventArgs {

        public CustomerAddedEventArgs(Customer newCustomer) {
            this.NewCustomer = newCustomer;
        }

        public Customer NewCustomer { get; private set; }
    }
}

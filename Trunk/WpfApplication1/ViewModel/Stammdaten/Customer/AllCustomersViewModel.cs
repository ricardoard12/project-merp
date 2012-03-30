using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using FrontEnd.DataAccess.Stammdaten.Customer;
using FrontEnd.DataAccess;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Views.Stammdaten;
using WpfApplication1.DataAccess.Stammdaten.Customer;

namespace FrontEnd.ViewModel.Stammdaten.Customer {
    class AllCustomersViewModel : WorkspaceViewModel {

        readonly CustomerRepository _customerRepository;
        public ObservableCollection<ICustomerView> AllCustomers { get; private set; }
        
        public AllCustomersViewModel() {
            _customerRepository = new CustomerRepository();
            AllCustomers = new ObservableCollection<ICustomerView>(_customerRepository.AllCustomers());
        }

       

        //Berechnet die Summe aller selektierter Kunden
        public double TotalSelectedSales {
            get {
                return  new double();
              
            }
        }


    }
}

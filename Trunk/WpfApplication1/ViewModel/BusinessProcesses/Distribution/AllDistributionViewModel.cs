using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrontEnd.DataAccess.Stammdaten.Customer;
using FrontEnd.ViewModel.Stammdaten.Customer;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;

namespace WpfApplication1.ViewModel.BusinessProcesses.Distribution
{
    class AllDistributionViewModel
    {
        readonly QuattroRepository quattroRepository;
        public ObservableCollection<DistributionViewModel> AllDistribution { get; private set; }

        public AllDistributionViewModel(QuattroRepository quattroRepository)
        {
            if (quattroRepository == null)
                throw new ArgumentNullException("quattroRepository");

            //base.DisplayName = "AllCustomersViewModel_DisplayName";
            this.quattroRepository = quattroRepository;

            //notification when a new customer is saved
            this.quattroRepository. += this.OnCustomerAddedToRepository;

            //Populate the AllCustomers collection with CustomerViewModels
            this.CreateAllCustomers();
        }

        private void CreateAllCustomers() {
           
        
        }

        //Berechnet die Summe aller selektierter Kunden
        public double TotalSelectedSales {
            get {
                return  new double();
              
            }
        }

        protected override void OnDispose() {
            foreach (CustomerViewModel custVM in this.AllDistribution)
                custVM.Dispose();

            this.AllDistribution.Clear();
            this.AllDistribution.CollectionChanged -= this.OnCollectionChanged;

            _customerRepository.CustomerAdded -= this.OnCustomerAddedToRepository;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (CustomerViewModel custVM in e.NewItems)
                    custVM.PropertyChanged += this.OnCustomerViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (CustomerViewModel custVM in e.OldItems)
                    custVM.PropertyChanged -= this.OnCustomerViewModelPropertyChanged;
        }

        void OnCustomerViewModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            string IsSelected = "IsSelected";
            // Make sure that the property name we're referencing is valid.
            // This is a debugging technique, and does not execute in a Release build.
            (sender as CustomerViewModel).VerifyPropertyName(IsSelected);

            // When a customer is selected or unselected, we must let the
            // world know that the TotalSelectedSales property has changed,
            // so that it will be queried again for a new value.
            if (e.PropertyName == IsSelected)
                this.OnPropertyChanged("TotalSelectedSales");
        }

        void OnCustomerAddedToRepository(object sender, CustomerAddedEventArgs e) {
            var viewModel = new CustomerViewModel();
            this.AllDistribution.Add(viewModel);
        }
    }
}

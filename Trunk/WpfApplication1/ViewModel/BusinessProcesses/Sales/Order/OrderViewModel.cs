using System;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;
using WpfApplication1.DataAccess.Stammdaten.Customer;
using Views.Stammdaten.Customer;
using System.Collections.Generic;
using System.Text;
using Views.Stammdaten.User;
using System.Collections.ObjectModel;
using Views.Stammdaten.Customer;
using Views.Stammdaten;

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Order
{
    public class OrderViewModel : WorkspaceViewModel
    {
        private IQuattroRepository quattroRepository;
        private ISalesHeaderView _salesHeaderView;
        private ObservableCollection<ICustomerView> allCustomers;
        private CustomerRepository customerRepository;
        private ICustomerView selectedCustomer;
        private ISalesItem salesItem;
        private ObservableCollection<ISalesItem> positions;


        private string[] typeOptions;
        private bool isSelected;

        public OrderViewModel()
        {
            this.quattroRepository = new QuattroRepository();
            this.customerRepository = new CustomerRepository();
            this._salesHeaderView = SalesFactory.createNewSalesHeader();
            selectedCustomer = CustomerFactory.createNew();
        }

        #region Constructors

        public OrderViewModel(ISalesHeaderView _salesHeaderView, IQuattroRepository quattroRepository)
        {
            if (_salesHeaderView == null)
                throw new ArgumentNullException("_salesHeaderView");

            if (quattroRepository == null)
                throw new ArgumentNullException("orderRepository");

            this._salesHeaderView = _salesHeaderView;
            this.quattroRepository = quattroRepository;
        }

        #endregion Constructors

        #region Order Properties

        public int? OfferNumber
        {
            get { return _salesHeaderView.SalesHeaderNumber; }
            set
            {
                if (value == _salesHeaderView.SalesHeaderNumber)
                    return;

                _salesHeaderView.SalesHeaderNumber = value;
                base.OnPropertyChanged("SalesHeaderNumber");
            }
        }

        public int? OfferCustomer
        {
            get { return _salesHeaderView.SalesHeaderCustomer; }
            set
            {
                if (value == _salesHeaderView.SalesHeaderCustomer)
                    return;

                _salesHeaderView.SalesHeaderCustomer = value;
                base.OnPropertyChanged("SalesHeaderCustomer");
            }
        }


        public ObservableCollection<ICustomerView> GetCustomers
        {
            get
            {
                return allCustomers ?? (allCustomers = new ObservableCollection<ICustomerView>(customerRepository.AllCustomers()));
            }
        }

        public ICustomerView SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                if (value != selectedCustomer)
                {
                    selectedCustomer = value;
                   _salesHeaderView.SalesHeaderCustomer = value.CusId;
                   OnPropertyChanged("SelectedCustomer");
                }
                
            }
        }

        public ObservableCollection<ISalesItem> Positions
        {
            get
            {
                if (positions == null || positions.Count == 0)
                {
                    positions = new ObservableCollection<ISalesItem>(quattroRepository.AllSalesItemsBySalesHeader(_salesHeaderView.SalesHeaderId));
                }
                return positions;
            }
        }

        #endregion Order Properties
    }
}
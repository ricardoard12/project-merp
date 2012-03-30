using System;
using FrontEnd.DataAccess.Stammdaten.Product;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using Views.Stammdaten.Product;
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
        private ProductRepository productRepository;
        private ICustomerView selectedCustomer;
        private IProductView selectedProduct;
        private ISalesItem salesItem;
        private ObservableCollection<ISalesItem> positions;
        private ObservableCollection<IProductView> products;


        private string[] typeOptions;
        private bool isSelected;

        #region Constructors

        public OrderViewModel()
        {
            this.quattroRepository = new QuattroRepository();
            this.customerRepository = new CustomerRepository();
            this.productRepository = new ProductRepository();
            this._salesHeaderView = SalesFactory.createNewSalesHeader();
            this.selectedProduct = ProductFactory.createProduct();
            selectedCustomer = CustomerFactory.createNew();

        }

      

        #endregion Constructors

        #region Order Properties

        public int? OrderNumber
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


        public ObservableCollection<IProductView> Products
        {
            get { return products ?? (products = new ObservableCollection<IProductView>(productRepository.ProductsList)); }
        }

        public IProductView SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                   selectedProduct = value;
                   OnPropertyChanged("SelectedProduct");    
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

        public DateTime? SelectedDate
        {
            get { return _salesHeaderView.SalesHeaderCreateDate; }

            set
            {
                if (!Equals(value, _salesHeaderView.SalesHeaderCreateDate))
                {
                    _salesHeaderView.SalesHeaderCreateDate = value;
                }
                OnPropertyChanged("SelectedDate");
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

        public double? Amount
        {
            get { return salesItem.Saivat; }
            set
            {
                salesItem.Saivat = value;
                OnPropertyChanged("Amount");
            }
        }


        public double? Price
        {
            get { return salesItem.SaiDiscount; }
            set
            {
                salesItem.SaiDiscount = value;
                OnPropertyChanged("Price");
            }
        }


        #endregion Order Properties
    }
}
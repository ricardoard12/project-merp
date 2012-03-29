using System;
using System.ComponentModel;
using FrontEnd.DataAccess.Stammdaten.Customer;
using System.Windows.Input;
using Views.Stammdaten;
using Views.Stammdaten.Customer;
using WpfApplication1.DataAccess.Stammdaten.Customer;

namespace FrontEnd.ViewModel.Stammdaten.Customer {
    class CustomerViewModel : WorkspaceViewModel, IDataErrorInfo {
        #region Fields

        private ICustomerView customer;
        readonly CustomerRepository customerRepository;
        string customerType;
        string[] customerTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;

        #endregion Fields

        #region Constructors
        public CustomerViewModel() {
            customer = CustomerFactory.createNew();
            customerRepository = new CustomerRepository();
            customerType = "NotSpecified";
        }  

        #endregion Constructors

        #region Customer Properties
        public string Email {
            get { return customer.Email; }
            set {
                if (value == customer.Email)
                    return;

                customer.Email = value;
                base.OnPropertyChanged("Email");
            }
        }

        public string FirstName {
            get { return customer.CusFirstname; }
            set {
                if (value == customer.CusFirstname)
                    return;
                customer.CusFirstname = value;
                base.OnPropertyChanged("FirstName");
            }
        }

        public bool? IsCompany {
            get { return customer.CusIsCompany; }
        }

        public string LastName {
            get { return customer.CusLastname; }
            set {
                if (value == customer.CusLastname)
                    return;
                customer.CusLastname = value;

                base.OnPropertyChanged("LastName");
            }
        }

        /*
        public double TotalSales {
            get { return customer.; }
        }
         */

        #endregion Customer Properties

        #region Presentation properties

        public string CustomerType {
            get { return customerType; }
            set {
                if (value == customerType || String.IsNullOrEmpty(value))
                    return;

                customerType = value;

                if (customerType == "Company") {
                    customer.CusIsCompany = true;
                } else if (customerType == "Person") {
                    customer.CusIsCompany = false;
                }

                base.OnPropertyChanged("CustomerType");
                // Falls CustomerType Company wird, oder nicht mehr Company muss der Lastname
                // Ebenfalls aktualisiert werden
                base.OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Returns a list of strings used to populate the Customer Type selector.
        /// </summary>
        public string[] CustomerTypeOptions {
            get {
                if (customerTypeOptions == null) {
                    customerTypeOptions = new string[]
                    {
                        "NotSpecified",
                        "Person",
                        "Company"
                    };
                }
                return customerTypeOptions;
            }
        }

        public override string DisplayName {
            get {
                if (this.customer.CusId <= 0) {
                    return "Display Name";
                } else if (customer.CusIsCompany == true) {
                    return customer.CusLastname;
                } else {
                    return String.Format("{0}, {1}", customer.CusLastname, customer.CusFirstname);
                }
            }
        }

        public bool IsSelected {
            get { return _isSelected; }
            set {
                if (value == _isSelected)
                    return;

                _isSelected = value;

                base.OnPropertyChanged("IsSelected");
            }
        }

        public ICommand SaveCommand {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(
                                                           param => this.Save(),
                                                           param => this.CanSave
                                                           ));
            }
        }

        #endregion // Presentation Properties

        #region public methods

        /// <summary>
        /// Saves the customer to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        
        
        public void Save() {
            customerRepository.AddCustomer(customer);
            base.OnPropertyChanged("DisplayName");
        }
        
                /// <summary>
        /// Returns true if the customer is valid and can be saved.
        /// </summary>
        bool CanSave {
            get { return String.IsNullOrEmpty(this.ValidateCustomerType()) && customer.IsValid; }
        }
        
        #endregion public methods

        #region Private Helpers


        #endregion // Private Helpers

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error {
            get { return (customer as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName] {
            get {
                string error = null;

                if (propertyName == "CustomerType") {
                    // The IsCompany property of the Customer class 
                    // is Boolean, so it has no concept of being in
                    // an "unselected" state.  The CustomerViewModel
                    // class handles this mapping and validation.
                    error = this.ValidateCustomerType();
                } else {
                    error = (customer as IDataErrorInfo)[propertyName];
                }

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }

        string ValidateCustomerType() {
            if (this.CustomerType == "Company" ||
               this.CustomerType == "Person")
                return null;

            return "Customer type must be selected";
        }

        #endregion // IDataErrorInfo Members
    }
}
   
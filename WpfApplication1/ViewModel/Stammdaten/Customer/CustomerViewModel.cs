using System;
using System.ComponentModel;
using WpfApplication1.DataAccess;
using System.Windows.Input;

namespace WpfApplication1.ViewModel.Stammdaten.Customer {
    class CustomerViewModel : WorkspaceViewModel, IDataErrorInfo {
        #region Fields
        readonly Model.Customer _customer;
        readonly CustomerRepository _customerRepository;
        string _customerType;
        string[] _customerTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;

        #endregion Fields

        #region Constructors
        public CustomerViewModel(Model.Customer customer, CustomerRepository customerRepository) {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            _customer = customer;
            _customerRepository = customerRepository;
            _customerType = "NotSpecified";
        }

        #endregion Constructors

        #region Customer Properties
        public string Email {
            get { return _customer.Email; }
            set {
                if (value == _customer.Email)
                    return;

                _customer.Email = value;
                base.OnPropertyChanged("Email");
            }
        }

        public string FirstName {
            get { return _customer.FirstName; }
            set {
                if (value == _customer.FirstName)
                    return;

                _customer.FirstName = value;

                base.OnPropertyChanged("FirstName");
            }
        }

        public bool IsCompany {
            get { return _customer.IsCompany; }
        }

        public string LastName {
            get { return _customer.LastName; }
            set {
                if (value == _customer.LastName)
                    return;

                _customer.LastName = value;

                base.OnPropertyChanged("LastName");
            }
        }

        public double TotalSales {
            get { return _customer.TotalSales; }
        }

        #endregion Customer Properties

        #region Presentation properties

        public string CustomerType {
            get { return _customerType; }
            set {
                if (value == _customerType || String.IsNullOrEmpty(value))
                    return;

                _customerType = value;

                if (_customerType == "Company") {
                    _customer.IsCompany = true;
                } else if (_customerType == "Person") {
                    _customer.IsCompany = false;
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
                if (_customerTypeOptions == null) {
                    _customerTypeOptions = new string[]
                    {
                        "NotSpecified",
                        "Person",
                        "Company"
                    };
                }
                return _customerTypeOptions;
            }
        }

        public override string DisplayName {
            get {
                if (this.IsNewCustomer) {
                    return "Display Name";
                } else if (_customer.IsCompany) {
                    return _customer.FirstName;
                } else {
                    return String.Format("{0}, {1}", _customer.LastName, _customer.FirstName);
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
            get {
                if (_saveCommand == null) {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        }

        #endregion // Presentation Properties

        #region public methods

        /// <summary>
        /// Saves the customer to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Save() {
            if (!_customer.IsValid)
                throw new InvalidOperationException("Customer is not valid");

            if (this.IsNewCustomer)
                _customerRepository.AddCustomer(_customer);

            base.OnPropertyChanged("DisplayName");
        }

                /// <summary>
        /// Returns true if the customer is valid and can be saved.
        /// </summary>
        bool CanSave {
            get { return String.IsNullOrEmpty(this.ValidateCustomerType()) && _customer.IsValid; }
        }

        #endregion public methods

        #region Private Helpers

        /// <summary>
        /// Returns true if this customer was created by the user and it has not yet
        /// been saved to the customer repository.
        /// </summary>
        bool IsNewCustomer {
            get { return !_customerRepository.ContainsCustomer(_customer); }
        }



        #endregion // Private Helpers

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error {
            get { return (_customer as IDataErrorInfo).Error; }
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
                    error = (_customer as IDataErrorInfo)[propertyName];
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
   
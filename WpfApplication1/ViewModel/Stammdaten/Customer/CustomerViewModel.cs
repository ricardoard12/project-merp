using System;
using System.ComponentModel;
using FrontEnd.DataAccess.Stammdaten.Customer;
using FrontEnd.DataAccess;
using System.Windows.Input;

namespace FrontEnd.ViewModel.Stammdaten.Customer {
    class CustomerViewModel : WorkspaceViewModel, IDataErrorInfo {
        #region Fields
        readonly Model.Stammdaten.CustomerModel _customerModel;
        readonly CustomerRepository _customerRepository;
        string _customerType;
        string[] _customerTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;

        #endregion Fields

        #region Constructors
        public CustomerViewModel(Model.Stammdaten.CustomerModel customerModel, CustomerRepository customerRepository) {
            if (customerModel == null)
                throw new ArgumentNullException("customerModel");

            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            _customerModel = customerModel;
            _customerRepository = customerRepository;
            _customerType = "NotSpecified";
        }

        #endregion Constructors

        #region Customer Properties
        public string Email {
            get { return _customerModel.Email; }
            set {
                if (value == _customerModel.Email)
                    return;

                _customerModel.Email = value;
                base.OnPropertyChanged("Email");
            }
        }

        public string FirstName {
            get { return _customerModel.FirstName; }
            set {
                if (value == _customerModel.FirstName)
                    return;

                _customerModel.FirstName = value;

                base.OnPropertyChanged("FirstName");
            }
        }

        public bool IsCompany {
            get { return _customerModel.IsCompany; }
        }

        public string LastName {
            get { return _customerModel.LastName; }
            set {
                if (value == _customerModel.LastName)
                    return;

                _customerModel.LastName = value;

                base.OnPropertyChanged("LastName");
            }
        }

        public double TotalSales {
            get { return _customerModel.TotalSales; }
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
                    _customerModel.IsCompany = true;
                } else if (_customerType == "Person") {
                    _customerModel.IsCompany = false;
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
                } else if (_customerModel.IsCompany) {
                    return _customerModel.FirstName;
                } else {
                    return String.Format("{0}, {1}", _customerModel.LastName, _customerModel.FirstName);
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
            if (!_customerModel.IsValid)
                throw new InvalidOperationException("Customer is not valid");

            if (this.IsNewCustomer)
                _customerRepository.AddCustomer(_customerModel);

            base.OnPropertyChanged("DisplayName");
        }

                /// <summary>
        /// Returns true if the customer is valid and can be saved.
        /// </summary>
        bool CanSave {
            get { return String.IsNullOrEmpty(this.ValidateCustomerType()) && _customerModel.IsValid; }
        }

        #endregion public methods

        #region Private Helpers

        /// <summary>
        /// Returns true if this customer was created by the user and it has not yet
        /// been saved to the customer repository.
        /// </summary>
        bool IsNewCustomer {
            get { return !_customerRepository.ContainsCustomer(_customerModel); }
        }



        #endregion // Private Helpers

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error {
            get { return (_customerModel as IDataErrorInfo).Error; }
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
                    error = (_customerModel as IDataErrorInfo)[propertyName];
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
   
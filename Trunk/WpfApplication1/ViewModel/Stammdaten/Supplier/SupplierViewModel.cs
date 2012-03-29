using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FrontEnd;
using FrontEnd.DataAccess.Stammdaten.User;
using FrontEnd.ViewModel;
using Views.Stammdaten.Supplier;
using Views.Stammdaten.User;
using WpfApplication1.DataAccess.Stammdaten.Supplier;

namespace WpfApplication1.ViewModel.Stammdaten.Supplier
{
    public class SupplierViewModel : WorkspaceViewModel, IDataErrorInfo 
    {
        private ISupplierRepository supplierRepository;
        private UserRepository userRepository;
        private ISupplierView supplierView;
        private ICommand saveCommand;
        private string supplierType;
        private string[] typeOptions;
        private bool isSelected;
        private ObservableCollection<IUserView> allUsers;
        private IUserView selectedUser;

        #region Constructors

        public SupplierViewModel()
        {
            this.supplierRepository = new SupplierRepository();
            this.supplierView = SupplierFactory.createNew();
            this.userRepository = new UserRepository();
            selectedUser = UserFactory.CreateNewUser();

        }

        #endregion Constructors


        #region Supplier Properties

        public string SupFirstname
        {
            get { return supplierView.SupFirstname; }
            set
            {
                if (value == supplierView.SupFirstname)
                    return;

                supplierView.SupFirstname = value;
                base.OnPropertyChanged("SupFirstname");
            }
        }

        public string SupLastname
        {
            get { return supplierView.SupLastname; }
            set
            {
                if (value == supplierView.SupLastname)
                    return;

                supplierView.SupLastname = value;
                base.OnPropertyChanged("SupLastname");
            }
        }

        public string SupContactname
        {
            get { return supplierView.SupContactname; }
            set
            {
                if (value == supplierView.SupContactname)
                    return;

                supplierView.SupContactname = value;
                base.OnPropertyChanged("SupContactname");
            }
        }

        public bool? SupIsCompany
        {
            get { return supplierView.SupIsCompany; }
        }

        public int SupId
        {
            get { return supplierView.SupId; }
        }

        public int? SupNumber
        {
            get { return supplierView.SupNumber; }
            set
            {
                if (value == supplierView.SupNumber)
                    return;

                supplierView.SupNumber = value;
                base.OnPropertyChanged("SupNumber");
            }
        }

        public int? SupUsrId
        {
            get { return supplierView.SupUsrId; }
            set
            {
                if (value == supplierView.SupUsrId)
                    return;

                supplierView.SupUsrId = value;
                base.OnPropertyChanged("SupUsrId");
            }
        }
        #endregion Supplier Properties

        #region Commands

        public ICommand SaveCommand
        {
            get 
            { 
                return saveCommand ?? (saveCommand = new RelayCommand(param => Save(), param=>  CanSave));
            } 
        }

        private void Save()
        {
            this.supplierRepository.AddSupplier(supplierView);
        }

        private bool CanSave
        {
            get { return supplierView.IsValid; }     
        }

        #endregion 


        #region Presentation Properties

        public string SupplierType
        {
            get { return supplierType; }
            set
            {
                if (value == supplierType || String.IsNullOrEmpty(value))
                    return;

                supplierType = value;

                if (supplierType == "Company")
                {
                    supplierView.SupIsCompany = true;
                }
                else if (supplierType == "Person")
                {
                    supplierView.SupIsCompany = false;
                }

                base.OnPropertyChanged("SupplierType");
                base.OnPropertyChanged("SupLastname");
            }
        }


        public IUserView SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (value == selectedUser || value == null)
                {
                    return;
                }
                selectedUser = value;
                supplierView.SupUsrId = selectedUser.UsrId;

                base.OnPropertyChanged("SelectedUser");
            }
        }

        public string[] SupplierTypeOptions
        {
            get
            {
                if (this.typeOptions == null)
                {
                    typeOptions = new string[]
                        {
                            "NotSpecified",
                            "Person",
                            "Company"
                        };
                }

                return typeOptions;
            }
          
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value == isSelected)
                    return;

                isSelected = value;
                base.OnPropertyChanged("IsSelected");
            }
        }

        public ObservableCollection<IUserView> AllUsers
        {
            get { return this.allUsers ?? (allUsers = new ObservableCollection<IUserView>(userRepository.GetAllUsers)); }
        } 

        #endregion Presentation Properties

        #region IDataErrors

        string IDataErrorInfo.Error
        {
            get { return (supplierView as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;

                if (propertyName == "SupplierType")
                {
                    // The IsCompany property of the Customer class 
                    // is Boolean, so it has no concept of being in
                    // an "unselected" state.  The CustomerViewModel
                    // class handles this mapping and validation.
                    error = this.ValidateSupplierType();
                }
                else
                {
                    error = (supplierView as IDataErrorInfo)[propertyName];
                }

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }

       

        string ValidateSupplierType()
        {
            if (this.SupplierType == "Company" ||
               this.SupplierType == "Person")
                return null;

            return "Supplier type must be selected";
        }

        #endregion 
    }
}

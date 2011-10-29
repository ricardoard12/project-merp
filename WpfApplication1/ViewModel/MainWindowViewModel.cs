using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using WpfApplication1.DataAccess;
using WpfApplication1.Model;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using WpfApplication1.ViewModel.Stammdaten.Customer;


namespace WpfApplication1.ViewModel {
    class MainWindowViewModel : WorkspaceViewModel {
        readonly CustomerRepository _customerRepository;
        ObservableCollection<CommandViewModel> _commands;
        ObservableCollection<WorkspaceViewModel> _workspaces;
        private ICommand _closeApplication;
  
        public MainWindowViewModel()
            : this("Data/customers.xml") {

        }

        public MainWindowViewModel(string customerDataFile) {
            base.DisplayName = "MainWindowViewModel.Display Name";
            _customerRepository = new CustomerRepository(customerDataFile);
            _commands = Commands;
            _workspaces = Workspaces;
        }

      
        public ICommand CloseApplication
        {
            get { return _closeApplication ?? (_closeApplication = new RelayCommand(OnCloseApplication)); }

        }

        private void OnCloseApplication(object obj)
        {
            if (App.Current.MainWindow != null)
                App.Current.MainWindow.Close();
        }

        public ObservableCollection<WorkspaceViewModel> Workspaces {
            get {
                if (_workspaces == null) {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspaceChanged;
                }
                return _workspaces;
            }

        }

        #region Commands

        public ObservableCollection<CommandViewModel> Commands {
            get {
                if (_commands == null) {
                    List<CommandViewModel> cmnds = this.CreateCommandsForNav();
                    _commands = new ObservableCollection<CommandViewModel>(cmnds);
                  
                }
                return _commands;
            }
        }

        List<CommandViewModel> CreateCommandsForNav() {
            return new List<CommandViewModel> {
                new CommandViewModel("Create New Customer" , new RelayCommand(param => this.CreateNewCustomer())),
                new CommandViewModel("Show All Customers" , new RelayCommand(param => this.ShowAllCustomers()))
            };
        }

        // Can only be one open ShowCustomerWorkspace
        void ShowAllCustomers() {
            AllCustomersViewModel workspace = 
                this.Workspaces.FirstOrDefault(vm => vm is AllCustomersViewModel)
                as AllCustomersViewModel;

            if (workspace == null) {
                workspace = new AllCustomersViewModel(_customerRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        void CreateNewCustomer() {
            Customer newCustomer = Customer.CreateNewCustomer();
            CustomerViewModel workspace = new CustomerViewModel(newCustomer, _customerRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace) {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion 

        void OnWorkspaceChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.NewItems != null && e.NewItems.Count > 0) 
               foreach (WorkspaceViewModel workspace in e.NewItems)
                   workspace.RequestClose += this.OnWorkspaceRequestClose;

             if (e.OldItems != null && e.OldItems.Count > 0) 
               foreach (WorkspaceViewModel workspace in e.OldItems)
                   workspace.RequestClose -= this.OnWorkspaceRequestClose;
                      
            }

        void OnWorkspaceRequestClose(object sender, EventArgs e) {
            this.Workspaces.Remove(sender as WorkspaceViewModel);
        }
    }
}

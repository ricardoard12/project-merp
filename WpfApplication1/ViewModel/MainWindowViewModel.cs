using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using WpfApplication1.DataAccess;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using WpfApplication1.Model.Stammdaten;
using WpfApplication1.Properties;
using WpfApplication1.ViewModel.NavCommands;
using WpfApplication1.ViewModel.Stammdaten.Customer;
using WpfApplication1.ViewModel.Stammdaten.Product;


namespace WpfApplication1.ViewModel {
    public class MainWindowViewModel : WorkspaceViewModel {
        protected readonly CustomerRepository _customerRepository;
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
                    List<CommandViewModel> cmnds = CreateCommandsForNav();
                    _commands = new ObservableCollection<CommandViewModel>(cmnds);
                }
                return _commands;
            }
        }

        protected List<CommandViewModel> CreateCommandsForNav() {
            return new List<CommandViewModel> {
                new CommandViewModel("Create New Customer" , new RelayCommand(param =>CreateNewCustomer()), Resources.StringStammdaten, Resources.StringCustomer),
                new CommandViewModel("Show All Customers" , new RelayCommand(param => ShowAllCustomers()), Resources.StringStammdaten, Resources.StringCustomer),
                new CommandViewModel("Show all Products", new RelayCommand(param =>ShowAllProducts()), Resources.StringStammdaten, Resources.StringProduct)
            };
        }

        protected void ShowAllProducts() {
            var workspace = new AllProductsViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);

        }

        // Can only be one open ShowCustomerWorkspace
        protected void ShowAllCustomers() {
            AllCustomersViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllCustomersViewModel)
                as AllCustomersViewModel;

            if (workspace == null) {
                workspace = new AllCustomersViewModel(_customerRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        protected void CreateNewCustomer() {
            CustomerModel newCustomerModel = CustomerModel.CreateNewCustomer();
            CustomerViewModel workspace = new CustomerViewModel(newCustomerModel, _customerRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        protected void SetActiveWorkspace(WorkspaceViewModel workspace) {
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using FrontEnd.DataAccess.Stammdaten.Customer;
using FrontEnd.Model.Stammdaten;
using FrontEnd.Properties;
using FrontEnd.ViewModel.Security;
using FrontEnd.ViewModel.Stammdaten.Customer;
using FrontEnd.ViewModel.Stammdaten.Product;
using FrontEnd.ViewModel.Stammdaten.User;
using FrontEnd.DataAccess;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using FrontEnd.ViewModel.NavCommands;
using WpfApplication1.Guis.Security;


namespace FrontEnd.ViewModel {


    public class MainWindowViewModel : WorkspaceViewModel {

        protected readonly CustomerRepository _customerRepository;
        ObservableCollection<CommandViewModel> _commands;
        ObservableCollection<WorkspaceViewModel> _workspaces;
        private ObservableCollection<TreeViewCommandCategory> _commandsTreeView;
  
        

      
        private ICommand _closeApplication;
  
        public MainWindowViewModel()
            : this("Data/customers.xml") {
        }
       
       
        public MainWindowViewModel(string customerDataFile) {
            base.DisplayName = "MainWindowViewModel.Display Name";
            _customerRepository = new CustomerRepository(customerDataFile);     
            _commands = CommandsForNav;
            _workspaces = Workspaces;
            DockVisibility = Visibility.Collapsed;
            LoginVisibility = Visibility.Visible;
           
        }

      
        public ICommand CloseApplication
        {
            get { return _closeApplication ?? (_closeApplication = new RelayCommand(OnCloseApplication)); }

        }

        private Visibility _guiVisibilety;
        private Visibility _dockVisibility;

        public Visibility DockVisibility {
            get { return _dockVisibility; }
            set {
                if (value != _dockVisibility) {
                    _dockVisibility = value;
                    OnPropertyChanged("DockVisibility");
                }
            }
        }

        public Visibility LoginVisibility {
            get { return _guiVisibilety; }
            set {
                if (value != _guiVisibilety) {
                    _guiVisibilety = value;
                    OnPropertyChanged("LoginVisibility");
                }

            }
        }

        private static void OnCloseApplication(object obj)
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
        public ObservableCollection<TreeViewCommandCategory> CommandsTreeView {
            get {
                if (_commandsTreeView == null)
                     _commandsTreeView = new ObservableCollection<TreeViewCommandCategory>();
                     CreateCommandsForTree();
                return _commandsTreeView;

            }
        }

        private void CreateCommandsForTree() {
            TreeViewCommandCategory Customers = new TreeViewCommandCategory(Resources.StringCustomer) {
                                                        Commands =
                                                                                                              new List
                                                                                                              <
                                                                                                              CommandViewModel
                                                                                                              >(
                                                                                                              CommandsForNav
                                                                                                                  .Where
                                                                                                                  (c =>
                                                                                                                   c.
                                                                                                                       Hirarchi2 ==
                                                                                                                   Resources
                                                                                                                       .
                                                                                                                       StringCustomer))
                                                                                                      };
            TreeViewCommandCategory Products = new TreeViewCommandCategory(Resources.StringProduct) {
                    Commands = new List<CommandViewModel>(CommandsForNav.Where(c => c.Hirarchi2 == Resources.StringProduct))
                                                                                                    };
            TreeViewCommandCategory Users = new TreeViewCommandCategory(Resources.StringUsers) {
                Commands = new List<CommandViewModel>(CommandsForNav.Where(c => c.Hirarchi2 == Resources.StringUsers))
            };

            _commandsTreeView.Add(Customers);
            _commandsTreeView.Add(Products);
            _commandsTreeView.Add(Users);
        
        }


        public ObservableCollection<CommandViewModel> CommandsForNav {
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
                new CommandViewModel("Show all Products", new RelayCommand(param =>ShowAllProducts()), Resources.StringStammdaten, Resources.StringProduct),
                new CommandViewModel("Show all Users", new RelayCommand(param => ShowAllUsers()), Resources.StringStammdaten, Resources.StringUsers )
            };
        }

        protected void ShowAllUsers() {
            var workspace = new AllUsersViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
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

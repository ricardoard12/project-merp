﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using FrontEnd.DataAccess.Stammdaten.Customer;
using FrontEnd.Model.Stammdaten;
using FrontEnd.ViewModel.Stammdaten.Customer;
using FrontEnd.ViewModel.Stammdaten.Product;
using FrontEnd.ViewModel.Stammdaten.User;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using FrontEnd.ViewModel.NavCommands;
using Views;
using WpfApplication1;
using WpfApplication1.DI;
using WpfApplication1.Events;
using WpfApplication1.Properties;
using WpfApplication1.ViewModel.BusinessProcesses.Distribution;
using WpfApplication1.ViewModel.BusinessProcesses.Purchase;
using WpfApplication1.ViewModel.Security;
using WpfApplication1.ViewModel.Stammdaten.Supplier;
using bbv.Common.EventBroker;
using bbv.Common.EventBroker.Handlers;
using WpfApplication1.ViewModel.BusinessProcesses.Sales.Offer;
using WpfApplication1.ViewModel.BusinessProcesses.Sales.Order;


namespace FrontEnd.ViewModel {


    public class MainWindowViewModel : WorkspaceViewModel {

        protected readonly CustomerRepositoryOld _customerRepository;
        ObservableCollection<CommandViewModel> _commands;
        ObservableCollection<IWorkspaceViewModel> _workspaces;
        private ObservableCollection<TreeViewCommandCategory> _commandsTreeView;
        private ILoginViewModel _loginViewModel;
        private Visibility _vsbDirectory;
        private EventBroker _eventBroker;
        private ICommand _closeApplication;


        public MainWindowViewModel()
            : this("Data/customers.xml") {
        }
       
       
        public MainWindowViewModel(string customerDataFile) {
            base.DisplayName = "MainWindowViewModel.Display Name";
            VsbDirectory = Visibility.Hidden;
            _eventBroker = Session.EventBroker();
            _eventBroker.Register(this);
     this._customerRepository = new CustomerRepositoryOld(customerDataFile);
          
            _commands = CommandsForNav;
            _workspaces = Workspaces;
            InitializeLogin();
           

        }

        private void InitializeLogin()
        {
            _loginViewModel = DIContainer.GetClientLibrarie<ILoginViewModel>();
            this.Workspaces.Add(_loginViewModel);
            this.SetActiveWorkspace(_loginViewModel);
        }


        [EventSubscription("topic://OnLoginExecuted", typeof(Publisher))]
        public void OnLoginExecuted(object sender, BooleanEventArg e) {
            if (e.BooleanValue) {
                Workspaces.Remove(_loginViewModel);
                VsbDirectory = Visibility.Visible;
                
            }
            else {
                MessageBox.Show("Wrong password");
            }
        }

      
        public ICommand CloseApplication
        {
            get { return _closeApplication ?? (_closeApplication = new RelayCommand(OnCloseApplication)); }

        }

        private static void OnCloseApplication(object obj)
        {
            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.Close();
        }

        public ObservableCollection<IWorkspaceViewModel> Workspaces {
            get {
                if (_workspaces == null) {
                    _workspaces = new ObservableCollection<IWorkspaceViewModel>();
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

        private void CreateCommandsForTree()
        {
            TreeViewCommandCategory Customers = new TreeViewCommandCategory(Resources.StringCustomer)
                                                    {
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
            TreeViewCommandCategory Products = new TreeViewCommandCategory(Resources.StringProduct)
                                                   {
                                                       Commands =
                                                           new List<CommandViewModel>(
                                                           CommandsForNav.Where(
                                                               c => c.Hirarchi2 == Resources.StringProduct))
                                                   };
            TreeViewCommandCategory Users = new TreeViewCommandCategory(Resources.StringUsers)
                                                {
                                                    Commands =
                                                        new List<CommandViewModel>(
                                                        CommandsForNav.Where(c => c.Hirarchi2 == Resources.StringUsers))
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

        public Visibility VsbDirectory {
            get { return _vsbDirectory; }
            set {
                _vsbDirectory = value;
                OnPropertyChanged("VsbDirectory");
            }
        }

        protected List<CommandViewModel> CreateCommandsForNav() {
            return new List<CommandViewModel> {
                new CommandViewModel("Create New Customer" , new RelayCommand(param =>CreateGuiByOnce(new CustomerViewModel())), Resources.StringStammdaten, Resources.StringCustomer),
                new CommandViewModel("Show All Customers" , new RelayCommand(param => CreateGuiByOnce(new AllCustomersViewModel())), Resources.StringStammdaten, Resources.StringCustomer),
                new CommandViewModel("Show all Products", new RelayCommand(param => CreateGuiAndSetActive(new AllProductsViewModel())), Resources.StringStammdaten, Resources.StringProduct),
                new CommandViewModel("Show all Users", new RelayCommand(param => CreateGuiAndSetActive(new AllUsersViewModel())), Resources.StringStammdaten, Resources.StringUsers ),
                new CommandViewModel("Create New Product", new RelayCommand(param => CreateGuiAndSetActive(new ProductViewModel())), Resources.StringStammdaten, Resources.StringProduct),
                new CommandViewModel("Create Supplier", new RelayCommand(param => CreateGuiAndSetActive(new SupplierViewModel())), Resources.StringStammdaten, Resources.StringSupplier  ),
                new CommandViewModel("All Supplier", new RelayCommand(param => CreateGuiAndSetActive(new AllSupplierViewModel())), Resources.StringStammdaten, Resources.StringSupplier  ),
                new CommandViewModel("Create Order", new RelayCommand(param => CreateGuiAndSetActive(new OrderViewModel())), Resources.StringBusinessProcesses, Resources.StringOrder  ),
                new CommandViewModel("All Distribution", new RelayCommand(param => CreateGuiAndSetActive(new AllDistributionViewModel())), Resources.StringBusinessProcesses, Resources.StringDistribution  ),
                new CommandViewModel("Create Distribution", new RelayCommand(param => CreateGuiAndSetActive(new DistributionViewModel())), Resources.StringBusinessProcesses, Resources.StringDistribution  ),
                new CommandViewModel("All Purchase", new RelayCommand(param => CreateGuiAndSetActive(new AllPurchaseHeaderViewModel())), Resources.StringBusinessProcesses, Resources.StringPurchase  ),
                new CommandViewModel("Create Purchase", new RelayCommand(param => CreateGuiAndSetActive(new PurchaseHeaderViewModel())), Resources.StringBusinessProcesses, Resources.StringPurchase  ),
                new CommandViewModel("All Offer", new RelayCommand(param => CreateGuiAndSetActive(new AllOfferViewModel())), Resources.StringBusinessProcesses, Resources.StringOffer  ),
                new CommandViewModel("Create Offer", new RelayCommand(param => CreateGuiAndSetActive(new OfferViewModel())), Resources.StringBusinessProcesses, Resources.StringOffer  )
            };
        }

        private void CreateGuiAndSetActive(IWorkspaceViewModel viewModel)
        {
            Workspaces.Add(viewModel);
            SetActiveWorkspace(viewModel);
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
                workspace = new AllCustomersViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        void CreateGuiByOnce(IWorkspaceViewModel workspace)
        {
            //  WorkspaceViewModel viewModel = Workspaces.FirstOrDefault(vm => vm is workspace)
            IWorkspaceViewModel viewModelExists = null;

            foreach (var eachWorkspace in Workspaces.Where(eachWorkspace => eachWorkspace.GetType() == workspace.GetType())) {
                viewModelExists = eachWorkspace;
            }

            if (viewModelExists == null) {
                CreateGuiAndSetActive(workspace);
            }

        }

        protected void CreateNewCustomer() {
            CustomerModel newCustomerModel = CustomerModel.CreateNewCustomer();
            CustomerViewModel workspace = new CustomerViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        protected void SetActiveWorkspace(IWorkspaceViewModel workspace)
        {
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

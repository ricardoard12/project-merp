using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FrontEnd.Properties;
using FrontEnd.Model.Stammdaten;
using FrontEnd.ViewModel.Stammdaten.Customer;
using FrontEnd.ViewModel.Stammdaten.Product;

namespace FrontEnd.ViewModel.NavCommands {
    public class TreeViewCommands : MainWindowViewModel
    {
   
        private ObservableCollection<CommandViewModel> _stufe1;
        private ObservableCollection<CommandViewModel> _stufe2;
        private ObservableCollection<CommandViewModel> _produkte;
        private ObservableCollection<CommandViewModel> _customer; 
 

        public ObservableCollection<CommandViewModel> Stufe1
        {
            get
            {
                if (_stufe1 == null || _stufe1.Count == 0)
                {
                    _stufe1 = new ObservableCollection<CommandViewModel>();
                    foreach (var u in CommandsStammdaten)
                    {

                        _stufe1.Add(u);
                    }
                    
                }
                return _stufe1;
            }
        } 
        
        public ObservableCollection<CommandViewModel> Stufe2
        {
            get
            {
                if (_stufe2 == null || _stufe2.Count == 0)
                {

                    _stufe2 = new ObservableCollection<CommandViewModel>();
                    foreach (var u in CommandsProducts)
                    {
                        _stufe2.Add(u);
                    }
                    foreach (var u in CommandsCustomer)
                    {
                        _stufe2.Add(u);
                    }

                }
                return _stufe2;
            }
        } 
        
        public ObservableCollection<CommandViewModel> CommandsStammdaten {
            get { return CommandsSelectedByHeader1(Resources.StringStammdaten); }
        }


        public ObservableCollection<CommandViewModel> CommandsProducts
        {
            get
            {
                if (_produkte == null)
                    _produkte = new ObservableCollection<CommandViewModel>();
                    foreach (CommandViewModel p in CommandsSelectedByHeader2(Resources.StringProduct)) {
                        _produkte.Add(p);
                    }
                return _produkte;
            }
        }

          public ObservableCollection<CommandViewModel> CommandsCustomer
        {
            get
            {
                if (_customer == null)
                    _customer = new ObservableCollection<CommandViewModel>();
                    foreach (var c in CommandsSelectedByHeader2(Resources.StringCustomer))
                    {
                        _customer.Add(c);
                    }
                return _customer;
            }
        }

        private ObservableCollection<CommandViewModel> CommandsSelectedByHeader1(string header) {
            return new ObservableCollection<CommandViewModel>(
                from c in Commands where c.Hirarchi1 == header select c
                );

        }

        private ObservableCollection<CommandViewModel> CommandsSelectedByHeader2(string header)
        {
            return new ObservableCollection<CommandViewModel>(
                from c in Commands where c.Hirarchi2 == header select c
                );
        }
    }
}

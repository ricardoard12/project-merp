using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FrontEnd.Properties;
using FrontEnd.Model.Stammdaten;
using FrontEnd.ViewModel.Stammdaten.Customer;
using FrontEnd.ViewModel.Stammdaten.Product;

namespace FrontEnd.ViewModel.NavCommands {
    public class TreeViewCommandCategory : MainWindowViewModel
    {
        public string Name { get; set; }
        public List<CommandViewModel> Commands { get; set; }

        public TreeViewCommandCategory(string name) {
            Name = name;
        }
    }
}

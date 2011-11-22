using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using FrontEnd.ViewModel;

namespace FrontEnd {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public void InitializeComonents() {
            MainWindowViewModel mm = new MainWindowViewModel();
            this.StartupUri = new Uri("Guis/Security/LoginWindow.xaml", UriKind.Relative);
            
        }
        
    }
}

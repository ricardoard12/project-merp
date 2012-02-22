using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using FrontEnd.ViewModel;
using WpfApplication1;
using WpfApplication1.DI;

namespace FrontEnd {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private DIContainer _container; 
        

        public App() {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _container = new DIContainer(true);
            MainWindow mainWindow = DIContainer.GetClientLibrarie<MainWindow>();
            mainWindow.Show();
        }
        
    }
}

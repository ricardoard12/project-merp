using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WpfApplication1.ViewModel;

namespace WpfApplication1 {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            MainWindow window = new MainWindow();

            //Create the ViewModel to wich 
            // the main window binds. 
            string path = "Data/customers.xml";
            var viewModel = new MainWindowViewModel(path);

            // When the ViewModel ask to be close, 
            // close the window 
            EventHandler handler = null;


            viewModel.RequestClose += handler;

            handler = delegate {
                viewModel.RequestClose -= handler;
                window.Close();
            };

            //Allow all controls in the window to 
            // bind to the ViewModel by setting the
            // DataContext, wich propagates down 
            // the element tree
            window.DataContext = viewModel;
            window.Show();
            base.OnStartup(e);
     
         

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.DI;
using WpfApplication1.ViewModel.Security;

namespace FrontEnd.Guis.Security {
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl {
        public Login()
        {
            this.DataContext = DIContainer.GetClientLibrarie<ILoginViewModel>();
            InitializeComponent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BL.Service;
using FrontEnd.DataAccess.Stammdaten.User;
using Views;
using Views.Security.Connection;
using FrontEnd.Data.Channel;

namespace FrontEnd.ViewModel.Security {
    public delegate void LoginExecute();

    public class LoginViewModel : WorkspaceViewModel
    {
        public event EventHandler OnLoginExecuted;
        private UserRepository _userRepository;
        private MainWindow _mainWindow;
        //private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();


        public LoginViewModel() {
            _userRepository = new UserRepository();
            _mainWindow = new MainWindow();
            Application.Current.MainWindow = _mainWindow;
            Application.Current.MainWindow.Activate();

        }

        private ICommand _login;
   
        private string _username;

        

        public ICommand Login {
            get {
                return _login ??
                       (_login = new RelayCommand((passwordBox) => OnLoginExecute(passwordBox),
                                        (passwordBox) => CanLoginExecute()));
            }
        }

        private bool CanLoginExecute() {
            return Username != null;
        }

        public void OnLoginExecute(object password) {
            var passwordbox = password as PasswordBox;
            if (passwordbox != null)
            Session.Password = passwordbox.Password;
            Session.Username = Username;
           try {
               if (_userRepository.TestConnection) {
                   Application.Current.MainWindow.Show();
                   //_mainWindowViewModel.LoginVisibility = Visibility.Collapsed;
                   //_mainWindowViewModel.DockVisibility = Visibility.Visible;
               }
           }
        catch(MessageSecurityException fe) {
            
            MessageBox.Show((fe.InnerException as FaultException).Reason.ToString());
        }
                
        }

        public string Username{ 
            get { return _username; }
            set {
                if (_username != value)
                    _username = value;
                OnPropertyChanged("Username");
            }
        }

        
    }

}

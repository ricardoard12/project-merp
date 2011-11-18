using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BL.Service;
using Views.Security.Connection;
using WpfApplication1.Data.Channel;

namespace WpfApplication1.ViewModel.Security {
    public class LoginViewModel : WorkspaceViewModel
    {

        private IMERPService _merpService;

        public LoginViewModel() {
         
            
            GuiVisibilety = Visibility.Visible;
        }

        private ICommand _login;
   
        private string _username;
        private Visibility _guivisibilety;

        public Visibility GuiVisibilety {
            get { return _guivisibilety; }
            set { _guivisibilety = value; }
        }

        public ICommand Login {
            get {
                return _login ??
                       new RelayCommand((passwordBox) => OnLoginExecute(passwordBox),
                                        (passwordBox) => CanLoginExecute());
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
            
         
           
            GuiVisibilety = Visibility.Collapsed;
        }

        public string Username {
            get { return _username; }
            set {
                if (_username != value)
                    _username = value;
                OnPropertyChanged("Username");
            }
        }

        
    }

}

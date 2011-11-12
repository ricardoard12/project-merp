using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApplication1.Data.Channel;

namespace WpfApplication1.ViewModel.Security {
    public class LoginViewModel : WorkspaceViewModel
    {
        public delegate void LoginExecute();
        public event LoginExecute OnLoginExecuted;

        public LoginViewModel() {
            GuiVisibilety = Visibility.Visible;
        }

        private ICommand _login;
        private string _password;
        private string _username;
        private Visibility _guivisibilety;

        public Visibility GuiVisibilety {
            get { return _guivisibilety; }
            set { _guivisibilety = value; }
        }

        public ICommand Login {
            get {
                return _login ??
                       new RelayCommand((param) => OnLoginExecute(Username, Password),
                                        (param) => CanLoginExecute(Username, Password));
            }
        }

        private bool CanLoginExecute(string username, string password) {
            return Username != null && Password != null;
        }

        public void OnLoginExecute(string username, string password) {
            Session.Password = password;
            Session.Username = username;
            OnLoginExecuted();
            GuiVisibilety = Visibility.Collapsed;
        }

        public string Username {
            get { return _username; }
            set {
                if (_username != null && _username != value)
                    _username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password {
            get { return _password; }
            set {
                if (_password != null && _password != value)
                    _password = value;
                OnPropertyChanged("Password");
            }

        }


    }

}

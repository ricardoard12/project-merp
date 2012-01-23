using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FrontEnd.DataAccess.Stammdaten.User;
using Views;
using WpfApplication1.Events;

namespace FrontEnd.ViewModel.Security {
  

    public class LoginViewModel : WorkspaceViewModel
    {
        public static event EventHandler<BooleanEventArg> OnLoginExecuted;
        private UserRepository _userRepository;
        private ICommand _login;
        private string _username;



        public LoginViewModel() {
            _userRepository = new UserRepository();
        }

        
        

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
                    if (OnLoginExecuted != null) {
                        OnLoginExecuted(this, new BooleanEventArg(true));
                    }
                }
                else {
                    if (OnLoginExecuted != null) {
                        OnLoginExecuted(this, new BooleanEventArg(false));
                    }
                }

            } catch (MessageSecurityException fe) {

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

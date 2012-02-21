using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FrontEnd.DataAccess.Stammdaten.User;
using Views;
using WpfApplication1.Events;
using WpfApplication1.ViewModel.Security;
using bbv.Common.EventBroker;
using bbv.Common.EventBroker.Handlers;

namespace FrontEnd.ViewModel.Security {


    public class LoginViewModel : WorkspaceViewModel , ILoginViewModel
    {
        private readonly EventBroker _eventBroker;

        [EventPublication("topic://OnLoginExecuted")]
        public event EventHandler<BooleanEventArg> OnLoginExecuted;
        
        private readonly UserRepository _userRepository;
        private ICommand _login;
        private string _username;



        public LoginViewModel() {
            _userRepository = new UserRepository();
            _eventBroker = Session.EventBroker();
            _eventBroker.Register(this);
        }


        public LoginViewModel(bool isGui) {
            _userRepository = new UserRepository();

        }

        public ICommand Login {
            get {
                return _login ??
                       (_login = new RelayCommand((passwordBox) => OnLoginExecute(passwordBox),
                                        (passwordBox) => CanLoginExecute()));
            }
        }

        public bool CanLoginExecute() {
            return Username != null;
        }

        public void OnLoginExecute(object password) {
            var passwordbox = password as PasswordBox;
            if (passwordbox != null)
            Session.Password = passwordbox.Password;
            Session.Username = Username;
            var handler = this.OnLoginExecuted;
            try {
                if (_userRepository.TestConnection) {
                    if (handler != null)
                        handler(this, new BooleanEventArg(true));
                }
                else {
                    if (OnLoginExecuted != null)
                    OnLoginExecuted(this, new BooleanEventArg(false));
                }

            } catch (MessageSecurityException fe) {
                var faultException = fe.InnerException as FaultException;
                if (faultException != null)
                    MessageBox.Show(faultException.Reason.ToString());
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

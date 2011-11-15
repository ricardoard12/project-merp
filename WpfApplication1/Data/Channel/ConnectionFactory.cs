using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using BL.Service;
using BL.Service.Stammdaten.User;
using WpfApplication1.ViewModel.Security;

namespace WpfApplication1.Data.Channel
{
    public class ConnectionFactory<T>
    {
       

        readonly LoginViewModel _loginViewModel = new LoginViewModel();
        
        
        private ChannelFactory<T> _connectionFactory;
        private readonly EndpointAddress _endpointAddress;
        

        public ConnectionFactory(string endpointAddress) {
            _endpointAddress = new EndpointAddress(new Uri(endpointAddress),
                                                   EndpointIdentity.CreateDnsIdentity("SimiPro2"));
            _loginViewModel.OnLoginExecuted += LoginExecuted;
        }

  

        public ChannelFactory<T> Factory {
            get {
                if ( _connectionFactory == null) {

                    _connectionFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode =
                        X509CertificateValidationMode.None;
                    _connectionFactory.Credentials.ServiceCertificate.Authentication.RevocationMode =
                        X509RevocationMode.NoCheck;
                    _connectionFactory = new ChannelFactory<T>(new NetTcpBinding(), _endpointAddress);
                }
                return _connectionFactory;
            }
        }

        public T GetConnectionToService {
            get { return Factory.CreateChannel(); }
        }

        public string Username{
            get {
                if (Factory.Credentials != null)
                    return Factory.Credentials.UserName.UserName;
                throw new CommunicationException("setUsername");
            }
            set { if (Factory.Credentials != null) Factory.Credentials.UserName.UserName = value; }
        }

        public string Password {
            get {
                if (Factory.Credentials != null)
                    return Factory.Credentials.UserName.Password;
                throw new CommunicationException("setPassword");
            }
            set { if (Factory.Credentials != null) Factory.Credentials.UserName.Password = value; }
        }

        private void LoginExecuted() {
            Password =  Session.Password;
            Username =  Session.Username;
            
        }



   
    }
}

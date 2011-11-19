using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.IdentityModel.Claims;




namespace Views.Security.Connection {
    public class Connection<T> : IConnection<T>
    {
       private ChannelFactory<T> _channelFactory;

       public ChannelFactory<T> ChannelFactory {
           get { return _channelFactory; }
           set {
                if (value != null && value != _channelFactory)
                    _channelFactory = value;
               if (Session.Password == null || Session.Username == null)
                   throw new Exception("Kein Username oder Passwort angegeben");
                if (_channelFactory.Credentials != null) {
                    _channelFactory.Credentials.UserName.UserName = Session.Username;
                    _channelFactory.Credentials.UserName.Password = Session.Password;
                    _channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode =
                        X509CertificateValidationMode.None;
                    _channelFactory.Credentials.ServiceCertificate.Authentication.RevocationMode =
                        X509RevocationMode.NoCheck;
                   _channelFactory.Endpoint.Address = new EndpointAddress(new Uri(_channelFactory.Endpoint.Address.ToString()), new DnsEndpointIdentity("SimiPro2"));
                }
            }
      }

     
        public T CreateService { 
            get {
               return ChannelFactory.CreateChannel();
            }
        }

    
    }


       
}

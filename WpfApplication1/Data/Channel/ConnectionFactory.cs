using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using BL.Service;
using BL.Service.Stammdaten.User;
using Views.Security.Connection;
using FrontEnd.ViewModel.Security;

namespace FrontEnd.Data.Channel
{
    public class ConnectionFactory<T>
    {
        private static List<IConnection<T>> _services = new List<IConnection<T>>();
    
        public static IConnection<T> CreateConnection(string serviceName, string endpointadress) {
           return new Connection<T> {
               ChannelFactory = new ChannelFactory<T>(serviceName , new EndpointAddress(endpointadress))
                                     };
        }

    }
}

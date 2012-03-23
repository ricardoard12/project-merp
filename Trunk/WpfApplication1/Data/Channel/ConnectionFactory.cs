using System.Collections.Generic;
using System.ServiceModel;
using Views;
using Views.Security.Connection;

namespace FrontEnd.Data.Channel
{
    public class ConnectionFactory<T>
    {
        public static List<IConnection<T>> AllServices = new List<IConnection<T>>();
    
        public static IConnection<T> CreateConnection(string serviceName, string endpointadress) {
           IConnection<T> connection = new Connection<T> {
               ChannelFactory = new ChannelFactory<T>(serviceName , new EndpointAddress(endpointadress))
                                     };
           if (connection.ChannelFactory.Credentials != null) {
               connection.ChannelFactory.Credentials.UserName.UserName = Session.Username;
               connection.ChannelFactory.Credentials.UserName.Password = Session.Password;
           }
            AllServices.Add(connection);
            return connection;
        }



    }
}

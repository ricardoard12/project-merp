using System.ServiceModel;
using FrontEnd.Data.Channel;
using Views;
using Views.Security.Connection;

namespace WpfApplication1.DataAccess
{
    public class Repository<TService> : IRepository<TService>
    {
        private IConnection<TService> _connection;

        public IConnection<TService> Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection =
                        ConnectionFactory<TService>.CreateConnection("ProductService",
                                                                     "net.tcp://localhost:2526/Service/Stammdaten/Product");
                }
                if (_connection.ChannelFactory.Credentials != null)
                {
                    _connection.ChannelFactory.Credentials.UserName.UserName = Session.Username;
                    _connection.ChannelFactory.Credentials.UserName.Password = Session.Password;
                }
                if (_connection.ChannelFactory.State != CommunicationState.Opened)
                    _connection.ChannelFactory.Open();
                return _connection;
            }
        }
    }
}


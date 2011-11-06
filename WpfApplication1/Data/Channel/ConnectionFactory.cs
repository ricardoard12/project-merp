using System.ServiceModel;
using BL.Service;
using BL.Service.Stammdaten.User;

namespace WpfApplication1.Data.Channel
{
    public class ConnectionFactory<T>
    {
        
        private ChannelFactory<T> _connectionFactory;
        private readonly EndpointAddress _endpointAddress;

        public ConnectionFactory(string endpointAddress) {
            _endpointAddress = new EndpointAddress(endpointAddress);
        }



        public ChannelFactory<T> Factory {
            get {
                return _connectionFactory ??
                       (_connectionFactory = new ChannelFactory<T>(new NetTcpBinding(), _endpointAddress));
            }
        }

        public T GetConnectionToService() {
            return Factory.CreateChannel();
        }


    }
}

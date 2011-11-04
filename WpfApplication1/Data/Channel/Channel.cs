using System.ServiceModel;
using BL.Service;

namespace WpfApplication1.Data.Channel {
    public class Channel
    {
        private static IMERPService _serviceConnection;
        private static ChannelFactory<IMERPService> _channelFactory;

        public static ChannelFactory<IMERPService> ChannelFactoryTunnelToBlService
        {
            get
            {
                return _channelFactory ?? (_channelFactory = new ChannelFactory<IMERPService>(new NetTcpBinding(),
                                                                                              new EndpointAddress(
                                                                                         "net.tcp://localhost:2526/Service/")));
            }
        }

        public static IMERPService ConnectionToBl
        {
            get { return _serviceConnection ?? (_serviceConnection = ChannelFactoryTunnelToBlService.CreateChannel()); }
        }

     
    }
}

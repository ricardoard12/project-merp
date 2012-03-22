using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Views.Security.Connection {
    public interface IConnection<T> {


        ChannelFactory<T> ChannelFactory { get; set; }
        T CreateService { get; }
        

    }
}

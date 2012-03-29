using System.Collections.Generic;
using System.ServiceModel;
using FrontEnd.Data.Channel;
using FrontEnd.DataAccess.Stammdaten.Customer;
using Views;
using Views.Security.Connection;
using Views.Stammdaten;
using Views.Stammdaten.Customer;
using Views.Stammdaten.Product;

namespace WpfApplication1.DataAccess.Stammdaten.Customer
{
    public class CustomerRepository : ICustomerService
    {
        private IConnection<ICustomerService> _customerConnection;
        private ICustomerService _service;

        public IConnection<ICustomerService> Connection
        {
            get
            {
                if (_customerConnection == null)
                {
                    _customerConnection =
                    ConnectionFactory<ICustomerService>.CreateConnection("CustomerService",
                                                                           "net.tcp://10.12.10.150:2526/Service/CustomerService");
                }
                if (_customerConnection.ChannelFactory.Credentials != null)
                {
                    _customerConnection.ChannelFactory.Credentials.UserName.UserName = Session.Username;
                    _customerConnection.ChannelFactory.Credentials.UserName.Password = Session.Password;
                }
                if (_customerConnection.ChannelFactory.State != CommunicationState.Opened)
                    _customerConnection.ChannelFactory.Open();
                return _customerConnection;
            }
        }

        public void AddCustomer(ICustomerView customer)
        {
            Service.AddCustomer(customer);
        }

        public IList<ICustomerView> AllCustomers()
        {
            return Service.AllCustomers();
        }

        public ICustomerView GetCustomerByPrimaryKey(int primaryKey)
        {
            return Service.GetCustomerByPrimaryKey(primaryKey);
        }

        public ICustomerService Service
        {
            get { return _service ?? (_service = Connection.CreateService); } 
        }
    }
}
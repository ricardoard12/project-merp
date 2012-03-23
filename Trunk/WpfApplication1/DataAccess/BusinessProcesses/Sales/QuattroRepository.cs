using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Sales;
using System.ServiceModel;
using FrontEnd.Data.Channel;
using Views;
using Views.BusinessProcesses.Sales.Offer;
using Views.Security.Connection;
using Views.BusinessProcesses.Sales.Order;
using Views.Stammdaten.Supplier;


namespace WpfApplication1.DataAccess.BusinessProcesses.Sales
{
    class QuattroRepository : IQuattroRepository
    {
        private IConnection<IQuattroService> quattroServiceConnection;
        private IQuattroService quattroService;
        private ISalesHeaderView salesHeaderView; 
        
        public QuattroRepository()
        {
            salesHeaderView = SalesFactory.createNew();
        }

        public IConnection<IQuattroService> Connection
        {
            get
            {
                if (quattroServiceConnection == null)
                {
                    quattroServiceConnection =
                    ConnectionFactory<IQuattroService>.CreateConnection("QuattroService",
                                                                           "net.tcp://10.12.10.150:2526/Service/BusinessProcesses/Sales");
                }
                if (quattroServiceConnection.ChannelFactory.Credentials != null)
                {
                    quattroServiceConnection.ChannelFactory.Credentials.UserName.UserName = Session.Username;
                    quattroServiceConnection.ChannelFactory.Credentials.UserName.Password = Session.Password;
                }
                if (quattroServiceConnection.ChannelFactory.State != CommunicationState.Opened)
                    quattroServiceConnection.ChannelFactory.Open();
                return quattroServiceConnection;
            }
        }

        public IQuattroService Service
        {
            get { return quattroService ?? (quattroService = Connection.ChannelFactory.CreateChannel()); }
        }

        public void AddOrder(ISalesHeaderView salesHeaderView)
        {
            Service.AddQuattro(salesHeaderView);
        }

        public IList<ISalesHeaderView> AllQuattros()
        {
            PagedResult<ISalesHeaderView> resultSet = Service.AllQuattros();
            return resultSet.Rows.ToList();
        }

        public void AddQuattro(IOrderView view)
        {
            Service.AddQuattro(view);
        }

        public void AddPosition(ISalesItem item)
        {
            Service.AddSalesPosition(item);
        }

        /*
        public IList<IOrderView> GetAllOrders()
        {
            PagedResult<IOrderView> resultSet = Service.AllOrder();
             return resultSet.Rows.ToList();
        }
        */
        
        /*
        public void DeleteOrder(IOrderView order)
        {
            Service.DeleteOrder(order);
        }
        */

        /*
        public void UpdateQuattro(IOrderView order)
        {
            Service.UpdateQuattro(order);
        }
        */

        /*
        public IOrderView GetOrderByPrimaryKey(int primaryKey)
        {
          return Service.OrderByPrimaryKey(primaryKey);
        }
        */

        /*
        public IOrderview ByPrimaryKey()
        {
            throw new NotImplementedException();
        }
        */
    }
}

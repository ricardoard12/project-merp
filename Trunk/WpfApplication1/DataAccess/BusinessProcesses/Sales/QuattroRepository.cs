using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Sales;
using System.ServiceModel;
using FrontEnd.Data.Channel;
using Views;
using Views.Security.Connection;
using Views.BusinessProcesses.Sales.Order;


namespace WpfApplication1.DataAccess.BusinessProcesses.Sales
{
    class QuattroRepository : IQuattroRepository
    {
        private IConnection<IQuattroService> quattroServiceConnection;
        private IQuattroService quattroService;
        private IOrderView orderpublic; 
        
        public QuattroRepository()
        {
            order = OrderFactory.createNew();
        }

        public IConnection<IQuattroService> Connection
        {
            get
            {
                if (quattroServiceConnection == null)
                {
                    supplierServiceConnection =
                    ConnectionFactory<ISupplierService>.CreateConnection("SupplierService",
                                                                           "net.tcp://10.12.10.150:2526/Service/Stammdaten/Supplier");
                }
                if (supplierServiceConnection.ChannelFactory.Credentials != null)
                {
                    supplierServiceConnection.ChannelFactory.Credentials.UserName.UserName = Session.Username;
                    supplierServiceConnection.ChannelFactory.Credentials.UserName.Password = Session.Password;
                }
                if (supplierServiceConnection.ChannelFactory.State != CommunicationState.Opened)
                    supplierServiceConnection.ChannelFactory.Open();
                return supplierServiceConnection;
            }
        }

        public ISupplierService Service
        {
            get { return quattroService ?? (quattroService = Connection.ChannelFactory.CreateChannel()); }
        }


        public void AddSupplier(ISupplierView supplier)
        {
            Service.AddSupplier(supplier);
        }

        public IList<ISupplierView> GetAllSuppliers()
        {
            PagedResult<ISupplierView> resultSet = Service.AllSupplier();
             return resultSet.Rows.ToList();
        }

        public void DeleteSupplier(ISupplierView supplier)
        {
            Service.DeleteSupplier(supplier);
        }

        public void UpdateSupplier(ISupplierView supplier)
        {
            Service.UpdateSupplier(supplier);
        }

        public ISupplierView GetSupplierByPrimaryKey(int primaryKey)
        {
          return Service.SupplierByPrimaryKey(primaryKey);
        }

    }
}

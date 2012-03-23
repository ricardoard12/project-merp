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
        private IOrderView orderpublic; 
        
        public QuattroRepository()
        {
            orderpublic = OrderFactory.createNew();
        }

        public IConnection<IQuattroService> Connection
        {
            get
            {
                if (quattroServiceConnection == null)
                {
                    quattroServiceConnection =
                    ConnectionFactory<ISupplierService>.CreateConnection("SupplierService",
                                                                           "net.tcp://10.12.10.150:2526/Service/Stammdaten/Supplier");
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

        public IOrderService Service
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

        public IOfferView ByPrimaryKey()
        {
            throw new NotImplementedException();
        }

        public IList<IOfferView> AllQuattros()
        {
            throw new NotImplementedException();
        }

        public void AddQuattro(IOfferView view)
        {
            throw new NotImplementedException();
        }

        public void AddPosition(ISalesItem item)
        {
            throw new NotImplementedException();
        }
    }
}

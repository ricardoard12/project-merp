using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using FrontEnd.Data.Channel;
using Views;
using Views.BusinessProcesses.Purchase;
using Views.BusinessProcesses.Sales;
using Views.Security.Connection;
using Views.Stammdaten.Product;
using Views.Stammdaten.Supplier;

namespace WpfApplication1.DataAccess.BusinessProcesses.Purchase
{
    class PurchaseHeaderRepository : IPurchaseHeaderRepository
    {
        private IConnection<IQuattroService> quattroServiceConnection;
        private PagedResult<IPurchaseHeaderView> purchaseHeaderView;
        private IQuattroService quattroService;
        private IPurchaseHeaderView purchaseHeader;
        private readonly List<PurchaseHeaderView> purchaseHeaders;

        public PurchaseHeaderRepository()
        {
            purchaseHeader = PurchaseFactory.createNewPurchaseHeader();
            purchaseHeaders = new List<PurchaseHeaderView>();
        }

        public IConnection<IQuattroService> Connection
        {
            get
            {
                if (quattroServiceConnection == null)
                {
                    quattroServiceConnection =
                    ConnectionFactory<IQuattroService>.CreateConnection("QuattroService",
                                                                           "net.tcp://10.12.10.150:2526/Service/SupplierService");
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

        public void AddPurchaseHeader(IPurchaseHeaderView purchaseHeader)
        {
            Service.AddPurchaseHeader(purchaseHeader);
        }

        public IList<IPurchaseHeaderView> GetAllPurchaseHeader()
        {
            IList<IPurchaseHeaderView> resultSet = Service.AllPurchaseHeader();
            return resultSet.ToList();
        }

        public void DeletePurchaseHeader(IPurchaseHeaderView purchaseHeader)
        {
            Service.DeletePurchaseHeader(purchaseHeader);
        }

        public void UpdatePurchaseHeader(IPurchaseHeaderView purchaseHeader)
        {
            Service.UpdatePurchaseHeader(purchaseHeader);
        }

        public IPurchaseHeaderView GetPurchaseHeaderByPrimaryKey(int primaryKey)
        {
            return Service.QuattroPurchaseByPrimaryKey(primaryKey);
        }
    }
}

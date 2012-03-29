using System.Collections.Generic;
using System.Linq;
using Views.BusinessProcesses.Purchase;
using Views.BusinessProcesses.Sales;
using System.ServiceModel;
using FrontEnd.Data.Channel;
using Views;
using Views.BusinessProcesses.Sales.Offer;
using Views.Security.Connection;


namespace WpfApplication1.DataAccess.BusinessProcesses.Sales
{
    class QuattroRepository : IQuattroRepository
    {
        private IConnection<IQuattroService> quattroServiceConnection;
        private IQuattroService quattroService;
        private ISalesHeaderView salesHeaderView; 
        
        public QuattroRepository()
        {
            salesHeaderView = SalesFactory.createNewSalesHeader();
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
            Service.AddHeaderSales(salesHeaderView);
        }

        public ISalesHeaderView ByPrimaryKey()
        {
            throw new System.NotImplementedException();
        }

        public IList<ISalesHeaderView> AllQuattros()
        {
            IList<ISalesHeaderView> resultSet = Service.AllSales();
            return resultSet.ToList();
        }

        public void AddQuattro(ISalesHeaderView salesHeaderView)
        {
            Service.AddHeaderSales(salesHeaderView);
        }

        public void AddPosition(ISalesItem item)
        {
            Service.AddSalesPosition(item);
        }

      
        public void AddHeaderSales(ISalesHeaderView view)
        {
            Service.AddHeaderSales(view);
        }

        public void DeleteSalesHeader(ISalesHeaderView view)
        {
            Service.DeleteSalesHeader(view);
        }

        public void AddSalesPosition(ISalesItem item)
        {
           Service.AddSalesPosition(item);
        }

        public void DeleteSalesPosition(ISalesItem item)
        {
           Service.DeleteSalesPosition(item);
        }

        public ISalesHeaderView QuattroSalesByPrimaryKey(int primaryKey)
        {
            return Service.QuattroSalesByPrimaryKey(primaryKey);
        }

        public IList<ISalesHeaderView> AllSales()
        {
           return Service.AllSales();
        }

        public IList<ISalesHeaderView> BySpecifiedType(int? type)
        {
            return Service.BySpecifiedType(type);
        }

        public IList<ISalesItem> AllSalesItemsBySalesHeader(int primaryKey)
        {
            return Service.AllSalesItemsBySalesHeader(primaryKey);
        }

        public void AddPurchaseHeader(IPurchaseHeaderView view)
        {
           Service.AddPurchaseHeader(view);   
        }

        public void AddPuchaseItem(IPurchaseItem item)
        {
            Service.AddPuchaseItem(item);
        }

        public void DeletePurchaseHeader(IPurchaseHeaderView view)
        {
           
            Service.DeletePurchaseHeader(view);
        }

        public void DeletePurchaseItem(IPurchaseItem item)
        {
           Service.DeletePurchaseItem(item);
        }

        public IPurchaseHeaderView QuattroPurchaseByPrimaryKey(int primaryKey)
        {
           return Service.QuattroPurchaseByPrimaryKey(primaryKey);
        }

        public IList<IPurchaseHeaderView> AllPurchaseHeader()
        {
            return Service.AllPurchaseHeader();
        }

        public IList<IPurchaseHeaderView> AllPurchaseHeaderBySpecifiedType(int? type)
        {
            return Service.AllPurchaseHeaderBySpecifiedType(type);
        }

        public IList<IPurchaseItem> AllPurchaseItemsByHeaderPrimaryKey(int primaryKey)
        {
            return Service.AllPurchaseItemsByHeaderPrimaryKey(primaryKey);
        }

        public void UpdatePurchaseHeader(IPurchaseHeaderView purchaseHeader)
        {
            Service.UpdatePurchaseHeader(purchaseHeader);
        }
    }
}

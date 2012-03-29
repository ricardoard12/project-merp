using System.Collections.Generic;
using DAL.Selections.BusinessProcess.Quattro;
using Views.BusinessProcesses.Purchase;
using Views.BusinessProcesses.Sales;
using Views.BusinessProcesses.Sales.Offer;


namespace BL.Service
{
    public partial class RootService : IQuattroService 
    {
        public void AddHeaderSales(ISalesHeaderView view)
        {
            QuattroDataFactory.AddSalesHeader(view);
        }

        public void UpdateHeaderSales(ISalesHeaderView view)
        {
            QuattroDataFactory.UpdateSalesHeader(view);
        }

        public void AddSalesPosition(ISalesItem item)
        {
            QuattroDataFactory.AddPosition(item);
        }

        public ISalesHeaderView QuattroSalesByPrimaryKey(int primaryKey)
        {
           return QuattroDataFactory.LoadBySalesHeader(primaryKey);
        }

        public IList<ISalesHeaderView> AllSales()
        {
            return QuattroDataFactory.AllSalesHeader();
        }

        public IList<ISalesHeaderView> BySpecifiedType(int? type)
        {
            return QuattroDataFactory.BySpecifiedType(type);
        }

        public IList<ISalesItem> AllSalesItemsBySalesHeader(int primaryKey)
        {
           return QuattroDataFactory.AllSalesItemsByHeaderKey(primaryKey);
        }

        public void AddPurchaseHeader(IPurchaseHeaderView view)
        {
             QuattroDataFactory.AddPurchaseHeader(view);
        }

        public void AddPuchaseItem(IPurchaseItem item)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePurchaseHeader(IPurchaseHeaderView view)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePurchaseItem(IPurchaseItem item)
        {
            throw new System.NotImplementedException();
        }

        public IPurchaseHeaderView QuattroPurchaseByPrimaryKey(int primaryKey)
        {
            throw new System.NotImplementedException();
        }

        public IList<IPurchaseHeaderView> AllPurchaseHeader()
        {
            throw new System.NotImplementedException();
        }

        public IList<IPurchaseHeaderView> AllPurchaseHeaderBySpecifiedType(int? type)
        {
            throw new System.NotImplementedException();
        }

        public IList<IPurchaseItem> AllPurchaseItemsByHeaderPrimaryKey(int primaryKey)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSalesHeader(ISalesHeaderView view)
        {
            QuattroDataFactory.DeleteHeader(view);
        }

        public void DeleteSalesPosition(ISalesItem item)
        {
            QuattroDataFactory.DeleteSalesItem(item);
        }
    }
}

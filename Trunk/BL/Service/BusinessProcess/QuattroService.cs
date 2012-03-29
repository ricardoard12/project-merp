using System.Collections.Generic;
using DAL.Selections.BusinessProcess.Quattro;
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

        public void DeleteQuattro(ISalesHeaderView view)
        {
            QuattroDataFactory.DeleteHeader(view);
        }

        public void DeletePosition(ISalesItem item)
        {
            QuattroDataFactory.DeleteSalesItem(item);
        }
    }
}

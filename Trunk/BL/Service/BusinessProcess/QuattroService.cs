using System.Collections.Generic;
using DAL.Selections.Stammdaten.Quattro;
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

        public ISalesHeaderView QuattroByPrimaryKey(int primaryKey)
        {
           return QuattroDataFactory.LoadBySalesHeader(primaryKey);
        }

        public IList<ISalesHeaderView> AllQuattros()
        {
            throw new System.NotImplementedException();
        }

        public IList<ISalesHeaderView> BySpecifiedType(int type)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteQuattro(ISalesHeaderView view)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePosition(ISalesItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}

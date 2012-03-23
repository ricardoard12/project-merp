using System.Collections.Generic;
using DAL.Selections.Stammdaten.Quattro;
using Views.BusinessProcesses.Sales;
using Views.BusinessProcesses.Sales.Offer;
using Views.BusinessProcesses.Sales.Order;


namespace BL.Service
{
    public partial class RootService : IQuattroService 
    {
        public void AddQuattro(ISalesHeaderView view)
        {
            throw new System.NotImplementedException();
        }

        public void AddSalesPosition(ISalesItem item)
        {
            throw new System.NotImplementedException();
        }

        public ISalesHeaderView QuattroByPrimaryKey(int primaryKey)
        {
            throw new System.NotImplementedException();
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

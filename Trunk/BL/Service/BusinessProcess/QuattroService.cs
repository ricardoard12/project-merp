using System.Collections.Generic;
using DAL.Selections.Stammdaten.Quattro;
using Views.BusinessProcesses.Sales;
using Views.BusinessProcesses.Sales.Offer;
using Views.BusinessProcesses.Sales.Order;


namespace BL.Service
{
    public partial class RootService : IQuattroService 
    {
        public void AddQuattro(IOrderView view)
        {
            QuattroDataFactory.
        }

        public IOrderView QuattroByPrimaryKey(int primaryKey)
        {
            
        }

        public IList<IOrderView> AllQuattros()
        {
            throw new System.NotImplementedException();
        }

        public IList<IOrderView> BySpecifiedType(int type)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteQuattro(IOrderView view)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePosition(ISalesItem item)
        {
            throw new System.NotImplementedException();
        }

        public IList<IOrderView> BySpecifiedType()
        {
            throw new System.NotImplementedException();
        }
    }
}

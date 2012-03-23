using System.Collections.Generic;
using Views.BusinessProcesses.Sales;
using Views.BusinessProcesses.Sales.Order;


namespace BL.Service
{
    public partial class RootService : IQuattroService 
    {
        public void AddQuattro(IOrderView view)
        {
            
        }

        public IOrderView QuattroByPrimaryKey(int primaryKey)
        {
            
        }

        public IList<IOrderView> AllQuattros()
        {
            throw new System.NotImplementedException();
        }

        public IList<IOrderView> BySpecifiedType()
        {
            throw new System.NotImplementedException();
        }
    }
}

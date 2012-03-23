using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Sales.Offer;
using Views.BusinessProcesses.Sales.Order;

namespace WpfApplication1.DataAccess.BusinessProcesses.Sales
{
    public interface IQuattroRepository
    {
        IOrderView ByPrimaryKey();

        IList<IOrderView> AllQuattros();

        void AddQuattro(IOrderView view);

        void AddPosition(ISalesItem item);
        
    }
}

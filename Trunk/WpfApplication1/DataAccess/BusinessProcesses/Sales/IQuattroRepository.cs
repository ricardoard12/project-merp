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
        ISalesHeaderView ByPrimaryKey();

        IList<ISalesHeaderView> AllQuattros();

        void AddQuattro(ISalesHeaderView view);

        void AddPosition(ISalesItem item);
        
    }
}

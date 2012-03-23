using System.Collections.Generic;
using Views.BusinessProcesses.Sales.Offer;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Sales.Offer;

namespace WpfApplication1.DataAccess.BusinessProcesses.Sales
{
    interface IQuattroRepository
    {
        IOfferView ByPrimaryKey();

        IList<IOfferView> AllQuattros();

        void AddQuattro(IOfferView view);

        void AddPosition(ISalesItem item);
        
    }
}

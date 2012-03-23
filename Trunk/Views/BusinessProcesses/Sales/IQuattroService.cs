using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Views.BusinessProcesses.Sales.Offer;
using Views.BusinessProcesses.Sales.Order;

namespace Views.BusinessProcesses.Sales
{
    [ServiceContract]
    public interface IQuattroService
    {
        [OperationContract]
        void AddQuattro(IOrderView view);

        [OperationContract]
        IOrderView QuattroByPrimaryKey(int primaryKey);

        [OperationContract]
        IList<IOrderView> AllQuattros();

        [OperationContract]
        IList<IOrderView> BySpecifiedType();

    }
}

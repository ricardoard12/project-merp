using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Views.BusinessProcesses.Sales.Order;

namespace Views.BusinessProcesses.Sales
{
    [ServiceContract]
    [ServiceKnownType(typeof(OrderView))]
    public class IQuattroService
    {
        [OperationContract]
        void DeleteSupplier(IOrderView order);

        [OperationContract]
        void AddSupplier(IOrderView order);

        [OperationContract]
        PagedResult<IOrderView> AllOrder();

        [OperationContract]
        IOrderView OrderByPrimaryKey(int primaryKey);

        [OperationContract]
        void UpdateOrder(IOrderView order);
    }
}

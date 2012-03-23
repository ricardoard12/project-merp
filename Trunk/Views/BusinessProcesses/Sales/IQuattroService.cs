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
        void AddQuattro(ISalesHeaderView view);

        [OperationContract]
        void AddSalesPosition(ISalesItem item);
        
        [OperationContract]
        ISalesHeaderView QuattroByPrimaryKey(int primaryKey);

        [OperationContract]
        IList<ISalesHeaderView> AllQuattros();

        [OperationContract]
        IList<ISalesHeaderView> BySpecifiedType(int type);

        [OperationContract]
        void DeleteQuattro(ISalesHeaderView view);

        [OperationContract]
        void DeletePosition(ISalesItem item);



    }
}

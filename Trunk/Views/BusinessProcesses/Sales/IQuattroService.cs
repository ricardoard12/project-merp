using System.Collections.Generic;
using System.ServiceModel;
using Views.BusinessProcesses.Sales.Offer;

namespace Views.BusinessProcesses.Sales
{
    [ServiceContract]
    public interface IQuattroService
    {
        [OperationContract]
        void AddHeaderSales(ISalesHeaderView view);

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

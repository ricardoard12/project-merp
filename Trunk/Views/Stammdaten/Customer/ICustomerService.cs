using System.Collections.Generic;
using System.ServiceModel;

namespace Views.Stammdaten.Customer
{
    [ServiceContract]
    [ServiceKnownType(typeof(CustomerView))]
    public interface ICustomerService
    {
        [OperationContract]
        void AddCustomer(ICustomerView customer);

        [OperationContract]
        IList<ICustomerView> AllCustomers();

        [OperationContract]
        ICustomerView GetCustomerByPrimaryKey(int primaryKey);
    }
}

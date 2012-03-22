using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Views;
using Views.Stammdaten;

namespace BL.Service.Stammdaten.Customer
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        PagedResult<ICustomerView> AllCustomers();

        

    }
}

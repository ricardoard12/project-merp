using System.Collections.Generic;
using BL.Service.Stammdaten.Customer;
using DAL.Selections.Stammdaten.Customer;
using Views;
using Views.Stammdaten;

//HBS

namespace BL.Service
{
    public partial class RootService: ICustomerService
    {
        public IList<ICustomerView> AllCustomers()
        {
            return CustomerDataFactory.GetAllCustomers();
        }

        public ICustomerView By()
        {
            throw new System.NotImplementedException();
        }


        PagedResult<ICustomerView> ICustomerService.AllCustomers()
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using DAL.Selections.Stammdaten.Customer;
using Views;
using Views.Stammdaten;
using Views.Stammdaten.Customer;

//HBS

namespace BL.Service
{
    public partial class RootService: ICustomerService
    {
        public void AddCustomer(ICustomerView customer)
        {
            CustomerDataFactory.AddCustomer(customer);
        }

        public IList<ICustomerView> AllCustomers()
        {
           return CustomerDataFactory.GetAllCustomers();
        }

        public ICustomerView GetCustomerByPrimaryKey(int primaryKey)
        {
            return CustomerDataFactory.ByPrimaryKey(primaryKey);
        }
    }
}

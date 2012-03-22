using System.Collections.Generic;
using System.Linq;
using Database;
using Views.Stammdaten;
using Views.Stammdaten.Customer;

//HBS

namespace DAL.Selections.Stammdaten.Customer
{
    public class CustomerDataFactory : ASelection
    {
        public static void AddCustomer(ICustomerView customerView)
        {
            var customer = new tbl_Cus
                                   {
                                       Cus_ = customerView.CusId,
                                       CusLastname = customerView.CusLastname,
                                       CusFirstname = customerView.CusFirstname,
                                       CusUsr_ = customerView.CusUsrId,
                                       CusNumber = customerView.CusNumber,
                                       CusContactname = customerView.CusContactname,
                                       CusIscompany = customerView.CusIsCompany
                                   };
            MerpDatabase().tbl_Cus.AddObject(customer);
        }

        public static IList<ICustomerView> GetAllCustomers()
        {

            return (from c in MerpDatabase().tbl_Cus
                    select
                        CustomerFactory.createNew(c.Cus_, c.CusNumber, c.CusFirstname, c.CusLastname, c.CusContactname,
                                                  c.CusUsr_, c.CusIscompany)).ToList();
        }  

        public static ICustomerView ByPrimaryKey(int primryKey)
        {
            return (from c in MerpDatabase().tbl_Cus 
                        where c.Cus_ == primryKey
                        select 
            CustomerFactory.createNew(c.Cus_, c.CusNumber, c.CusFirstname, c.CusLastname, c.CusContactname,
                                      c.CusUsr_, c.CusIscompany)).First();
        }
    }
}

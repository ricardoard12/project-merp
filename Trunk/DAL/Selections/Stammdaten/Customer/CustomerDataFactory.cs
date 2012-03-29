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
            MerpDatabase().tbl_Cus.AddObject(CreateCustomer(customerView));
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
                        select CreateCustomer(c)).First();
        }

        public static ICustomerView CreateCustomer(tbl_Cus cus)
        {
            return CustomerFactory.createNew(cus.Cus_, cus.CusNumber, cus.CusFirstname, cus.CusLastname,
                                             cus.CusContactname,
                                             cus.CusUsr_, cus.CusIscompany);
        }

        public  static tbl_Cus CreateCustomer(ICustomerView cus)
        {
            var customer = new tbl_Cus
                               {
                                   Cus_ = cus.CusId,
                                   CusLastname = cus.CusLastname,
                                   CusFirstname = cus.CusFirstname,
                                   CusUsr_ = cus.CusUsrId,
                                   CusNumber = cus.CusNumber,
                                   CusContactname = cus.Email,
                                   CusIscompany = cus.CusIsCompany
                               };
            return customer;
        }
    }
}

using System.Collections;
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
            MerpDatabase().SaveChanges();
        }

        public static IList<ICustomerView> GetAllCustomers()
        {
            IList<ICustomerView> customers = new List<ICustomerView>();
            foreach (var currentCus in MerpDatabase().tbl_Cus)
            {
                customers.Add(CreateCustomer(currentCus));
            }
            return customers;
        }

        public static ICustomerView ByPrimaryKey(int primryKey)
        {
                var cus = MerpDatabase().tbl_Cus.First(c => c.Cus_ == primryKey);
                return CreateCustomer(cus);
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

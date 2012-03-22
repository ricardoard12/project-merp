using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.Stammdaten.User;

namespace Views.Stammdaten.Customer
{
   public static class CustomerFactory
    {
       public static ICustomerView createNew()
       {
           return new CustomerView();
       }

       public  static ICustomerView createNew( int CusId,int? CusNumber, string CusFirstname, string CusLastname,  string CusContactname, int? CusUsrId, bool? CusIsCompany)
       {
           return new CustomerView(CusId, CusNumber, CusFirstname, CusLastname, CusContactname, CusUsrId, CusIsCompany);
       }
    }
}

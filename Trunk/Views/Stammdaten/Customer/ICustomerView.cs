using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//HBS

namespace Views.Stammdaten
{
   public interface ICustomerView
    {
        int CusId { get; set; }
        int? CusNumber { get; set; }
        string CusFirstname { get; set; }
        string CusLastname { get; set; }
        string CusContactname { get; set; }
        int? CusUsrId { get; set; }
        bool? CusIsCompany { get; set; }

    }
}

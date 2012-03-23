using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Stammdaten.Supplier
{
   
    public interface ISupplierView : ISerializable
    {
        int SupId { get; set; }
        int? SupNumber { get; set; }
        string SupFirstname { get; set; }
        string SupLastname { get; set; }
        string SupContactname { get; set; }
        int?  SupUsrId{ get; set; }
        bool? SupIsCompany { get; set; }
    }
}

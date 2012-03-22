using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.Supplier
{
    class SupplierView : ISupplierView
    {
        public int SupId { get; set; }
        public int? SupNumber { get; set; }
        public string SupFirstname { get; set; }
        public string SupLastname { get; set; }
        public string SupContactname { get; set; }
        public int? SupUsrId { get; set; }
        public bool? SupIsCompany { get; set; }

        
        public SupplierView() {

        }


        public SupplierView(int supId, int? supNumber, string supFirstname, string supLastname, string supContactname, int? supUsrId, bool? supIsCompany)
        {
            this.SupId = supId;
            this.SupNumber = supNumber;
            this.SupFirstname = supFirstname;
            this.SupLastname = supLastname;
            this.SupContactname = supContactname;
            this.SupUsrId = supUsrId;
            this.SupIsCompany = supIsCompany;
        }
    }
}

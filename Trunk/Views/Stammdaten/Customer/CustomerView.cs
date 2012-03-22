//HBS

namespace Views.Stammdaten.Customer
{
    class CustomerView : ICustomerView
    {
        public int CusId { get; set; }
        public int? CusNumber { get; set; }
        public string CusFirstname { get; set; }
        public string CusLastname { get; set; }
        public string CusContactname { get; set; }
        public int? CusUsrId { get; set; }
        public bool? CusIsCompany { get; set; }

        public CustomerView()
        {
            
        }

        public CustomerView(int cusId, int? cusNumber, string cusFirstname, string cusLastname, string cusContactname, int? cusUsrId, bool? cusIsCompany)
        {
            this.CusId = cusId;
            this.CusNumber = cusNumber;
            this.CusFirstname = cusFirstname;
            this.CusLastname = cusLastname;
            this.CusContactname = cusContactname;
            this.CusUsrId = cusUsrId;
            this.CusIsCompany = cusIsCompany;
        }
    }
}

namespace Views.Stammdaten.Supplier
{
    public class SupplierFactory
    {

        public static ISupplierView createNew()
        {
            return new SupplierView();
        }

        public static ISupplierView createNew(int supId, int? supNumber, string supFirstname, string supLastname, string supContactname, int? supUsrId, bool? supIsCompany)
        {
            return new SupplierView(supId, supNumber, supFirstname, supLastname, supContactname, supUsrId, supIsCompany);
        }
    }
}

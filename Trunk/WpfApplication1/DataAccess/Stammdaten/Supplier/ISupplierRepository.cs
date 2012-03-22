//KCH

using System.Collections.Generic;
using Views.Stammdaten.Supplier;

namespace WpfApplication1.DataAccess.Stammdaten.Supplier
{
    public interface ISupplierRepository
    {
        void AddSupplier(ISupplierView supplier);

        IList<ISupplierView> GetAllSuppliers();

        void DeleteSupplier(ISupplierView supplier);

        void UpdateSupplier(ISupplierView supplier);

        ISupplierView GetSupplierByPrimaryKey(int primaryKey);





    }

}

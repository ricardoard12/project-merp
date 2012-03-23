using System.Collections.Generic;
using DAL.Selections.Stammdaten.Supplier;
using Views;
using Views.Stammdaten.Supplier;


namespace BL.Service
{
   public partial class RootService : ISupplierService
    {
       public void DeleteSupplier(ISupplierView supplier)
       {
           SupplierDataFactory.DeleteSupplier(supplier);
       }

       public void AddSupplier(ISupplierView supplier)
       {
           SupplierDataFactory.AddSupplier(supplier);
       }

       public PagedResult<ISupplierView> AllSupplier()
       {
           PagedResult<ISupplierView> resultSet = new PagedResult<ISupplierView>();
           IList<ISupplierView> result = SupplierDataFactory.GetAllSuppliers();
           resultSet.Rows = new List<ISupplierView>(result);
           resultSet.Total = result.Count;
           return resultSet;
       }

       public ISupplierView SupplierByPrimaryKey(int primaryKey)
       {
           ISupplierView result = SupplierDataFactory.ByPrimaryKey(primaryKey);
            return result;
       }

       public void UpdateSupplier(ISupplierView supplier)
       {
           SupplierDataFactory.UpdateSupplier(supplier);
       }
    }
}

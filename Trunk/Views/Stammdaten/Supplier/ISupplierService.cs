using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.Supplier
{
    public interface ISupplierService
    {
        void DeleteSupplier(ISupplierView supplier);


        void AddSupplier(ISupplierView supplier);


        PagedResult<ISupplierView> AllSupplier();


        ISupplierView SupplierByPrimaryKey(int primaryKey);
    }
}


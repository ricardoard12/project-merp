using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Views.Stammdaten.Supplier
{
    [ServiceContract]
    [ServiceKnownType(typeof(SupplierView))]
    public interface ISupplierService
    {
        [OperationContract]
        void DeleteSupplier(ISupplierView supplier);
        
        [OperationContract]
        void AddSupplier(ISupplierView supplier);
        
        [OperationContract]
        PagedResult<ISupplierView> AllSupplier();
        
        [OperationContract]
        ISupplierView SupplierByPrimaryKey(int primaryKey);
        
        [OperationContract]
        void UpdateSupplier(ISupplierView supplier);
    }
}


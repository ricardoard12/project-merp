using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Views;
using Views.Stammdaten.Supplier;

namespace BL.Service.Stammdaten.Supplier
{
    [ServiceContract]
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
    }
}

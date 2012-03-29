using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Purchase;

namespace WpfApplication1.DataAccess.BusinessProcesses.Purchase
{
    public interface IPurchaseHeaderRepository
    {
        void AddPurchaseHeader(IPurchaseHeaderView purchaseHeader);

        IList<IPurchaseHeaderView> GetAllPurchaseHeader();

        void DeletePurchaseHeader(IPurchaseHeaderView purchaseHeader);

        void UpdatePurchaseHeader(IPurchaseHeaderView purchaseHeader);

        IPurchaseHeaderView GetPurchaseHeaderByPrimaryKey(int primaryKey);
    }
}

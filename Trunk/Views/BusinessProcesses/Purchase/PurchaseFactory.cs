using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.BusinessProcesses.Purchase
{
    public class PurchaseFactory
    {
        public static IPurchaseHeaderView createNewPurchaseHeader()
        {
            return  new PurchaseHeaderView();
        }

        public static IPurchaseHeaderView createNewPurchaseHeader(int purchaseId, int? purchaseNumber, int? purchaseCustomer, DateTime? purchaseCreateDate, int? purchasetype)
        {
            return  new PurchaseHeaderView(purchaseId, purchaseNumber, purchaseCustomer, purchaseCreateDate, purchasetype);
        }


        public static IPurchaseItem createNewPurchaseItem()
        {
            return new PurchaseItem();
        }

        public  static IPurchaseItem createNewPruchaseItem(int id, int number, int SahId, int PrdId, float vat, float discount)
        {
            return  new PurchaseItem(id, number, SahId, PrdId, vat, discount);
        }
    }
}

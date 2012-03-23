using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Views.BusinessProcesses.Sales.Offer;

namespace DAL.Selections.Stammdaten.Quattro {
    public class QuattroDataFactory : ASelection {

        public static void AddPurchaseHeader(tbl_Puh header) {
            MerpDatabase().tbl_Puh.AddObject(header);
        }


        public static void AddSalesHeader(ISalesHeaderView view)
        {
            MerpDatabase().tbl_Sah.AddObject(CreateSalesHeader(view));
            MerpDatabase().SaveChanges();
        }


        public static ISalesHeaderView LoadBySalesHeader(int primaryKey)
        {
            return CreateSalesHeader(LoadByPrimaryKey(primaryKey));
        }


        public static void UpdateSalesHeader(ISalesHeaderView view)
        {
            LoadBySalesHeader(view);
            MerpDatabase().SaveChanges();
        }

        #region HelperMethod

        public static tbl_Sah CreateSalesHeader(ISalesHeaderView view)
        {
            tbl_Sah sah = new tbl_Sah();
            sah.SahNumber = view.OfferNumber;
            sah.SahCus_ = view.OfferCustomer;
            sah.SahCreatedate = view.OfferCreateDate;
            return sah;
        }

        private static tbl_Sah LoadBySalesHeader(ISalesHeaderView view)
        {
            tbl_Sah sah = (from S in MerpDatabase().tbl_Sah where S.Sah_ == view.OfferId select S).First();
            sah.SahNumber = view.OfferNumber;
            sah.SahCus_ = view.OfferCustomer;
            sah.SahCreatedate = view.OfferCreateDate;
            return sah;
        }

        private static tbl_Sah LoadByPrimaryKey(int primaryKey)
        {
            tbl_Sah sah = (from S in MerpDatabase().tbl_Sah where S.Sah_ == primaryKey select S).First();
             return sah;
        }

        public static tbl_Sai CreateSalesItem(ISalesItem item)
        {
            tbl_Sai sai = new tbl_Sai();
            sai.SaiNumber = item.SaiNumber;
            sai.SaiPrd_ = item.SaiPrdId;
            sai.Saidiscount = item.SaiDiscount;
            sai.SaiSah_ = item.SaiSahId;
            sai.Saivat = item.Saivat;
            return sai;
        }

        public static ISalesHeaderView CreateSalesHeader(tbl_Sah sah)
        {
            ISalesHeaderView header = SalesFactory.createNew(sah.Sah_, sah.SahNumber, sah.SahCus_, sah.SahCreatedate);
            return header;
        }

        #endregion

        public static void AddPosition(ISalesItem item)
        {
            MerpDatabase().tbl_Sai.AddObject(CreateSalesItem(item));
            MerpDatabase().SaveChanges();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Database;
using Views.BusinessProcesses.Purchase;
using Views.BusinessProcesses.Sales.Offer;

namespace DAL.Selections.BusinessProcess.Quattro {
    public class QuattroDataFactory : ASelection {

        public static void AddPurchaseHeader(IPurchaseHeaderView header) {

            MerpDatabase().tbl_Puh.AddObject(CreatePurchaseHeader(header));
        }

   

        public static void AddSalesHeader(ISalesHeaderView view)
        {
            MerpDatabase().tbl_Sah.AddObject(CreateSalesHeader(view));
            MerpDatabase().SaveChanges();
        }


        public static ISalesHeaderView LoadBySalesHeader(int primaryKey)
        {
            return CreateSalesHeader(LoadSalesHeaderByPrimaryKey(primaryKey));
        }


        public static void UpdateSalesHeader(ISalesHeaderView view)
        {
            LoadBySalesHeader(view);
            MerpDatabase().SaveChanges();
        }

        

        public static void AddPosition(ISalesItem item)
        {
            MerpDatabase().tbl_Sai.AddObject(CreateSalesItem(item));
            MerpDatabase().SaveChanges();
        }


        public static IList<ISalesHeaderView> AllSalesHeader()
        {
            IList<ISalesHeaderView> resultSet = (from s in MerpDatabase().tbl_Sah select CreateSalesHeader(s)).ToList();
            return resultSet;
        }




        #region HelperMethod

        private static tbl_Puh CreatePurchaseHeader(IPurchaseHeaderView header)
        {
            tbl_Puh puh = new tbl_Puh();
            puh.PuhNumber = header.PurchaseHeaderNumber;
            puh.PuhSup_ = header.PurchaseHeaderCustomer;
            puh.PuhCreatedate = header.PurchaseHeaderCreateDate;
            return puh;
        }

        private static IPurchaseHeaderView CreatePurchaseHeader(tbl_Puh header)
        {
          return  PurchaseFactory.createNewPurchaseHeader(header.Puh_, header.PuhNumber, header.PuhSup_, header.PuhCreatedate,
                                                    header.SahType);
        }

        public static tbl_Pui CreatePurchaseItem(IPurchaseItem item)
        {
            tbl_Pui pui = new tbl_Pui();
            pui.PuiNumber = item.PuiNumber;
            pui.PuiPrd_ = item.PuiPrdId;
            pui.Puidiscount = item.PuiDiscount;
            pui.PuiPuh_ = item.PuiPuhId;
            pui.Puivat = item.Puivat;
            return pui;
        }

        public static IPurchaseItem CreatePurchaseItem(tbl_Pui item)
        {
            return PurchaseFactory.createNewPruchaseItem(item.Pui_, item.PuiNumber, item.PuiPuh_, item.PuiPrd_,
                                                         item.Puivat, item.Puidiscount);
        }


        public static tbl_Sah CreateSalesHeader(ISalesHeaderView view)
        {
            tbl_Sah sah = new tbl_Sah();
            sah.SahNumber = view.SalesHeaderNumber;
            sah.SahCus_ = view.SalesHeaderCustomer;
            sah.SahCreatedate = view.SalesHeaderCreateDate;
            return sah;
        }

        private static tbl_Sah LoadBySalesHeader(ISalesHeaderView view)
        {
            tbl_Sah sah = (from S in MerpDatabase().tbl_Sah where S.Sah_ == view.SalesHeaderId select S).First();
            sah.SahNumber = view.SalesHeaderNumber;
            sah.SahCus_ = view.SalesHeaderCustomer;
            sah.SahCreatedate = view.SalesHeaderCreateDate;
            return sah;
        }

        private static tbl_Sah LoadSalesHeaderByPrimaryKey(int primaryKey)
        {
            tbl_Sah sah = (from S in MerpDatabase().tbl_Sah where S.Sah_ == primaryKey select S).First();
            return sah;
        }

        private static tbl_Sai LoadSalesItemByPrimaryKey(int primaryKey)
        {
            tbl_Sai sai = (from S in MerpDatabase().tbl_Sai where S.Sai_ == primaryKey select S).First();
            return sai;
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
            ISalesHeaderView header = SalesFactory.createNewSalesHeader(sah.Sah_, sah.SahNumber, sah.SahCus_, sah.SahCreatedate, sah.SahType);
            return header;
        }

        public static ISalesItem CreateSalesItem(tbl_Sai item)
        {
            ISalesItem salesItem = SalesFactory.createNewSalesItem(item.Sai_, item.SaiNumber, item.SaiSah_, item.SaiPrd_,
                                                                   item.Saivat, item.Saidiscount);

            return salesItem;
        }


        #endregion

        public static IList<ISalesHeaderView> BySpecifiedType(int? type)
        {
            IList<ISalesHeaderView> resultSet = (from s in MerpDatabase().tbl_Sah where type == s.SahType select CreateSalesHeader(s)).ToList();
            return resultSet;
        }

        public static void DeleteHeader(ISalesHeaderView view)
        {
           MerpDatabase().tbl_Sah.DeleteObject(LoadBySalesHeader(view));
        }

        public static void DeleteSalesItem(ISalesItem item)
        {
            MerpDatabase().tbl_Sai.DeleteObject(LoadSalesItemByPrimaryKey(item.SaiId));
        }


        public static IList<ISalesItem>  AllSalesItemsByHeaderKey(int primaryKey)
        {
           return (from s in MerpDatabase().tbl_Sai where s.SaiSah_ == primaryKey select CreateSalesItem(s)).ToList();
        }
    }
}

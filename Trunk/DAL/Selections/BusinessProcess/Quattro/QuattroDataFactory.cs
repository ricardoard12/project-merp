using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Database;
using Views.BusinessProcesses.Purchase;
using Views.BusinessProcesses.Sales.Offer;

namespace DAL.Selections.BusinessProcess.Quattro {
    public class QuattroDataFactory : ASelection
    {

        public static void AddPurchaseHeader(IPurchaseHeaderView header)
        {

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
            var resultSet = (from s in MerpDatabase().tbl_Sah select s);
            IList<ISalesHeaderView> sales = new List<ISalesHeaderView>();
            foreach (var tblSah in resultSet)
            {
                sales.Add(CreateSalesHeader(tblSah));
            }

            return sales;
        }




        #region HelperMethod

        private static tbl_Puh LoadPurchaseHeader(IPurchaseHeaderView view)
        {
            return (from c in MerpDatabase().tbl_Puh where view.PurchaseHeaderId == c.Puh_ select c).First();
        }

        private static tbl_Puh LoadPurchaseHeader(int primaryKey)
        {
            return (from c in MerpDatabase().tbl_Puh where primaryKey == c.Puh_ select c).First();
        }


        private static tbl_Pui LoadPurchaseItem(IPurchaseItem item)
        {
            return (from c in MerpDatabase().tbl_Pui where item.PuiId == c.Pui_ select c).First();
        }




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
            return PurchaseFactory.createNewPurchaseHeader(header.Puh_, header.PuhNumber, header.PuhSup_,
                                                           header.PuhCreatedate,
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
            ISalesHeaderView header = SalesFactory.createNewSalesHeader(sah.Sah_, sah.SahNumber, sah.SahCus_,
                                                                        sah.SahCreatedate, sah.SahType);
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
            var query = (from s in MerpDatabase().tbl_Sah where type == s.SahType select s).ToList();

            IList<ISalesHeaderView> salesheader = new List<ISalesHeaderView>();

            foreach (var sah in query)
            {
                salesheader.Add(CreateSalesHeader(sah));
            }

            return salesheader;
        }

        public static void DeleteHeader(ISalesHeaderView view)
        {
            MerpDatabase().tbl_Sah.DeleteObject(LoadBySalesHeader(view));
        }

        public static void DeleteSalesItem(ISalesItem item)
        {
            MerpDatabase().tbl_Sai.DeleteObject(LoadSalesItemByPrimaryKey(item.SaiId));
        }


        public static IList<ISalesItem> AllSalesItemsByHeaderKey(int primaryKey)
        {
            var query = (from s in MerpDatabase().tbl_Sai where s.SaiSah_ == primaryKey select s).ToList();
            IList<ISalesItem> salesItems = new List<ISalesItem>();

            foreach (var tblSai in query)
            {
                salesItems.Add(CreateSalesItem(tblSai));
            }

            return salesItems;
        }

        public static void AddPurchaseItem(IPurchaseItem item)
        {
            MerpDatabase().tbl_Pui.AddObject(CreatePurchaseItem(item));
        }

        public static void DeletePurchaseHeader(IPurchaseHeaderView view)
        {
            MerpDatabase().tbl_Puh.DeleteObject(LoadPurchaseHeader(view));
        }


        public static void DeletePurchaseItem(IPurchaseItem item)
        {
            MerpDatabase().tbl_Pui.DeleteObject(LoadPurchaseItem(item));
        }

        public static IPurchaseHeaderView GetPurchaseHeaderByPrimaryKey(int primaryKey)
        {
            return CreatePurchaseHeader(LoadPurchaseHeader(primaryKey));
        }

        public static IList<IPurchaseHeaderView> AllPurchaseHeader()
        {
            IList<IPurchaseHeaderView> resultset = new List<IPurchaseHeaderView>();
            var query = (from c in MerpDatabase().tbl_Puh select c).ToList();

            foreach (var tblPuh in query)
            {
                resultset.Add(CreatePurchaseHeader(tblPuh));
            }

            return resultset;
        }

        public static IList<IPurchaseHeaderView> AllPurchasHeaderBySpecifiedtype(int? type)
        {
            IList<IPurchaseHeaderView> resultset = new List<IPurchaseHeaderView>();
            var query = (from c in MerpDatabase().tbl_Puh where type == c.SahType select c).ToList();
            foreach (var tblPuh in query)
            {
                resultset.Add(CreatePurchaseHeader(tblPuh));
            }

            return resultset;
        }

        public static IList<IPurchaseItem> AllPurchaseHeaderByHeaderKey(int primaryKey)
        {
            IList<IPurchaseItem> resultset = new List<IPurchaseItem>();
            var query = (from c in MerpDatabase().tbl_Pui where primaryKey == c.PuiPuh_ select c).ToList();
            foreach (var tblPui in query)
            {
                resultset.Add(CreatePurchaseItem(tblPui));
            }

            return resultset;
        }
    }
}

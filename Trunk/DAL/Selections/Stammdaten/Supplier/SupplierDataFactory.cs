using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Views.Stammdaten.Supplier;

namespace DAL.Selections.Stammdaten.Supplier
{
   public class SupplierDataFactory : ASelection
    {
       public static void AddSupplier(ISupplierView supplierView)
       {
           var supplier = new tbl_Sup
           {
               Sup_ = supplierView.SupId,
               SupLastname = supplierView.SupLastname,
               SupFirstname = supplierView.SupFirstname,
               SupUsr_ = supplierView.SupUsrId,
               SupNumber = supplierView.SupNumber,
               SupContactname = supplierView.SupContactname,
               SupIscompany = supplierView.SupIsCompany
           };
           MerpDatabase().tbl_Sup.AddObject(supplier);
           MerpDatabase().SaveChanges();
       }

       public static void DeleteSupplier (ISupplierView supplierView)
       {
           var supplier = (from c in MerpDatabase().tbl_Sup where c.Sup_ == supplierView.SupId select c).First();
           if (supplier == null)
           {
               throw new Exception("No Supplierfound with this ID");
           }
           MerpDatabase().tbl_Sup.DeleteObject(supplier);
       }

       public static IList<ISupplierView> GetAllSuppliers()
       {

           return (from c in MerpDatabase().tbl_Sup
                   select
                       SupplierFactory.createNew(c.Sup_, c.SupNumber, c.SupFirstname, c.SupLastname, c.SupContactname,
                                                 c.SupUsr_, c.SupIscompany)).ToList();
       }

       public static ISupplierView ByPrimaryKey(int primryKey)
       {
           return (from c in MerpDatabase().tbl_Sup
                   where c.Sup_ == primryKey
                   select
       SupplierFactory.createNew(c.Sup_, c.SupNumber, c.SupFirstname, c.SupLastname, c.SupContactname,
                                 c.SupUsr_, c.SupIscompany)).First();
       }

       public static void UpdateSupplier(ISupplierView supplierView)
       {
           var supplier = (from c in MerpDatabase().tbl_Sup where c.Sup_ == supplierView.SupId select c).First();
           if (supplier == null)
           {
               throw new Exception("don't found supplier with this PrimaryKey");
           }
           supplier.Sup_ = supplierView.SupId;
           supplier.SupLastname = supplierView.SupLastname;
           supplier.SupFirstname = supplierView.SupFirstname;
           supplier.SupUsr_ = supplierView.SupUsrId;
           supplier.SupNumber = supplierView.SupNumber;
           supplier.SupContactname = supplierView.SupContactname;
           supplier.SupIscompany = supplierView.SupIsCompany;
           MerpDatabase().SaveChanges();

       }
    }
}

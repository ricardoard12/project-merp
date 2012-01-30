using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Views.Stammdaten.Product;

namespace DAL.Selections.Stammdaten.Product {
    public class ProductDataFactory : ASelection {

        public static void AddProduct(IProductView product) {
            tbl_Prd Product = new tbl_Prd()
            {
                Prd_ = MerpDatabase().tbl_Prd.Count() + 1,
                PrdNumber = product.ProductNumber,
                PrdName = product.ProductName,
                PrdEAN = product.Ean,
                PrdPricePurchase = product.PricePurchase,
                PrdPriceSale = product.PriceSale,
                
            };

            MerpDatabase().tbl_Prd.AddObject(Product);
            try {
                MerpDatabase().SaveChanges();
            } catch (Exception e) {

            }

        }


        public static List<IProductView> GetProducts(int PrdCat, int Anzahl, int Start) {
            return (from P in MerpDatabase().tbl_Prd
                    where P.PrdPrdcat_ == PrdCat
                    orderby P.Prd_
                    select ProductFactory.createProduct(P.Prd_, P.PrdNumber, P.PrdName, P.PrdEAN, P.PrdPricePurchase,
                                                       P.PrdPriceSale, P.PrdPrdcat_, P.PrdSup_)).Skip(Start).Take(Anzahl).ToList();
        
                      }
    }
}

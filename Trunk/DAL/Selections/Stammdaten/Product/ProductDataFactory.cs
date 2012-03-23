using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Views.Stammdaten.Product;

namespace DAL.Selections.Stammdaten.Product {
    public class ProductDataFactory : ASelection
    {

        public static void AddProduct(IProductView product)
        {
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
            try
            {
                MerpDatabase().SaveChanges();
            }
            catch (Exception e)
            {

            }

        }


        public static List<IProductView> GetProducts(int PrdCat, int Anzahl, int Start)
        {
            return (from P in MerpDatabase().tbl_Prd
                    where P.PrdPrdcat_ == PrdCat
                    orderby P.Prd_
                    select ProductFactory.createProduct(P.Prd_, P.PrdNumber, P.PrdName, P.PrdEAN, P.PrdPricePurchase,
                                                        P.PrdPriceSale, P.PrdPrdcat_, P.PrdSup_)).Skip(Start).Take(
                                                            Anzahl).ToList();

        }

        public static IList<IProductView> AllProducts()
        {
            List<IProductView> resultSet = new List<IProductView>();

            foreach (var productView in MerpDatabase().tbl_Prd)
            {
                resultSet.Add(ProductFactory.createProduct(productView.Prd_, productView.PrdNumber, productView.PrdName,
                                                           productView.PrdEAN, productView.PrdPricePurchase,
                                                           productView.PrdPriceSale, productView.PrdPrdcat_,
                                                           productView.PrdSup_));
            }

            return resultSet;
            /*return (from c in MerpDatabase().tbl_Prd
                    select
                        ProductFactory.createProduct(c.Prd_, c.PrdNumber, c.PrdName, c.PrdEAN, c.PrdPricePurchase,
                                                  c.PrdPriceSale, c.PrdPrdcat_, c.PrdSup_)).ToList();*/
        }



        public static IList<IPrdcatView> AllProductsCategorys()
        {
            IList<IPrdcatView> prdcatList = new List<IPrdcatView>();
            foreach (var prdcatView in MerpDatabase().tbl_Prdcat)
            {
                prdcatList.Add(CreateProductcategory(prdcatView));
            }
            return prdcatList;
        }

        public static void AddPrdcat(IPrdcatView prdcatView)
        {
            tbl_Prdcat prdcat = new tbl_Prdcat();
            prdcat.PrdcatName = prdcatView.PrdcatName;
            prdcat.Prdcat_ = prdcatView.PrdcatId;
            prdcat.PrdcatNumber = prdcatView.PrdcatNumber;

            MerpDatabase().tbl_Prdcat.AddObject(prdcat);
        }

        public static IPrdcatView GetPrdcatByPrimaryKey(int primaryKey)
        {
            return CreateProductcategory((from c in MerpDatabase().tbl_Prdcat where c.Prdcat_ == primaryKey select c).First());

        }

        static IPrdcatView CreateProductcategory(tbl_Prdcat prdcat)
        {
            return ProductFactory.createPrdcat(prdcat.Prdcat_, prdcat.PrdcatNumber, prdcat.PrdcatName);
        }
    }
}

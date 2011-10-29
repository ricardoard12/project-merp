using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Views;


namespace BL
{
    public class MerpBLManager : IMerpBLManager
    {
        DAL.MerpDataManager DataLayerManager = new DAL.MerpDataManager();

        public List<DL.tbl_Prd> GetProducts(int Prdcat, int Anzahl, int Start)
        {
            return DataLayerManager.GetProducts(Prdcat, Anzahl, Start);
        }

        public Int32 GetProductCount(int Prdcat, int Anzahl, int Start)
        {
            return DataLayerManager.GetProductCategorieCount(Prdcat);
        }

        public List<DL.tbl_Prdcat> GetAllProductCategories()
        {
            return DataLayerManager.GetAllProductCategories();
        }

        public Int32 GetProductCategorieCount()
        {
            return DataLayerManager.GetProductCategorieCount();
        }

        public List<DL.tbl_Usr> GetUserByIdent(string Userident, int Anzahl, int Start)
        {
            return DataLayerManager.GetUserByIdent(Userident, Anzahl, Start);
        }

        public Int32 GetUserCountByIdent(string Userident)
        {
            return DataLayerManager.GetUserCountByIdent(Userident);
        }

        public void UpdateUser(User usr) 
        {
           DataLayerManager.UpdateUser(usr);
        }
        public void AddUser(User usr)
        {
            DataLayerManager.AddUser(usr);
        }
    }
}

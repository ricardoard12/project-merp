using System;
using System.Collections.Generic;
using Views;


namespace BL
{
    public class MerpBLManager
    {
        readonly DAL.MerpDataManager _dataLayerManager = new DAL.MerpDataManager();

        public List<Database.tbl_Prd> GetProducts(int Prdcat, int Anzahl, int Start)
        {
            return _dataLayerManager.GetProducts(Prdcat, Anzahl, Start);
        }

        public Int32 GetProductCount(int Prdcat, int Anzahl, int Start)
        {
            return _dataLayerManager.GetProductCategorieCount(Prdcat);
        }

        public List<Database.tbl_Prdcat> GetAllProductCategories()
        {
            return _dataLayerManager.GetAllProductCategories();
        }

        public Int32 GetProductCategorieCount()
        {
            return _dataLayerManager.GetProductCategorieCount();
        }

        public List<Database.tbl_Usr> GetUserByIdent(string Userident, int Anzahl, int Start)
        {
            return _dataLayerManager.GetUserByIdent(Userident, Anzahl, Start);
        }

        public Int32 GetUserCountByIdent(string Userident)
        {
            return _dataLayerManager.GetUserCountByIdent(Userident);
        }

        public void UpdateUser(User usr) 
        {
           _dataLayerManager.UpdateUser(usr);
        }
        public void AddUser(User usr)
        {
            _dataLayerManager.AddUser(usr);
        }
    }
}

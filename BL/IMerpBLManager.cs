using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views;

namespace BL
{
    public interface IMerpBLManager
    {
         List<DL.tbl_Prd> GetProducts(int Prdcat, int Anzahl, int Start);
         Int32 GetProductCount(int Prdcat, int Anzahl, int Start);
         List<DL.tbl_Prdcat> GetAllProductCategories();
         Int32 GetProductCategorieCount();
         List<DL.tbl_Usr> GetUserByIdent(string UserIdent, int Anzahl, int Start);
         Int32 GetUserCountByIdent(string UserIdent);
         void UpdateUser(User usr);
         void AddUser(User usr);
    }
}

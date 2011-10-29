using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Views;

namespace BL.Service
{
    public class MERPService : IMERPService
    {
        BL.MerpBLManager BusinessLogic = new BL.MerpBLManager();


        public PagedResult<Product> GetProducts(int Prdcat, int Anzahl, int Start)
        {
            PagedResult<Product> p = new PagedResult<Product>();

            p.Rows = (from r in BusinessLogic.GetProducts(Prdcat, Anzahl, Start) select new Product { Id = r.Prd_, Ean = r.PrdEAN, Name = r.PrdName, PricePurchase = Convert.ToDouble(r.PrdPricePurchase.Value), PriceSale = Convert.ToDouble(r.PrdPriceSale.Value) }).ToList();
            p.Total = BusinessLogic.GetProductCount(Prdcat, Anzahl, Start);
            return p;
            
        }

        public PagedResult<User> GetUserByIdent(string Userident, int Anzahl, int Start)
        {
            PagedResult<User> p = new PagedResult<User>();
            p.Rows = (from u in BusinessLogic.GetUserByIdent(Userident, Anzahl, Start) select new User { UsrId = u.usr_, UsrIdent = u.usrIdent, UsrName = u.usrName, UsrPassword = u.usrPassword, UsrLogin = u.usrLogedin }).ToList();
            p.Total = BusinessLogic.GetUserCountByIdent(Userident);
            return p;
        }

        public void UpdateUser(User usr)
        {
            BusinessLogic.UpdateUser(usr);
        }
        
        public void AddUser(User usr)
        {
            
            BusinessLogic.AddUser(usr);

        }
    }
}


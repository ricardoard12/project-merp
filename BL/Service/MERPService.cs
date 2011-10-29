using System;
using System.Linq;
using Views;

namespace BL.Service
{
    public class MERPService : IMERPService
    {
        BL.MerpBLManager BusinessLogic = new BL.MerpBLManager();


        public PagedResult<Product> GetProducts(int Prdcat, int Anzahl, int Start)
        {
            PagedResult<Product> p = new PagedResult<Product>();

            p.Rows = Enumerable.ToList<Product>((from r in BusinessLogic.GetProducts(Prdcat, Anzahl, Start) select new Product { Id = r.Prd_, Ean = r.PrdEAN, Name = r.PrdName, PricePurchase = Convert.ToDouble((double) r.PrdPricePurchase.Value), PriceSale = Convert.ToDouble((double) r.PrdPriceSale.Value) }));
            p.Total = BusinessLogic.GetProductCount(Prdcat, Anzahl, Start);
            return p;
            
        }

        public PagedResult<User> GetUserByIdent(string Userident, int Anzahl, int Start)
        {
            PagedResult<User> p = new PagedResult<User>();
            p.Rows = Enumerable.ToList<User>((from u in BusinessLogic.GetUserByIdent(Userident, Anzahl, Start) select new User { UsrId = u.usr_, UsrIdent = u.usrIdent, UsrName = u.usrName, UsrPassword = u.usrPassword, UsrLogin = u.usrLogedin }));
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


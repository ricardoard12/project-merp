using System;
using System.Linq;
using Views;
using Views.Stammdaten.Product;
using Views.Stammdaten.User;

namespace BL.Service
{
    public class MerpService : IMERPService
    {
        BL.MerpBLManager BusinessLogic = new BL.MerpBLManager();


        public PagedResult<ProductView> GetProducts(int Prdcat, int Anzahl, int Start)
        {
            PagedResult<ProductView> p = new PagedResult<ProductView>();

            p.Rows = Enumerable.ToList<ProductView>((from r in BusinessLogic.GetProducts(Prdcat, Anzahl, Start) select new ProductView { Id = r.Prd_, Ean = r.PrdEAN, Name = r.PrdName, PricePurchase = Convert.ToDouble((double) r.PrdPricePurchase.Value), PriceSale = Convert.ToDouble((double) r.PrdPriceSale.Value) }));
            p.Total = BusinessLogic.GetProductCount(Prdcat, Anzahl, Start);
            return p;
            
        }

        public PagedResult<UserView> GetUserByIdent(string Userident, int Anzahl, int Start)
        {
            PagedResult<UserView> p = new PagedResult<UserView>();
            p.Rows = Enumerable.ToList<UserView>((from u in BusinessLogic.GetUserByIdent(Userident, Anzahl, Start) select new UserView { UsrId = u.Usr_, UsrIdent = u.UsrIdent, UsrName = u.UsrName, UsrPassword = u.UsrPassword, UsrLogedIn = u.UsrLogedin }));
            p.Total = BusinessLogic.GetUserCountByIdent(Userident);
            return p;
        }

        public void UpdateUser(UserView usr)
        {
            BusinessLogic.UpdateUser(usr);
        }
        
        public void AddUser(UserView usr)
        {
            
            BusinessLogic.AddUser(usr);

        }
    }
}


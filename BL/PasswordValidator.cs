using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using DAL.Selections.Stammdaten.User;
using Views.Stammdaten.User;

namespace BL {
    public class PasswordValidator : UserNamePasswordValidator {
        public override void Validate(string userName, string password) {

            IUserView user = UserDataFactory.UserByIdent(userName);
            if (user == null) {
                throw new SecurityTokenException("Userident not found");
            }


            if (user.UsrPassword != password) {
                throw new SecurityTokenException("Wrong Password");
            }
           
            
        }
    }
}

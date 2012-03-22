using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using DAL.Selections.Stammdaten.User;
using Views.Security.ErrorException;
using Views.Stammdaten.User;

namespace BL {
    public class PasswordValidator : UserNamePasswordValidator
    {

        [FaultContract(typeof(LoginError))]
        public override void Validate(string userName, string password) {
            if (userName.Length <= 0 || password.Length <= 0) {
                // Message.CreateMessage(MessageVersion.Default, "Kein Benutzername oder Passwort angegeben");
                throw new FaultException<LoginError>(new LoginError("Kein Benutzername oder Passwort angegeben"));

            }
            IUserView user = UserDataFactory.UserByIdent(userName);
            if (user == null) {
                //  Message.CreateMessage(MessageVersion.Default, "Userident not found");
                throw new FaultException<LoginError>(new LoginError("Userident not found"));
            }


            if (user.UsrPassword != password) {
                //    Message.CreateMessage(MessageVersion.Default, "Wrong Password");
                throw new FaultException<LoginError>(new LoginError("Wrong Password"));
            }



        }
    }
}

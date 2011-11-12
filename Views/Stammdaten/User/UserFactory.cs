

namespace Views.Stammdaten.User {
   public class UserFactory {


        public static IUserView CreateNewUser() {
            return new UserView();
        }

        public static IUserView CreateUser(
            int usrNumber, string usrName, string usrIdent, bool? usrIsEmployer, string usrPassword) {

                return new UserView {
                UsrId = 1,
                UsrIdent = usrIdent,
                UsrIsEmployer = usrIsEmployer,
                UsrName = usrName,
                UsrNumber = usrNumber,
                UsrPassword = usrPassword

            };

        }

    }
}

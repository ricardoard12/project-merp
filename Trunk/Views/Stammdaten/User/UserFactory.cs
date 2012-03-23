

namespace Views.Stammdaten.User
{
    public class UserFactory
    {


        public static IUserView CreateNewUser()
        {
            return new UserView();
        }

        public static IUserView CreateUser(
            int usrId, int usrNumber, string usrName, string usrIdent, bool? usrIsEmployer, string usrPassword,
            bool isLogedin)
        {

            return new UserView(usrId, usrNumber, usrName, usrIdent, usrIsEmployer, usrPassword, isLogedin);

        }


    }
}

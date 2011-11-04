

using Views.Stammdaten.User;

namespace WpfApplication1.Model.Stammdaten {
    class UserFactory {


      public static UserView CreateNewUser() {
          return new UserView();
      }

      public static UserView CreateUser(
          int usrNumber, string usrName, string usrIdent, bool usrIsEmployer, string usrPassword) {

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

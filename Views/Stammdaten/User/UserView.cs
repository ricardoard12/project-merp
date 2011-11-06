using System;


namespace Views.Stammdaten.User
{
    public class UserView
    {
        public int UsrId { get; set; }

        public int UsrNumber { get; set; }
    
        public string UsrIdent { get; set; }

        public string UsrName { get; set; }

        public bool? UsrIsEmployer { get; set; }

        public string UsrPassword { get; set; }

        public bool UsrLogedIn { get; set; }

        }
}

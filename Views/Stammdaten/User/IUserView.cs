using System;


namespace Views.Stammdaten.User
{
    public abstract class IUserView
    {
        public abstract int UsrId { get; set; }
        public abstract int UsrNumber { get; set; }
        public abstract string UsrIdent { get; set; }
        public abstract string UsrName { get; set; }
        public abstract bool? UsrIsEmployer { get; set; }
        public abstract string UsrPassword { get; set; }
        public abstract bool UsrLogedIn { get; set; }
    }
}

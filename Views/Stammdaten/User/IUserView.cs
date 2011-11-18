using System;


namespace Views.Stammdaten.User
{
    public interface IUserView
    { 
        
          int UsrId { get; set; }
          int UsrNumber { get; set; }
          string UsrIdent { get; set; }
          string UsrName { get; set; }
          bool? UsrIsEmployer { get; set; }
          string UsrPassword { get; set; }
          bool UsrLogedIn { get; set; }
        
    }
}

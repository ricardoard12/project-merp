using System;
using System.Runtime.Serialization;


namespace Views.Stammdaten.User
{
    public interface IUserView : ISerializable 
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views.Stammdaten.User {
    public class UserView : IUserView {
  
        public override int UsrId { get; set; }
        public override int UsrNumber { get; set; }
        public override string UsrIdent { get; set; }
        public override string UsrName { get; set; }
        public override bool? UsrIsEmployer { get; set; }
        public override string UsrPassword { get; set; }
        public override bool UsrLogedIn { get; set; }
    }
}

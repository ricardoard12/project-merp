using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Stammdaten.User {
    [Serializable]
    public class UserView : IUserView {
  
        public  int UsrId { get; set; }
        public  int UsrNumber { get; set; }
        public  string UsrIdent { get; set; }
        public  string UsrName { get; set; }
        public  bool? UsrIsEmployer { get; set; }
        public  string UsrPassword { get; set; }
        public  bool UsrLogedIn { get; set; }

        public UserView(int usrId, int usrNumber, string usrIdent, string userName, bool? usrIsEmployer, string usrPassword, bool usrLogedin)
        {
            UsrId = usrId;
            UsrNumber = usrNumber;
            UsrIdent = usrIdent;
            UsrName = userName;
            UsrIsEmployer = usrIsEmployer;
            UsrPassword = usrPassword;
            UsrLogedIn = usrLogedin;
        }


        public UserView()
        {
            
        }

        protected UserView(SerializationInfo info, StreamingContext contect)
        {
            UsrId = (int)info.GetValue("UsrId", typeof (int));
            UsrNumber = (int)info.GetValue("UsrNumber", typeof(int));
            UsrIdent = (string)info.GetValue("UsrIdent", typeof(string));
            UsrName = (string)info.GetValue("UsrName", typeof(string));
            UsrIsEmployer = (bool)info.GetValue("UsrIsEmployer", typeof(bool));
            UsrPassword = (string)info.GetValue("UsrPassword", typeof(string));
            UsrLogedIn = (bool)info.GetValue("UsrLogedIn", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("UsrId", UsrId);
            info.AddValue("UsrNumber", UsrNumber);
            info.AddValue("UsrIdent", UsrIdent);
            info.AddValue("UsrName", UsrName);
            info.AddValue("UsrIsEmployer", UsrIsEmployer);
            info.AddValue("UsrPassword", UsrPassword);
            info.AddValue("UsrLogedIn", UsrLogedIn);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}  {2}", UsrNumber, UsrIdent, UsrName);
        }
    }
}

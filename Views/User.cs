using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Views
{
    public class User
    {
        private Int32 _usrId;
        private string _usrIdent;
        private string _usrName;
        private string _usrPassword;
        private bool _usrLogedIn;

        public User()
        {
        }


        public User(Int32 usrid, string usrident, string usrName, string usrpassword, bool logedin)
        {
            _usrId = usrid;
            _usrIdent = usrident;
            _usrName = usrName;
            _usrPassword = usrpassword;
            _usrLogedIn = logedin;
        }

        public bool UsrLogin
        {
            get { return _usrLogedIn; }
            set { _usrLogedIn = value; }
        }

        public Int32 UsrId
        {
            get { return _usrId; }
            set { _usrId = value; }
        }

        public string UsrName
        {
            get { return _usrName; }
            set { _usrName = value; }
        }
        public string UsrPassword
        {
            get { return _usrPassword; }
            set { _usrPassword = value; }
        }

        public string UsrIdent
        {
            get { return _usrIdent; }
            set { _usrIdent = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public static class Session
    {
        private static string _username;
        private static string _password;

        public static string Username {
            get { return _username; }
            set { _username = value; }
        }

        public static string Password {
            get { return _password; }
            set { _password = value; }
        }

    }
}


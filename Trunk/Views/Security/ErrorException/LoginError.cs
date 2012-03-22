using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Security.ErrorException
{

    [DataContract]
    public class LoginError
    {
        private string _report;

        public LoginError(string message) {
            this._report = message;
        }

        [DataMemberAttribute]
        public string Message {
            get { return this._report; }
            set { this._report = value; }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BL {

    [DataContract]
    public class LoginFault {
        private string _operation;
        private string _problemType;

        public LoginFault(string methode, string message) {
            _operation = methode;
            _problemType = message;
        }

        [DataMember]
        public string Operation {
            get { return _operation; }
            set { _operation = value; }
        }

        [DataMember]
        public string ProblemType {
            get { return _problemType; }
            set { _problemType = value; }
        }
    }
}

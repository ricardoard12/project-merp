using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1.Events {
    public class BooleanEventArg : EventArgs
    {
        public bool BooleanValue { get; set; }
        
        public BooleanEventArg(bool booleanValue) {
            this.BooleanValue = booleanValue;
        }
    }
}

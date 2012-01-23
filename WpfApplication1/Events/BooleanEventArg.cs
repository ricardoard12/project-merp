using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1.Events {
    public class BooleanEventArg : EventArgs
    {
        public bool Value { get; set; }
        
        public BooleanEventArg(bool Value) {
            this.Value = Value;
        }
    }
}

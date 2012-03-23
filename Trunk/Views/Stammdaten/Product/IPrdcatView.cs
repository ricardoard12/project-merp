using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Stammdaten.Product
{
    public interface IPrdcatView : ISerializable 
    {
        int PrdcatId { get; set; }
        int? PrdcatNumber { get; set; }
        string PrdcatName { get; set; }
    }
}

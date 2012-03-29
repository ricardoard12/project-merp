using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Stammdaten.Product
{
    [Serializable]
    class PrdcatView : IPrdcatView
    {
        protected PrdcatView(SerializationInfo info, StreamingContext contect)
        {
            PrdcatId = (int)info.GetValue("PrdcatId", typeof(int));
            PrdcatNumber = (int?) info.GetValue("PrdcatNumber", typeof (int));
            PrdcatName = (string) info.GetValue("PrdcatName", typeof (string));
        }

        public  PrdcatView()
        {
            
        }

        public PrdcatView(int id, int? prdcatNumber, string prdcatName)
        {
            PrdcatId = id;
            PrdcatNumber = prdcatNumber;
            PrdcatName = prdcatName;

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PrdcatId", PrdcatId);
            info.AddValue("PrdcatNumber", PrdcatNumber);
            info.AddValue("PrdcatName", PrdcatName);
        }

        public int PrdcatId { get; set; }
        public int? PrdcatNumber { get; set; }
        public string PrdcatName { get; set; }

        public override string ToString()
        {
            return (PrdcatNumber+"; "+PrdcatName).ToString();
        }
    }
}

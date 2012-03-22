using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Views.Stammdaten.User;

namespace Views
{
    [Serializable]
    public class PagedResult<T>
    {
        public int Total;
        public List<T> Rows; 
    }
}

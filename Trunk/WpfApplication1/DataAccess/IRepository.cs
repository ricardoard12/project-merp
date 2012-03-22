using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Views.Security.Connection;

namespace WpfApplication1.DataAccess
{
    public interface IRepository<T>
    {
        IConnection<T> Connection { get; }

    }
}

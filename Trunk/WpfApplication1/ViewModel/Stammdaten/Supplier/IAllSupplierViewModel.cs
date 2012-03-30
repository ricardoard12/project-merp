using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views.Stammdaten.Product;
using Views.Stammdaten.Supplier;

namespace WpfApplication1.ViewModel.Stammdaten.Supplier
{
    public interface IAllSupplierViewModel
    {
        ObservableCollection<ISupplierView> Suppliers { get; }
    }
}

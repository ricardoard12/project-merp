using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views.Stammdaten.Product;

namespace WpfApplication1.ViewModel.Stammdaten.Product
{
    public interface IAllProductsViewModel
    {
        ObservableCollection<IProductView> Products { get; }

    }
}

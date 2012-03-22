using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApplication1.ViewModel.Stammdaten.Product
{
    public interface IProductViewModel : IWorkspaceViewModel
    {
        int? ProductNumber { get; set; }
        string ProductName { get; set; }
        string Ean { get; set; }
        double? PricePurchase { get; set; }
        double? PriceSale { get; set; }
        bool IsSelected { get; set; }
        ICommand SaveCommand { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Purchase;
using Views.Stammdaten.Product;

namespace WpfApplication1.ViewModel.BusinessProcesses.Purchase
{
    public interface IAllPurchaseHeaderViewModel
    {
        ObservableCollection<IPurchaseHeaderView> PurchaseHeaders { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views.BusinessProcesses.Sales.Offer;
using Views.Stammdaten.Product;

namespace WpfApplication1.ViewModel.BusinessProcesses.Distribution
{
    public interface IAllDistributionViewModel
    {
        ObservableCollection<ISalesHeaderView> Distribution { get; }
    }
}

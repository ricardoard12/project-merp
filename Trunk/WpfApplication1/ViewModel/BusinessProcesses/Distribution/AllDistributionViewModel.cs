using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrontEnd.DataAccess.Stammdaten.Customer;
using FrontEnd.DataAccess.Stammdaten.Product;
using FrontEnd.ViewModel;
using FrontEnd.ViewModel.Stammdaten.Customer;
using FrontEnd.ViewModel.Stammdaten.Product;
using Views.BusinessProcesses.Sales.Offer;
using Views.Stammdaten.Product;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;

namespace WpfApplication1.ViewModel.BusinessProcesses.Distribution
{
    public class AllDistributionViewModel : WorkspaceViewModel, IAllDistributionViewModel
    {
        private QuattroRepository quattroRepository;
        private DistributionViewModel distributionViewModel;
        private ObservableCollection<ISalesHeaderView> salesHeaderView;

        public AllDistributionViewModel()
        {
            quattroRepository = new QuattroRepository();
            distributionViewModel = new DistributionViewModel();
        }

        public ObservableCollection<ISalesHeaderView> Distribution
        {
            get
            {
                if (salesHeaderView == null || salesHeaderView.Count == 0)
                {
                    salesHeaderView = new ObservableCollection<ISalesHeaderView>(quattroRepository.BySpecifiedType(2));
                }
                return salesHeaderView;
            }
        }
    }
}
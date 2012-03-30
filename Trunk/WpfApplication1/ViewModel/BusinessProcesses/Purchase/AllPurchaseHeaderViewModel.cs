using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FrontEnd.DataAccess.Stammdaten.Product;
using FrontEnd.ViewModel;
using FrontEnd.ViewModel.Stammdaten.Product;
using Views.BusinessProcesses.Purchase;
using Views.Stammdaten.Product;
using WpfApplication1.DataAccess.BusinessProcesses.Purchase;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;

namespace WpfApplication1.ViewModel.BusinessProcesses.Purchase
{
    public class AllPurchaseHeaderViewModel : WorkspaceViewModel, IAllPurchaseHeaderViewModel
    {
        private PurchaseHeaderRepository purchaseHeaderRepository;
        private PurchaseHeaderViewModel purchaseHeaderViewModel;
        private ObservableCollection<IPurchaseHeaderView> purchaseHeaderView;

        public AllPurchaseHeaderViewModel()
        {
            purchaseHeaderRepository = new PurchaseHeaderRepository();
            purchaseHeaderViewModel = new PurchaseHeaderViewModel();
        }

        public ObservableCollection<IPurchaseHeaderView> PurchaseHeaders
        {
            get
            {
                if (purchaseHeaderView == null || purchaseHeaderView.Count == 0)
                {
                    purchaseHeaderView = new ObservableCollection<IPurchaseHeaderView>(purchaseHeaderRepository.GetAllPurchaseHeader());
                }
                return purchaseHeaderView;
            }
        }
    }
}

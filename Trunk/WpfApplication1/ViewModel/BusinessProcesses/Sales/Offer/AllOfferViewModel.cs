using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FrontEnd.DataAccess.Stammdaten.Product;
using FrontEnd.ViewModel;
using FrontEnd.ViewModel.Stammdaten.Product;
using Views.BusinessProcesses.Sales.Offer;
using Views.Stammdaten.Product;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Offer
{
    public class AllOfferViewModel: WorkspaceViewModel, IAllOfferViewModel
    {
        private QuattroRepository quattroRepository;
        private OfferViewModel offerViewModel;
        private ObservableCollection<ISalesHeaderView> salesHeaderViews;

        public AllOfferViewModel()
        {
            quattroRepository = new QuattroRepository();
            offerViewModel = new OfferViewModel();
        }
        
        public ObservableCollection<ISalesHeaderView> Offers
        {
            get
            {
                if (salesHeaderViews == null || salesHeaderViews.Count == 0)
                {
                    salesHeaderViews = new ObservableCollection<ISalesHeaderView>(quattroRepository.BySpecifiedType(1));
                }
                return salesHeaderViews;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using WpfApplication1.DataAccess.BusinessProcesses.Sales.Offer;

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Offer
{
    public class OfferViewModel : WorkspaceViewModel
    {
        private IOfferRepository offerRepository;
        private IOfferView offerView;
        private string[] typeOptions;
        private bool isSelected;

        public OfferViewModel(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
            this.offerView = OfferFactory.createNew();
        }

        #region Constructors
        
        public OfferViewModel(IOfferView offerView, IOfferRepository offerRepository)
        {
            if (offerView == null)
                throw new ArgumentNullException("offerView");

            if (offerRepository == null)
                throw new ArgumentNullException("offerRepository");

            this.offerView = offerView;
            this.offerRepository = offerRepository;
        }

        #endregion Constructors

        #region Offer Properties

        public int OfferNumber
        {
            get { return offerView.OfferNumber; }
            set
            {
                if (value == offerView.OfferNumber)
                    return;

                offerView.OfferNumber = value;
                base.OnPropertyChanged("OfferNumber");
            }
        }

        public int OfferCustomer
        {
            get { return offerView.OfferCustomer; }
            set
            {
                if (value == offerView.OfferCustomer)
                    return;

                offerView.OfferCustomer = value;
                base.OnPropertyChanged("OfferCustomer");
            }
        }

        #endregion Offer Properties

    }
}

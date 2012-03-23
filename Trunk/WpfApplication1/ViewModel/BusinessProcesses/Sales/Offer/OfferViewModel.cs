using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;
using WpfApplication1.DataAccess.BusinessProcesses.Sales.Offer;

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Offer
{
    public class OfferViewModel : WorkspaceViewModel
    {
        private IQuattroRepository quattroRepository;
        private ISalesHeaderView _salesHeaderView;
        private string[] typeOptions;
        private bool isSelected;

        public OfferViewModel(IOfferRepository offerRepository)
        {
            this.quattroRepository = quattroRepository;
            this._salesHeaderView = SalesFactory.createNew();
        }

        #region Constructors
        
        public OfferViewModel(ISalesHeaderView _salesHeaderView, IQuattroRepository quattroRepository)
        {
            if (_salesHeaderView == null)
                throw new ArgumentNullException("_salesHeaderView");

            if (quattroRepository == null)
                throw new ArgumentNullException("offerRepository");

            this._salesHeaderView = _salesHeaderView;
            this.quattroRepository = quattroRepository;
        }

        #endregion Constructors

        #region Offer Properties

        public int OfferNumber
        {
            get { return _salesHeaderView.OfferNumber; }
            set
            {
                if (value == _salesHeaderView.OfferNumber)
                    return;

                _salesHeaderView.OfferNumber = value;
                base.OnPropertyChanged("OfferNumber");
            }
        }

        public int OfferCustomer
        {
            get { return _salesHeaderView.OfferCustomer; }
            set
            {
                if (value == _salesHeaderView.OfferCustomer)
                    return;

                _salesHeaderView.OfferCustomer = value;
                base.OnPropertyChanged("OfferCustomer");
            }
        }

        #endregion Offer Properties

    }
}

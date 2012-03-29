using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using FrontEnd.DataAccess.

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Order
{
    public class OrderViewModel : WorkspaceViewModel
    {
        private IQuattroRepository quattroRepository;
        private ISalesHeaderView _salesHeaderView;
        private string[] typeOptions;
        private bool isSelected;

        public OrderViewModel(IOfferRepository offerRepository)
        {
            this.quattroRepository = quattroRepository;
            this._salesHeaderView = SalesFactory.createNew();
        }

        #region Constructors

        public OrderViewModel(ISalesHeaderView _salesHeaderView, IQuattroRepository quattroRepository)
        {
            if (_salesHeaderView == null)
                throw new ArgumentNullException("_salesHeaderView");

            if (quattroRepository == null)
                throw new ArgumentNullException("orderRepository");

            this._salesHeaderView = _salesHeaderView;
            this.quattroRepository = quattroRepository;
        }

        #endregion Constructors

        #region Order Properties

        public int? OfferNumber
        {
            get { return _salesHeaderView.OfferNumber; }
            set
            {
                if (value == _salesHeaderView.OfferNumber)
                    return;

                _salesHeaderView.OfferNumber = value;
                base.OnPropertyChanged("OrderNumber");
            }
        }

        public int? OfferCustomer
        {
            get { return _salesHeaderView.OfferCustomer; }
            set
            {
                if (value == _salesHeaderView.OfferCustomer)
                    return;

                _salesHeaderView.OfferCustomer = value;
                base.OnPropertyChanged("OrderCustomer");
            }
        }

        #endregion Order Properties
    }
}

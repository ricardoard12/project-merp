using System;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Order
{
    public class OrderViewModel : WorkspaceViewModel
    {
        private IQuattroRepository quattroRepository;
        private ISalesHeaderView _salesHeaderView;
        private string[] typeOptions;
        private bool isSelected;

        public OrderViewModel()
        {
            this.quattroRepository = quattroRepository;
            this._salesHeaderView = SalesFactory.createNewSalesHeader();
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
            get { return _salesHeaderView.SalesHeaderNumber; }
            set
            {
                if (value == _salesHeaderView.SalesHeaderNumber)
                    return;

                _salesHeaderView.SalesHeaderNumber = value;
                base.OnPropertyChanged("SalesHeaderNumber");
            }
        }

        public int? OfferCustomer
        {
            get { return _salesHeaderView.SalesHeaderCustomer; }
            set
            {
                if (value == _salesHeaderView.SalesHeaderCustomer)
                    return;

                _salesHeaderView.SalesHeaderCustomer = value;
                base.OnPropertyChanged("SalesHeaderCustomer");
            }
        }

        #endregion Order Properties
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FrontEnd;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;
using WpfApplication1.DataAccess.BusinessProcesses.Sales.Offer;

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Offer
{
    public class OfferViewModel : WorkspaceViewModel
    {
        private IQuattroRepository quattroRepository;
        private ISalesHeaderView salesHeaderView;
        private string[] typeOptions;
        private bool isSelected;
        private ICommand saveCommand;

        public OfferViewModel(IOfferRepository offerRepository)
        {
            this.quattroRepository = quattroRepository;
            this.salesHeaderView = SalesFactory.createNew();
        }

        #region Constructors
        
        public OfferViewModel(ISalesHeaderView salesHeaderView, IQuattroRepository quattroRepository)
        {
            if (salesHeaderView == null)
                throw new ArgumentNullException("_salesHeaderView");

            if (quattroRepository == null)
                throw new ArgumentNullException("quattroRepository");

            this.salesHeaderView = salesHeaderView;
            this.quattroRepository = quattroRepository;
        }

        #endregion Constructors

        #region Offer Properties

        public int OfferId
        {
            get { return salesHeaderView.OfferId; }
            set
            {
                if (value == salesHeaderView.OfferId)
                    return;

                salesHeaderView.OfferId = value;
                base.OnPropertyChanged("OfferId");
            }
        }

        public int? OfferNumber
        {
            get { return salesHeaderView.OfferNumber; }
            set
            {
                if (value == salesHeaderView.OfferNumber)
                    return;

                salesHeaderView.OfferNumber = value;
                base.OnPropertyChanged("OfferNumber");
            }
        }

        public int? OfferCustomer
        {
            get { return salesHeaderView.OfferCustomer; }
            set
            {
                if (value == salesHeaderView.OfferCustomer)
                    return;

                salesHeaderView.OfferCustomer = value;
                base.OnPropertyChanged("OfferCustomer");
            }
        }

        public DateTime? OfferCreateDate
        {
            get { return salesHeaderView.OfferCreateDate; }
            set
            {
                if (value == salesHeaderView.OfferCreateDate)
                    return;

                salesHeaderView.OfferCreateDate = value;
                base.OnPropertyChanged("OfferCreateDate");
            }
        }

        #endregion Offer Properties

        #region Commands

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(param => Save(), param => CanSave));
            }
        }

        private void Save()
        {
            this.quattroRepository.AddQuattro(salesHeaderView);
        }

        private bool CanSave
        {
            get { return salesHeaderView.IsValid; }
        }

        #endregion Commands
    }
}

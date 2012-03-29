using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FrontEnd;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Sales.Offer;
using Views.Stammdaten.User;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;

namespace WpfApplication1.ViewModel.BusinessProcesses.Sales.Offer
{
    public class OfferViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        private IQuattroRepository quattroRepository;
        private ISalesHeaderView salesHeaderView;
        private string[] typeOptions;
        private bool isSelected;
        private ICommand saveCommand;
        private string offerType;
        

        #region Constructors

        public OfferViewModel()
        {
            this.quattroRepository = quattroRepository;
            this.salesHeaderView = SalesFactory.createNewSalesHeader();
        }

        public OfferViewModel(ISalesHeaderView salesHeaderView, IQuattroRepository quattroRepository)
        {
            if (salesHeaderView == null)
                throw new ArgumentNullException("salesHeaderView");

            if (quattroRepository == null)
                throw new ArgumentNullException("quattroRepository");

            this.salesHeaderView = salesHeaderView;
            this.quattroRepository = quattroRepository;
        }

        #endregion Constructors

        #region Offer Properties

        public int OfferId
        {
            get { return salesHeaderView.SalesHeaderId; }
            set
            {
                if (value == salesHeaderView.SalesHeaderId)
                    return;

                salesHeaderView.SalesHeaderId = value;
                base.OnPropertyChanged("SalesHeaderId");
            }
        }

        public int? OfferNumber
        {

            get { return salesHeaderView.SalesHeaderNumber; }
 
            set
            {
                if (value == salesHeaderView.SalesHeaderNumber)
                   return;
                salesHeaderView.SalesHeaderNumber = value;
                base.OnPropertyChanged("SalesHeaderNumber");
            }
        }

        public int? OfferCustomer
        {

            get { return salesHeaderView.SalesHeaderCustomer; }

            set
            {
                if (value == salesHeaderView.SalesHeaderCustomer)
                    return;
                salesHeaderView.SalesHeaderCustomer = value;
                base.OnPropertyChanged("SalesHeaderCustomer");

            }
        }

        public DateTime? OfferCreateDate
        {
            get { return salesHeaderView.SalesHeaderCreateDate; }
            set
            {
                if (value == salesHeaderView.SalesHeaderCreateDate)
                    return;

                salesHeaderView.SalesHeaderCreateDate = value;
                base.OnPropertyChanged("SalesHeaderCreateDate");
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
       

        #region IDataErrors

        string IDataErrorInfo.this[string propertyName]
        {
            get 
            { 
                string error = null;
                error = (salesHeaderView as IDataErrorInfo)[propertyName];
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }

        string IDataErrorInfo.Error
        {
            get { return (salesHeaderView as IDataErrorInfo).Error; }
        }

        #endregion 
    }
}

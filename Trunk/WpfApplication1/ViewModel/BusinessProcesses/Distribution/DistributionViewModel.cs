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

namespace WpfApplication1.ViewModel.BusinessProcesses.Distribution
{
    public class DistributionViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        private IQuattroRepository quattroRepository;
        private ISalesHeaderView salesHeaderView;
        private string[] typeOptions;
        private bool isSelected;
        private ICommand saveCommand;

        #region constructors

        public DistributionViewModel()
        {
            this.quattroRepository = quattroRepository;
            salesHeaderView = SalesFactory.createNewSalesHeader();
        }

        public DistributionViewModel(ISalesHeaderView salesHeaderView, IQuattroRepository quattroRepository)
        {
            if (salesHeaderView == null)
                throw new ArgumentNullException("salesHeaderView");

            if (quattroRepository == null)
                throw new ArgumentNullException("quattroRepository");

            this.salesHeaderView = salesHeaderView;
            this.quattroRepository = quattroRepository;
        }

        #endregion constructors

        #region distribution properties

        public int SalesHeaderID
        {
            get { return salesHeaderView.SalesHeaderId; }
            set
            {
                if (value == salesHeaderView.SalesHeaderId)
                    return;

                salesHeaderView.SalesHeaderId = value;
                base.OnPropertyChanged("SalesHeaderID");
            }
        }

        public int? SalesHeaderNumber
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

        public int? SalesHeaderCustomer
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

        public DateTime? SalesHeaderCreateDate
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

        public int? SalesHeaderType
        {
            get { return salesHeaderView.SalesHeaderType; }
            set
            {                
                if (value == salesHeaderView.SalesHeaderType)
                    return;
                

                salesHeaderView.SalesHeaderType = 1;
                base.OnPropertyChanged("SalesHeaderType");
            }
        }

        #endregion distribution properties

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
            this.quattroRepository.AddHeaderSales(salesHeaderView);
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

        string IDataErrorInfo.Error { get { return null; } }

        #endregion 
    }
}

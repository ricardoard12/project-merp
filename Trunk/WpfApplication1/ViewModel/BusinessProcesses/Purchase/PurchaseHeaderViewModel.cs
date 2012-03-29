using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FrontEnd;
using FrontEnd.DataAccess.Stammdaten.User;
using FrontEnd.ViewModel;
using Views.BusinessProcesses.Purchase;
using Views.Stammdaten.Supplier;
using Views.Stammdaten.User;
using WpfApplication1.DataAccess.BusinessProcesses.Sales;
using WpfApplication1.DataAccess.Stammdaten.Supplier;

namespace WpfApplication1.ViewModel.BusinessProcesses.Purchase
{
    public class PurchaseHeaderViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        private IQuattroRepository quattroRepository;
        private IPurchaseHeaderView purchaseHeaderView;
        private ICommand saveCommand;

        #region Constructors

        public PurchaseHeaderViewModel()
        {
            this.quattroRepository = new QuattroRepository();
            this.purchaseHeaderView = PurchaseFactory.createNewPurchaseHeader();
        }

        #endregion Constructors

        #region Supplier Properties

        public DateTime? PurchaseHeaderCreateDate
        {
            get { return purchaseHeaderView.PurchaseHeaderCreateDate; }
            set
            {
                if (value == purchaseHeaderView.PurchaseHeaderCreateDate)
                    return;

                purchaseHeaderView.PurchaseHeaderCreateDate = value;
                base.OnPropertyChanged("PurchaseHeaderCreateDate");
            }
        }

        public int? PurchaseHeaderCustomer
        {
            get { return purchaseHeaderView.PurchaseHeaderCustomer; }
            set
            {
                if (value == purchaseHeaderView.PurchaseHeaderCustomer)
                    return;

                purchaseHeaderView.PurchaseHeaderCustomer = value;
                base.OnPropertyChanged("PurchaseHeaderCustomer");
            }
        }

        public int? PurchaseHeaderNumber
        {
            get { return purchaseHeaderView.PurchaseHeaderNumber; }
            set
            {
                if (value == purchaseHeaderView.PurchaseHeaderNumber)
                    return;

                purchaseHeaderView.PurchaseHeaderNumber = value;
                base.OnPropertyChanged("PurchaseHeaderNumber");
            }
        }

        public int? PurchaseHeaderType
        {
            get { return purchaseHeaderView.PurchaseHeaderType; }
        }

        public int PurchaseHeaderId
        {
            get { return purchaseHeaderView.PurchaseHeaderId; }
        }

        #endregion Supplier Properties

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
            this.quattroRepository.AddPurchaseHeader(purchaseHeaderView);
        }

        private bool CanSave
        {
            get { return purchaseHeaderView.IsValid; }
        }

        #endregion

        #region Presentation Properties

        #endregion Presentation Properties

        #region IDataErrors

        string IDataErrorInfo.Error
        {
            get { return (purchaseHeaderView as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;
                error = (purchaseHeaderView as IDataErrorInfo)[propertyName];
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }

        #endregion 
    }
}

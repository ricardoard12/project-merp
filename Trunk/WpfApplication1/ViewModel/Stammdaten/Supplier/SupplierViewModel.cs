using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrontEnd.ViewModel;
using Views.Stammdaten.Supplier;
using WpfApplication1.DataAccess.Stammdaten.Supplier;

namespace WpfApplication1.ViewModel.Stammdaten.Supplier
{
    public class SupplierViewModel : WorkspaceViewModel, IDataErrorInfo 
    {
        private ISupplierRepository supplierRepository;
        private ISupplierView supplierView;
        private string[] typeOptions;
        private bool isSelected;


        #region Constructors

        public SupplierViewModel()
        {
            this.supplierRepository = new SupplierRepository();
            this.supplierView = SupplierFactory.createNew();
            
        }

        #endregion Constructors


        #region Supplier Properties

        public string SupFirstname
        {
            get { return supplierView.SupFirstname; }
            set
            {
                if (value == supplierView.SupFirstname)
                    return;

                supplierView.SupFirstname = value;
                base.OnPropertyChanged("SupFirstname");
            }
        }

        public string SupLastname
        {
            get { return supplierView.SupLastname; }
            set
            {
                if (value == supplierView.SupLastname)
                    return;

                supplierView.SupLastname = value;
                base.OnPropertyChanged("SupLastname");
            }
        }

        public string SupContactname
        {
            get { return supplierView.SupContactname; }
            set
            {
                if (value == supplierView.SupContactname)
                    return;

                supplierView.SupContactname = value;
                base.OnPropertyChanged("SupContactname");
            }
        }

        public bool? SupIsCompany
        {
            get { return supplierView.SupIsCompany; }
        }

        public int SupId
        {
            get { return supplierView.SupId; }
        }

        public int? SupNumber
        {
            get { return supplierView.SupNumber; }
            set
            {
                if (value == supplierView.SupNumber)
                    return;

                supplierView.SupNumber = value;
                base.OnPropertyChanged("SupNumber");
            }
        }

        public int? SupUsrId
        {
            get { return supplierView.SupUsrId; }
            set
            {
                if (value == supplierView.SupUsrId)
                    return;

                supplierView.SupUsrId = value;
                base.OnPropertyChanged("SupUsrId");
            }
        }
        #endregion Supplier Properties

        #region Presentation Properties

        public string SupplierType
        {
            get { return SupplierType; }
            set
            {
                if (value == SupplierType || String.IsNullOrEmpty(value))
                    return;

                SupplierType = value;
                
                if (SupplierType == "Company")
                {
                    supplierView.SupIsCompany = true;
                }
                else if (SupplierType == "Person")
                {
                    supplierView.SupIsCompany = false;
                }

                base.OnPropertyChanged("SupplierType");
                base.OnPropertyChanged("SupLastname");
            }
        }

        public string[] SupplierTypeOptions
        {
            get
            {
                if (this.typeOptions == null)
                {
                    typeOptions = new string[]
                        {
                            "NotSpecified",
                            "Person",
                            "Company"
                        };
                }

                return typeOptions;
            }
          
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value == isSelected)
                    return;

                isSelected = value;
                base.OnPropertyChanged("IsSelected");
            }
        }
        #endregion Presentation Properties

        #region IDataErrors

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.Error
        {
            get { return (supplierView as IDataErrorInfo).Error; }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        #endregion 
    }
}

using System;
using System.Windows.Input;
using FrontEnd.DataAccess.Stammdaten.Product;
using FrontEnd.Model.Stammdaten;
using FrontEnd.DataAccess;
using Views.Stammdaten.Product;

namespace FrontEnd.ViewModel.Stammdaten.Product {
    public class ProductViewModel : WorkspaceViewModel {
        readonly ProductView _productView;
        private readonly ProductRepository _productRepository;

      //  string _productType;
       // string[] _productTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;
       

        public  ProductViewModel()
        {
            _productView = ProductFactory.CreateNewProduct();
            _productRepository = new ProductRepository();

        }


        public string Name {
            get { return _productView.Name; }
            set {
                if (value == _productView.Name)
                    return;

                _productView.Name = value;
                base.OnPropertyChanged("Name");
            }
        }

        public string Ean {
            get { return _productView.Ean; }
            set {
                if (value == _productView.Ean)
                    return;

                _productView.Ean = value;

                base.OnPropertyChanged("Ean");
            }
        }

        public double PricePurchase {
            get { return _productView.PricePurchase; }
            set {
                if (value == _productView.PricePurchase)
                    return;

                _productView.PricePurchase = value;

                base.OnPropertyChanged("PricePurchase");
            }
        }

        public double PriceSale {
            get { return _productView.PriceSale; }
            set {
                if (value == _productView.PriceSale)
                    return;

                _productView.PriceSale = value;

                base.OnPropertyChanged("PriceSale");
            }
        }


#region presentation properties

        public override string DisplayName {
            get {
                if (this.IsNewProduct) {
                    return "Display Name";
                } else {
                    return String.Format("{0}", _productView.Name);
                }
            }
        }

        public bool IsSelected {
            get { return _isSelected; }
            set {
                if (value == _isSelected)
                    return;

                _isSelected = value;

                base.OnPropertyChanged("IsSelected");
            }
        }

        public ICommand SaveCommand {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(
                                                           param => this.Save(),
                                                           param => this.CanSave
                                                           ));
            }
        }

        private void Save()
        {
            throw new NotImplementedException();
        }

        private bool CanSave
        {
            get { return true; }
        }

        #endregion

#region Helpermethods

        private bool IsNewProduct
        {
            get { return !_productRepository.ProductsList.Contains(_productView); }
        }

        #endregion


    }
}

using System;
using System.Windows.Input;
using WpfApplication1.DataAccess;
using  WpfApplication1.Model.Stammdaten;

namespace WpfApplication1.ViewModel.Stammdaten.Product {
    public class ProductViewModel : WorkspaceViewModel {
        readonly Model.Stammdaten.Product _product;
        private readonly ProductRepository _productRepository;

      //  string _productType;
       // string[] _productTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;
       

        public  ProductViewModel(Model.Stammdaten.Product product, ProductRepository productRepository)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            if (productRepository == null)
                throw new ArgumentNullException("productRepository");

            _product = product;
            _productRepository = productRepository;

        }


        public string Name {
            get { return _product.Name; }
            set {
                if (value == _product.Name)
                    return;

                _product.Name = value;
                base.OnPropertyChanged("Name");
            }
        }

        public string Ean {
            get { return _product.Ean; }
            set {
                if (value == _product.Ean)
                    return;

                _product.Ean = value;

                base.OnPropertyChanged("Ean");
            }
        }

        public double PricePurchase {
            get { return _product.PricePurchase; }
            set {
                if (value == _product.PricePurchase)
                    return;

                _product.PricePurchase = value;

                base.OnPropertyChanged("PricePurchase");
            }
        }

        public double PriceSale {
            get { return _product.PriceSale; }
            set {
                if (value == _product.PriceSale)
                    return;

                _product.PriceSale = value;

                base.OnPropertyChanged("PriceSale");
            }
        }


#region presentation properties

        public override string DisplayName {
            get {
                if (this.IsNewProduct) {
                    return "Display Name";
                } else {
                    return String.Format("{0}", _product.Name);
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
            get {
                if (_saveCommand == null) {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        }

        private void Save()
        {
            throw new NotImplementedException();
        }

        #endregion

#region Helpermethods

        private bool IsNewProduct
        {
            get { return _productRepository. }
        }

        #endregion


    }
}

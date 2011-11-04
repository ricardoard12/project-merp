using System;
using System.Windows.Input;
using WpfApplication1.DataAccess;
using  WpfApplication1.Model.Stammdaten;

namespace WpfApplication1.ViewModel.Stammdaten.Product {
    public class ProductViewModel : WorkspaceViewModel {
        readonly ProductFactory _productFactory;
        private readonly ProductRepository _productRepository;

      //  string _productType;
       // string[] _productTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;
       

        public  ProductViewModel()
        {
            _productFactory = new ProductFactory();
            _productRepository = new ProductRepository();

        }


        public string Name {
            get { return _productFactory.Name; }
            set {
                if (value == _productFactory.Name)
                    return;

                _productFactory.Name = value;
                base.OnPropertyChanged("Name");
            }
        }

        public string Ean {
            get { return _productFactory.Ean; }
            set {
                if (value == _productFactory.Ean)
                    return;

                _productFactory.Ean = value;

                base.OnPropertyChanged("Ean");
            }
        }

        public double PricePurchase {
            get { return _productFactory.PricePurchase; }
            set {
                if (value == _productFactory.PricePurchase)
                    return;

                _productFactory.PricePurchase = value;

                base.OnPropertyChanged("PricePurchase");
            }
        }

        public double PriceSale {
            get { return _productFactory.PriceSale; }
            set {
                if (value == _productFactory.PriceSale)
                    return;

                _productFactory.PriceSale = value;

                base.OnPropertyChanged("PriceSale");
            }
        }


#region presentation properties

        public override string DisplayName {
            get {
                if (this.IsNewProduct) {
                    return "Display Name";
                } else {
                    return String.Format("{0}", _productFactory.Name);
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
            get { return !_productRepository.ProductsModel.Contains(_productFactory); }
        }

        #endregion


    }
}

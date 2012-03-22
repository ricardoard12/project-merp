using System;
using System.Windows.Input;
using FrontEnd.DataAccess.Stammdaten.Product;
using FrontEnd.Model.Stammdaten;
using FrontEnd.DataAccess;
using Views.Stammdaten.Product;
using WpfApplication1.ViewModel.Stammdaten.Product;
using ProductFactory = Views.Stammdaten.Product.ProductFactory;

namespace FrontEnd.ViewModel.Stammdaten.Product {
    public class ProductViewModel : WorkspaceViewModel, IProductViewModel
    {
        readonly IProductView _productView;
        private readonly ProductRepository _productRepository;

      //  string _productType;
       // string[] _productTypeOptions;
        bool _isSelected;
        RelayCommand _saveCommand;
       

        public  ProductViewModel() {
            _productView = ProductFactory.createNewProduct();
            _productRepository = new ProductRepository();

        }



        public int? ProductNumber {
            get { return _productView.ProductNumber; }
            set {
                if (value == _productView.ProductNumber)
                    return;

                _productView.ProductNumber = value;
                base.OnPropertyChanged("ProductNumber");
            }
        }

        public string ProductName {
            get { return _productView.ProductName; }
            set {
                if (value == _productView.ProductName)
                    return;

                _productView.ProductName = value;
                base.OnPropertyChanged("ProductName");
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

        public double? PricePurchase {
            get { return _productView.PricePurchase; }
            set {
                if (value == _productView.PricePurchase)
                    return;

                _productView.PricePurchase = value;

                base.OnPropertyChanged("PricePurchase");
            }
        }

        public double? PriceSale {
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
                    return String.Format("{0}", _productView.ProductName);
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

        #endregion

#region Helpermethods

        private bool IsNewProduct
        {
            get { return !_productRepository.ProductsList.Contains(_productView); }
        }


        private void Save()
        {
            _productRepository.AddProduct(ProductFactory.createProduct(1234, ProductNumber, ProductName, Ean, PricePurchase, PriceSale, 1, 1));
        }

        private bool CanSave
        {
            get { return true; }
        }
        

#endregion



    }
}

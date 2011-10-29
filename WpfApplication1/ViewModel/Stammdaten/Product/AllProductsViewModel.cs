using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WpfApplication1.DataAccess;

namespace WpfApplication1.ViewModel.Stammdaten.Product {
    public class AllProductsViewModel
    {
        private ProductRepository _productRepository;
        public  ObservableCollection<> 

        public AllProductsViewModel()
        {
            _productRepository = new ProductRepository();
        }

        List<> 
    }
}

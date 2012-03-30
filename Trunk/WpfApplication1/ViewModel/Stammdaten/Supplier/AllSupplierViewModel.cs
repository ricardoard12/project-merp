using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FrontEnd.DataAccess.Stammdaten.Product;
using FrontEnd.ViewModel;
using FrontEnd.ViewModel.Stammdaten.Product;
using Views.Stammdaten.Product;
using Views.Stammdaten.Supplier;
using WpfApplication1.DataAccess.Stammdaten.Supplier;

namespace WpfApplication1.ViewModel.Stammdaten.Supplier
{
    public class AllSupplierViewModel: WorkspaceViewModel, IAllSupplierViewModel
    {
        private SupplierRepository supplierRepository;
        private SupplierViewModel supplierViewModel;
        private ObservableCollection<ISupplierView> suppliers;

        public AllSupplierViewModel()
        {
            supplierRepository = new SupplierRepository();
            supplierViewModel = new SupplierViewModel();
        }

        public ObservableCollection<ISupplierView> Suppliers
        {
            get
            {
                if (suppliers == null || suppliers.Count == 0)
                {
                    suppliers = new ObservableCollection<ISupplierView>(supplierRepository.GetAllSuppliers());
                }
                return suppliers;
            }
        }
    }
}

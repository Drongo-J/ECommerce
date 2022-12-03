using Ecommerce.Commands;
using Ecommerce.DataAccess.SqlServer;
using Ecommerce.Domain.Abstractions;
using Ecommerce.Domain.Services;
using Ecommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }

        private readonly IRepository<Product> _productRepo;
        private readonly ProductService _productService;

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value;OnPropertyChanged(); }
        }

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }

        public bool IsLower { get; set; }

        public MainViewModel(IRepository<Product> productRepo)  
        {
            FilterText = "Lower to Higher";
            SelectedProduct = new Product();

            _productRepo = productRepo;
            _productService = new ProductService();

            AllProducts = _productRepo.GetAllData();

            ToLowerCommand = new RelayCommand((t) =>
            {
                IsLower = !IsLower;

                if (IsLower)
                {
                    FilterText = "Higher To Lower";
                }
                else
                {
                    FilterText = "Lower To Higher";
                }

                AllProducts = _productService.GetFromLowerToHigher(IsLower);
                
            });

            SelectProductCommand = new RelayCommand((o) => 
            {
                var vm = new ProductInfoViewModel();
                vm.ProductInfo = SelectedProduct;
                var view = new ProductWindow();
                view.DataContext = vm;
                view.ShowDialog();    
            });
        }
    }
}

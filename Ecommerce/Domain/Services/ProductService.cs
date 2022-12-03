using Ecommerce.DataAccess.SqlServer;
using Ecommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService()
        {
            _productRepo = new ProductRepository();
        }

        public ObservableCollection<Product> GetFromLowerToHigher(bool IsLower)
        {
            IOrderedEnumerable<Product> products;
            if (IsLower)
            {
                products = from p in _productRepo.GetAllData()
                            orderby p.Price ascending
                            select p;
            }
            else
            {
                products = from p in _productRepo.GetAllData()
                            orderby p.Price descending
                            select p;
            }

            return new ObservableCollection<Product>(products);
        }
    }
}

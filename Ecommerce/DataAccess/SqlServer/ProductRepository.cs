using Ecommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ecommerce.DataAccess.SqlServer
{
    public class ProductRepository : IProductRepository
    {
        private ECommerceDataClassesDataContext _dataContext;

        public ProductRepository()
        {
            _dataContext = new ECommerceDataClassesDataContext();
        }

        public void AddData(Product data)
        {
            _dataContext.Products.InsertOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public void DeleteData(Product data)
        {
            _dataContext.Products.DeleteOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public ObservableCollection<Product> GetAllData()
        {
            var products = from p in _dataContext.Products
                           select p;

            return new ObservableCollection<Product>(products);
        }

        public Product GetData(int id)
        {
            return _dataContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public void UpdateData(Product data)
        {
            var item = _dataContext.Products.SingleOrDefault(p => p.Id == data.Id);
            item = new Product()
            {
                Name = data.Name,
                Price = data.Price,
                Description = data.Description,
                Quantity = data.Quantity,
                Discount = data.Discount
            };
            _dataContext.SubmitChanges();
        }
    }
}

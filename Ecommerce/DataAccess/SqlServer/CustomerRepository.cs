using Ecommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.SqlServer
{
    public class CustomerRepository : ICustomerRepository
    {
        private ECommerceDataClassesDataContext _dataContext;

        public CustomerRepository()
        {
            _dataContext = new ECommerceDataClassesDataContext();
        }

        public void AddData(Customer data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Customer data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAllData()
        {
            var customers = from c in _dataContext.Customers
                            select c;

            return new ObservableCollection<Customer>(customers);
        }

        public Customer GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}

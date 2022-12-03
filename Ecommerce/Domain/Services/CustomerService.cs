using Ecommerce.DataAccess.SqlServer;
using Ecommerce.Domain.Abstractions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepo;

        public CustomerService()
        {
            _customerRepo = new CustomerRepository();
        }

        public Customer GetCustomerByUsername(string username)
        {
            var customer = _customerRepo.GetAllData().FirstOrDefault(c => c.Username == username);
            return customer;
        }
    }
}

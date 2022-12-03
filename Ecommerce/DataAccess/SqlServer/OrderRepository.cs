using Ecommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.SqlServer
{
    public class OrderRepository : IOrderRepository
    {
        private ECommerceDataClassesDataContext _dataContext;

        public OrderRepository()
        {
            _dataContext = new ECommerceDataClassesDataContext();   
        }

        public void AddData(Order data)
        {
            _dataContext.Orders.InsertOnSubmit(data);
            _dataContext.SubmitChanges();
        }

        public void DeleteData(Order data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> GetAllData()
        {
            var orders = from o in _dataContext.Orders
                         select o;

            return new ObservableCollection<Order>(orders);
        }

        public Order GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Order data)
        {
            throw new NotImplementedException();
        }
    }
}

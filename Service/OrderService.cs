using DataAccess.IRepositotry;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService
    {

        private IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public List<Order> GetAllOrder()
        {
            return _repository.GetAllOrder();
        }

        public Order GetOrderWithId(int id)
        {
            return _repository.GetOrderWithId(id);
        }

        public void AddOrder(Order order)
        {
            _repository.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            _repository.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _repository.DeleteOrder(id);
        }

        public void AddOrderCheckout(string? fname, string? lname, string? address, int[]? arrayId, int[]? quantity, string accId)
        {
            _repository.addOrderCheckout(fname, lname, address, arrayId, quantity, accId);
        }
    }
}

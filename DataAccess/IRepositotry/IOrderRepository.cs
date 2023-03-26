using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositotry
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrder();
        public Order GetOrderWithId(int id);
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(int id);
        public void addOrderCheckout(string? fname, string? lname, string? address, int[]? arrayId, int[]? quantity, string accId);
    }
}

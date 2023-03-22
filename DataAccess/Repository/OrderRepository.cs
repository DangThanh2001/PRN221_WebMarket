using DataAccess.IRepositotry;
using Microsoft.EntityFrameworkCore;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextBase _dbContext;
        public OrderRepository(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Order> GetAllOrder()
        {
            return _dbContext.Orders.ToList();
        }
        public Order GetOrderWithId(int id)
        {
            return _dbContext.Orders.Where(x => x.OrderId == id).FirstOrDefault();
        }
        public void AddOrder(Order order)
        {
            try
            {
                Order o = GetOrderWithId(order.OrderId);
                if (o == null)
                {
                    _dbContext.Orders.Add(o);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("This Order exists");
            }
        }
        public void UpdateOrder(Order order)
        {
            try
            {
                Order o = GetOrderWithId(order.OrderId);
                if (o != null)
                {
                    _dbContext.Entry<Order>(order).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteOrder(int id)
        {
            try
            {
                Order o = GetOrderWithId(id);
                if (o != null)
                {

                    _dbContext.Orders.Remove(o);
                    _dbContext.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw new Exception("The Order doesn't exist");
            }
        }
    }
}

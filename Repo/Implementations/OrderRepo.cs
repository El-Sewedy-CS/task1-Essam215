using Demo_2.Models;
using Demo_2.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo_2.Repo.Implementations
{
    public class OrderRepo : IOrderRepo
    {
        private readonly MyAppContext _context;

        public OrderRepo(MyAppContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.Include(o => o.MenuItem).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Include(o => o.MenuItem).FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            // defensive check: ensure referenced MenuItem exists to avoid FK violation
            var exists = _context.MenuItems.Any(m => m.Id == order.MenuItemId);
            if (!exists)
            {
                throw new InvalidOperationException($"MenuItem with Id {order.MenuItemId} does not exist.");
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
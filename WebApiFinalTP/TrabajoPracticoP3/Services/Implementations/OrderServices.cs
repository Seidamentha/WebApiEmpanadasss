using Microsoft.EntityFrameworkCore;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.DBContext;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Services.Implementations
{
    public class OrderServices : IOrderServices
    {
        private readonly ECommerceContext _context;

        public OrderServices(ECommerceContext context)
        {
            _context = context;
        }

        public Order? GetOrder(int id)
        {
            return _context.Orders
                .Include(o => o.Client)
                .Include(o => o.SaleOrderLine)
                .SingleOrDefault(o => o.Id == id);
        }

        public int AddOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();

            return order.Id;
        }

        public Order? GetLatestOrderForClient(int clientId)
        {
            return _context.Orders
                .Where(o => o.ClientId == clientId)
                .OrderByDescending(o => o.Id)
                .FirstOrDefault();
        }
    }
}

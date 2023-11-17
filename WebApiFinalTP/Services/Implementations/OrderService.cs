using System;
using WebApiFinalTP.Data;
using WebApiFinalTP.Data.Models;

namespace WebApiFinalTP.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly TPIContext _context;

        public OrderService(TPIContext context)
        {
            _context = context;
        }

        public Order AddOrder(OrderDto orderDto)
        {
            var orderToAdd = new Order
            {
                UserId = orderDto.UserId,
                Status = orderDto.Status,
            };

            _context.Orders.Add(orderToAdd);
            _context.SaveChanges();
            return orderToAdd;
        }

        public OrderLine AddProductToOrderLine(OrderLineDto orderLineDto)
        {
            var userExists = _context.Users.Any(u => u.UserId == orderLineDto.CustomerId);
            var productExists = _context.Products.Any(p => p.ProductId == orderLineDto.ProductId);

            if (!userExists || !productExists)
            {
                return null;
            }

            var product = _context.Products
                .FirstOrDefault(p => p.ProductId == orderLineDto.ProductId);

            if (product == null)
            {
                return null;
            }

            var order = _context.Orders.FirstOrDefault(o => o.Id == orderLineDto.OrderId && o.UserId == orderLineDto.CustomerId);

            if (order == null)
            {
                return null;
            }

            var orderLine = new OrderLine
            {
                Product = product,
                Quantity = orderLineDto.Quantity,
                OrderId = orderLineDto.OrderId,
            };

            _context.OrderLines.Add(orderLine);
            _context.SaveChanges();
            return orderLine;
        }


        public List<Order> GetAllOrders(int userId)
        {
            return _context.Orders
                .Where(o => o.UserId == userId)
                .Include(p => p.OrderLines)
                    .ThenInclude(ol => ol.Product)
                        .ThenInclude(p => p.Colours)
                    .Include(p => p.OrderLines)
                    .ThenInclude(ol => ol.Product)
                        .ThenInclude(p => p.Sizes)
                .ToList();
        }
    }

}


using System;
using WebApiFinalTP.Data.Models;

namespace WebApiFinalTP.Services.Interfaces
{
    public interface IOrderService
    {
        public OrderLine AddProductToOrderLine(OrderLineDto orderLineDto);
        public Order AddOrder(OrderDto orderDto);
        public List<Order> GetAllOrders(int userId);
    }
}


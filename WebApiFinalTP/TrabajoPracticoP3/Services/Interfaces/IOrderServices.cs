using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IOrderServices
    {
        public Order GetOrder(int id);
        public Order? GetLatestOrderForClient(int clientId);
        public int AddOrder(Order order);
    }
}

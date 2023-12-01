using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.DBContext;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Services.Implementations
{
    public class ClientServices : IClientServices
    {
        private readonly ECommerceContext _context;

        public ClientServices(ECommerceContext context)
        {
            _context = context;
        }

        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public Client? GetUserById(int userId)
        {
            return _context.Clients.FirstOrDefault(u => u.Id == userId);
        }

        public int CreateClient(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateClient(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();

        }

        public void HighLogicUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public void LowLogicUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

    }
}

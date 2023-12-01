using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IClientServices
    {
        public List<Client> GetClients();
        public Client GetUserById(int user);
        public int CreateClient(User user);
        public void UpdateClient(Client client);
        public void DeleteUser(User user);
        public void HighLogicUser(User user);
        public void LowLogicUser(User user);
    }
}

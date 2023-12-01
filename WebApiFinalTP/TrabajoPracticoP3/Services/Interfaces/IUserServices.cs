using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IUserServices
    {
        public Tuple<bool, User?> ValidarUsuario(string email, string password);
    }
}

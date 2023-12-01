using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.DBContext;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Services.Implementations
{
    public class UserService : IUserServices
    {
        private readonly ECommerceContext _context;

        public UserService(ECommerceContext context)
        {
            _context = context;
        }

        public Tuple<bool, User?> ValidarUsuario(string email, string password)
        {
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                    return new Tuple<bool, User?>(true, userForLogin);
                return new Tuple<bool, User?>(false, userForLogin);
            }
            return new Tuple<bool, User?>(false, null);

        }
    }
}

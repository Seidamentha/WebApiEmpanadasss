using System;
using WebApiFinalTP.Data;

namespace WebApiFinalTP.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly TPIContext _context;

        public AdminService(TPIContext context)
        {
            _context = context;
        }

        public List<Admin> GetAdmins()
        {
            return _context.Admins.ToList();
        }

    }

}


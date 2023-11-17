using System;
namespace WebApiFinalTP.Services.Interfaces
{
    public interface IAdminService
    {
        List<User> GetAdmins();
        User? GetAdminById(int id);
        User AddAdmin(User admin);
        void UpdateAdmin(User admin);
        void DeleteAdmin(int adminId);

       
    }
}


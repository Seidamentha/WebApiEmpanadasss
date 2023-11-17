using System;
using WebApiFinalTP.Data.Models;

namespace WebApiFinalTP.Services.Interfaces
{
    public interface IUserService
    {
        UserResponse ValidateUser(string userName, string password);
        User CreateUser(User user);
        User? GetUserByUsername(string userName);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        // Otros métodos según sea necesario para la gestión de usuarios
    }
}


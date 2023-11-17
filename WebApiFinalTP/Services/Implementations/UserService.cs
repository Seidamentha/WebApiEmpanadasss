using System;
using WebApiFinalTP.Data.Models;

namespace WebApiFinalTP.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly TPIContext _context;

        public UserService(TPIContext context)
        {
            _context = context;
        }

        public UserResponse ValidateUser(string userName, string password)
        {
            UserResponse response = new UserResponse();

            User userForLogin = _context.Users.SingleOrDefault(u => u.UserName == userName);

            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "Login Successful";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Wrong Password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "User not found";
            }

            return response;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUserByUsername(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User userToBeDeleted = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (userToBeDeleted != null)
            {
                userToBeDeleted.Status = false;
                _context.Users.Update(userToBeDeleted);
                _context.SaveChanges();
            }
            
        }
    }

}


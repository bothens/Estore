using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> UserExistsAsync(int UserId);
        Task<bool> UpdateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> RemoveUserAsync(int id);

        

    }
}

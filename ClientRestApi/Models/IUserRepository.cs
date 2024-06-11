using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Models
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Search(string name, string email);
        Task<User> GetUser(int UserId);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserByEmail(string Email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int UserId);

        
    }
}

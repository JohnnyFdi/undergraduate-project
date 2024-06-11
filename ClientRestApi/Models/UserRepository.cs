using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClientRestApi.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(int userId)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.UserId == userId);

            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }

        }

        public async Task<User> GetUser(int userId)
        {
            return await appDbContext.Users
                .FirstOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await appDbContext.Users
                    .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> Search(string name, string email)
        {
            IQueryable<User> query = appDbContext.Users;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                              || e.LastName.Contains(name));
            }

            if (email != null)
            {
                query = query.Where(e => e.Email == email);
            }

            return await query.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.UserId == user.UserId);

            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Email = user.Email;
                result.PhoneNumber = user.PhoneNumber;
                result.Password = user.Password;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }



        




    }
}

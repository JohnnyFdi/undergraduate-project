using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClientRestApi.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClientRestApi.Models
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<AdminUser> AddAdminUser(AdminUser adminuser)
        {
            var result = await appDbContext.AdminUsers.AddAsync(adminuser);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAdminUser(int adminId)
        {
            var result = await appDbContext.AdminUsers
                .FirstOrDefaultAsync(e => e.AdminId == adminId);

            if (result != null)
            {
                appDbContext.AdminUsers.Remove(result);
                await appDbContext.SaveChangesAsync();
            }

        }

        public async Task<AdminUser> GetAdminUser(int adminId)
        {
            return await appDbContext.AdminUsers
                .FirstOrDefaultAsync(e => e.AdminId == adminId);
        }

        public async Task<AdminUser> GetAdminUserByEmail(string email)
        {
            return await appDbContext.AdminUsers
                    .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<AdminUser>> GetAdminUsers()
        {
            return await appDbContext.AdminUsers.ToListAsync();
        }

        
        public async Task<AdminUser> UpdateAdminUser(AdminUser adminuser)
        {
            var result = await appDbContext.AdminUsers
                .FirstOrDefaultAsync(e => e.AdminId == adminuser.AdminId);

            if (result != null)
            {
               
                result.Role = adminuser.Role;
                result.Email = adminuser.Email;
                result.Password = adminuser.Password;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CasaVanduta>> GetCasaVandutas()
        {
            return await appDbContext.CasaVandutas.ToListAsync();
        }

        public async Task<CasaVanduta> GetCasaVanduta(int id)
        {
            return await appDbContext.CasaVandutas.FindAsync(id);
        }

        public async Task<CasaVanduta> AddCasaVanduta(CasaVanduta casaVanduta)
        {
            appDbContext.CasaVandutas.Add(casaVanduta);
            await appDbContext.SaveChangesAsync();
            return casaVanduta;
        }

        public async Task<CasaVanduta> UpdateCasaVanduta(CasaVanduta casaVanduta)
        {
            var existingCasa = await appDbContext.CasaVandutas.FindAsync(casaVanduta.CasaId);
            if (existingCasa == null) return null;

            appDbContext.Entry(existingCasa).CurrentValues.SetValues(casaVanduta);
            await appDbContext.SaveChangesAsync();
            return existingCasa;
        }

        public async Task DeleteCasaVanduta(int id)
        {
            var casaVanduta = await appDbContext.CasaVandutas.FindAsync(id);
            if (casaVanduta != null)
            {
                appDbContext.CasaVandutas.Remove(casaVanduta);
                await appDbContext.SaveChangesAsync();
            }
        }







    }
}

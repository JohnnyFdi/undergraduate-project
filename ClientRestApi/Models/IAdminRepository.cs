using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.Admin;

namespace ClientRestApi.Models
{
    public interface IAdminRepository
    {
        
        Task<AdminUser> GetAdminUser(int AdminId);
        Task<IEnumerable<AdminUser>> GetAdminUsers();
        Task<AdminUser> GetAdminUserByEmail(string Email);
        Task<AdminUser> AddAdminUser(AdminUser adminuser);
        Task<AdminUser> UpdateAdminUser(AdminUser adminuser);
        Task DeleteAdminUser(int AdminId);

        Task<IEnumerable<CasaVanduta>> GetCasaVandutas();
        Task<CasaVanduta> GetCasaVanduta(int id);
        Task<CasaVanduta> AddCasaVanduta(CasaVanduta casaVanduta);
        Task<CasaVanduta> UpdateCasaVanduta(CasaVanduta casaVanduta);
        Task DeleteCasaVanduta(int id);

    }
}

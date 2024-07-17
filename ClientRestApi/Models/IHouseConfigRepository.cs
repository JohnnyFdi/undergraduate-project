using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.House_Config;

namespace ClientRestApi.Models
{
    public interface IHouseConfigRepository
    {
        Task<IEnumerable<Material>> GetMaterials();
        Task<IEnumerable<Finish>> GetFinishes();
        Task<IEnumerable<Heating>> GetHeatings();
        Task<IEnumerable<Ventilation>> GetVentilations();
        Task<IEnumerable<Waste>> GetWastes();
        Task<ConfigCasa> AddHouseConfig(ConfigCasa configCasa);
        Task<ConfigCasa> GetHouseConfigById(int id);

        Task<IEnumerable<ConfigCasa>> GetHouseConfigsByUserId(int userId);
    }
     
}

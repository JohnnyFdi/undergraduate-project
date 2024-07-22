﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClientRestApi.House_Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClientRestApi.Models
{
    public class HouseConfigRepository : IHouseConfigRepository
    {
        private readonly AppDbContext appDbContext;

        public HouseConfigRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        
        

        public async Task<IEnumerable<Material>> GetMaterials()
        {
            return await appDbContext.Materials.ToListAsync();
        }

        public async Task<IEnumerable<Finish>> GetFinishes()
        {
            return await appDbContext.Finishes.ToListAsync();
        }

        public async Task<IEnumerable<Heating>> GetHeatings()
        {
            return await appDbContext.Heatings.ToListAsync();
        }

        public async Task<IEnumerable<Ventilation>> GetVentilations()
        {
            return await appDbContext.Ventilations.ToListAsync();
        }

        public async Task<IEnumerable<Waste>> GetWastes()
        {
            return await appDbContext.Wastes.ToListAsync();
        }

        public async Task<ConfigCasa> AddHouseConfig(ConfigCasa configCasa)
        {
            var result = await appDbContext.ConfigCasas.AddAsync(configCasa);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ConfigCasa> GetHouseConfigById(int id)
        {
            return await appDbContext.ConfigCasas
                .Include(c => c.ConfigCameras)
                .FirstOrDefaultAsync(c => c.ConfigCasaId == id);
        }

        public async Task<IEnumerable<ConfigCasa>> GetHouseConfigsByUserId(int userId)
        {
            return await appDbContext.ConfigCasas
                .Where(c => c.UserId == userId)
                .Include(c => c.ConfigCameras)
                .ToListAsync();
        }
    }
}

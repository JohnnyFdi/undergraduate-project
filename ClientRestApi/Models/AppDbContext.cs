using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.House_Config;
using Microsoft.EntityFrameworkCore;

namespace ClientRestApi.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Finish> Finishes { get; set; }
        public DbSet<Heating> Heatings { get; set; }
        public DbSet<Ventilation> Ventilations { get; set; }
        public DbSet<Waste> Wastes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Material>()
                .HasKey(m => m.MaterialId);

            modelBuilder.Entity<Finish>()
                .HasKey(f => f.FinishId);

            modelBuilder.Entity<Heating>()
                .HasKey(h => h.HeatingId);

            modelBuilder.Entity<Ventilation>()
                .HasKey(v => v.VentilationId);

            modelBuilder.Entity<Waste>()
                .HasKey(w => w.WasteId);

            //send User Table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FirstName= "Dragos Ionut",
                    LastName= "Fertu",
                    Email = "fertuionutdragos@yahoo.com",
                    PhoneNumber = "0769258202",
                    Password = "Jmek123"
                }) ;

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserId = 2,
                   FirstName = "Romeo",
                   LastName = "Fantastik",
                   Email = "romeofantastik@yahoo.com",
                   PhoneNumber = "0762413567",
                   Password = "Crrmrr69"
               });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 3,
                    FirstName = "Dragos",
                    LastName = "Pardafir",
                    Email = "roserose@yahoo.com",
                    PhoneNumber = "0745667893",
                    Password = "Aaaahhhh3"
                });

            modelBuilder.Entity<Material>().HasData(
                new Material
                {
                    MaterialId = 1,
                    MatName = "BCA",
                    Material_xm2 = 1.0
                },
                new Material
                {
                    MaterialId = 2,
                    MatName = "Caramida Rosie",
                    Material_xm2 = 1.5
                }
            );

            modelBuilder.Entity<Finish>().HasData(
                new Finish
                {
                    FinishId = 1,
                    FinName = "Standard",
                    Finish_xm2 = 1.0
                },
                new Finish
                {
                    FinishId = 2,
                    FinName = "Premium",
                    Finish_xm2 = 2.0
                },
                new Finish
                {
                    FinishId = 3,
                    FinName = "De Lux",
                    Finish_xm2 = 3.5
                }
            );

            modelBuilder.Entity<Heating>().HasData(
                new Heating
                {
                    HeatingId = 1,
                    HeatName = "Centrala Termica (pe gaz)",
                    HeatPrice = 3000
                },
                new Heating
                {
                    HeatingId = 2,
                    HeatName = "Centrala Termica (electrica)",
                    HeatPrice = 2000
                },
                new Heating
                {
                    HeatingId = 3,
                    HeatName = "Pompa De Caldura (aer-aer)",
                    HeatPrice = 6500
                },
                new Heating
                {
                    HeatingId = 4,
                    HeatName = "Pompa De Caldura (aer-apa)",
                    HeatPrice = 10500
                },
                new Heating
                {
                    HeatingId = 5,
                    HeatName = "Pompa De Caldura (sol-apa)",
                    HeatPrice = 21500
                },
                new Heating
                {
                    HeatingId = 6,
                    HeatName = "Soba Moderna (pe lemne/pellet)",
                    HeatPrice = 2500
                },
                new Heating
                {
                    HeatingId = 7,
                    HeatName = "Soba Moderna (pe gaz)",
                    HeatPrice = 3500
                }
            );

            modelBuilder.Entity<Ventilation>().HasData(
                new Ventilation
                {
                    VentilationId = 1,
                    VentName = "Ventilatie Naturala",
                    VentPrice = 125
                },
                new Ventilation
                {
                    VentilationId = 2,
                    VentName = "Ventilatie Mecanica Simpla",
                    VentPrice = 650
                },
                new Ventilation
                {
                    VentilationId = 3,
                    VentName = "Ventilatie Mecanica Controlata (VMC)",
                    VentPrice = 2000
                },
                new Ventilation
                {
                    VentilationId = 4,
                    VentName = "Ventilatie Mecanica Cu Recuperare De Caldura (VMC-R)",
                    VentPrice = 5250
                }
            );

            modelBuilder.Entity<Waste>().HasData(
                new Waste
                {
                    WasteId = 1,
                    WasteName = "Canalizare",
                    WastePrice = 1250
                },
                new Waste
                {
                    WasteId = 2,
                    WasteName = "Fosa Septica",
                    WastePrice = 6000
                }
            );

        }

    }


}
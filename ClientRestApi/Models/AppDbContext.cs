using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.Admin;
using ClientRestApi.Angajati;
using ClientRestApi.Constructori;
using ClientRestApi.Contracte;
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
        public DbSet<ConfigCasa> ConfigCasas { get; set; }
        public DbSet<ConfigCamera> ConfigCameras { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<Proiect> Proiecte { get; set; }
        public DbSet<Apartament> Apartamente { get; set; }
        public DbSet<Imagine> Imagini { get; set; }

        public DbSet<CasaVanduta> CasaVandutas { get; set; }

        public DbSet<EchipaConstructorBlocuri> EchipaConstructorBlocuris { get; set; }
        public DbSet<AssignmentHistory> AssignmentHistories { get; set; }
        public DbSet<EchipaConstructorCase> EchipaConstructorCases { get; set; }
        public DbSet<AssignmentHistoryHouse> AssignmentHistoryHouses { get; set; }

        public DbSet<ContracteApartamente> ContracteApartamentes { get; set; }

        public DbSet<ContracteCase> ContracteCases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<AdminUser>()
                .HasKey(a => a.AdminId);

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

            // Configurarea cheii primare pentru ConfigCasa
            modelBuilder.Entity<ConfigCasa>()
                .HasKey(c => c.ConfigCasaId);

            modelBuilder.Entity<ConfigCamera>()
                .HasKey(k => k.ConfigCameraId);

            modelBuilder.Entity<Proiect>()
                .HasKey(p => p.ProiectId);

            modelBuilder.Entity<Apartament>()
                .HasKey(a => a.ApartamentId);

            modelBuilder.Entity<Imagine>()
                .HasKey(i => i.ImagineId);

            modelBuilder.Entity<CasaVanduta>()
                .HasKey(c => c.CasaId);

            modelBuilder.Entity<EchipaConstructorBlocuri>()
                .HasKey(c => c.ConstructorId);

            modelBuilder.Entity<AssignmentHistory>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<EchipaConstructorCase>()
                .HasKey(c => c.ConstructorCaseId);

            modelBuilder.Entity<AssignmentHistoryHouse>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<ContracteApartamente>()
                .HasKey(c => c.ContractApId);

            modelBuilder.Entity<ContracteCase>()
                .HasKey(c => c.ContractCId);



            // Configurarea relației dintre User și ConfigCasa
            modelBuilder.Entity<ConfigCasa>()
                .HasOne(c => c.User)
                .WithMany(u => u.ConfigCasas)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ConfigCamera>()
                .HasOne(k => k.ConfigCasa)
                .WithMany(c => c.ConfigCameras)
                .HasForeignKey(c => c.ConfigCasaId);

            modelBuilder.Entity<Proiect>()
            .HasMany(p => p.Apartamente)
            .WithOne(a => a.Proiect)
            .HasForeignKey(a => a.ProiectId);

            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.Imagini)
                .WithOne(i => i.Proiect)
                .HasForeignKey(i => i.ProiectId);

            
            modelBuilder.Entity<EchipaConstructorBlocuri>()
                .HasOne(a => a.Proiect)
                .WithOne(p => p.EchipaConstructorBlocuri)
                .HasForeignKey<EchipaConstructorBlocuri>(a => a.ProiectId);

            modelBuilder.Entity<EchipaConstructorCase>()
                .HasOne(a => a.CasaVanduta)
                .WithOne(p => p.EchipaConstructorCase)
                .HasForeignKey<EchipaConstructorCase>(a => a.CasaId);

            modelBuilder.Entity<ContracteApartamente>()
                .HasOne(c => c.AdminUser)
                .WithMany()
                .HasForeignKey(c => c.AdminId);

            modelBuilder.Entity<ContracteApartamente>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ContracteApartamente>()
                .HasOne(c => c.Apartament)
                .WithMany()
                .HasForeignKey(c => c.ApartamentId);

            modelBuilder.Entity<ContracteCase>()
                .HasOne(c => c.AdminUser)
                .WithMany()
                .HasForeignKey(c => c.AdminId);

            modelBuilder.Entity<ContracteCase>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ContracteCase>()
                .HasOne(c => c.CasaVanduta)
                .WithMany()
                .HasForeignKey(c => c.CasaId);




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

            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser
                {
                    AdminId = 1,
                    Role = "Director",
                    Email = "jhonnyfdi@fdimobiliare.ro",
                    Password = "Parolaconfidentiala10-"
                },

                new AdminUser
                {
                    AdminId = 2,
                    Role = "Consultant",
                    Email = "adamrosca@fdimobiliare.ro",
                    Password = "Adam5contracte-"
                }

            );

            modelBuilder.Entity<EchipaConstructorBlocuri>().HasData(
                new EchipaConstructorBlocuri
                {
                    ConstructorId = 1,
                    ConsName = "FDIWorkerTeam 1",
                    ConsStatus = "disponibil"
                    
                },
                new EchipaConstructorBlocuri
                {
                    ConstructorId = 2,
                    ConsName = "FDIWorkerTeam 2",
                    ConsStatus = "disponibil"
                },
                new EchipaConstructorBlocuri
                {
                    ConstructorId = 3,
                    ConsName = "FDIWorkerTeam 3",
                    ConsStatus = "disponibil"

                },

                new EchipaConstructorBlocuri
                {
                    ConstructorId = 4,
                    ConsName = "FDIWorkerTeam 4",
                    ConsStatus = "disponibil"
                }
            );

            modelBuilder.Entity<EchipaConstructorCase>().HasData(
                new EchipaConstructorCase
                {
                    ConstructorCaseId = 1,
                    ConsName = "FDIHouseWorkerTeam 1",
                    ConsStatus = "disponibil"

                },
                new EchipaConstructorCase
                {
                    ConstructorCaseId = 2,
                    ConsName = "FDIHouseWorkerTeam 2",
                    ConsStatus = "disponibil"

                },
                new EchipaConstructorCase
                {
                    ConstructorCaseId = 3,
                    ConsName = "FDIHouseWorkerTeam 3",
                    ConsStatus = "disponibil"

                },

                new EchipaConstructorCase
                {
                    ConstructorCaseId = 4,
                    ConsName = "FDIHouseWorkerTeam 4",
                    ConsStatus = "disponibil"

                }
            );


        }

    }


}
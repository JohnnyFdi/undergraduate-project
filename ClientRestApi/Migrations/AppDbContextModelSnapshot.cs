﻿// <auto-generated />
using System;
using ClientRestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientRestApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientRestApi.Admin.AdminUser", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContracteApartamenteContractApId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.HasIndex("ContracteApartamenteContractApId");

                    b.ToTable("AdminUsers");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            Email = "jhonnyfdi@fdimobiliare.ro",
                            Password = "Parolaconfidentiala10-",
                            Role = "Director"
                        },
                        new
                        {
                            AdminId = 2,
                            Email = "adamrosca@fdimobiliare.ro",
                            Password = "Adam5contracte-",
                            Role = "Consultant"
                        });
                });

            modelBuilder.Entity("ClientRestApi.Admin.Apartament", b =>
                {
                    b.Property<int>("ApartamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Compartimentare")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Etaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumarApartament")
                        .HasColumnType("int");

                    b.Property<int>("NumarCamere")
                        .HasColumnType("int");

                    b.Property<int>("ProiectId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Suprafata")
                        .HasColumnType("int");

                    b.HasKey("ApartamentId");

                    b.HasIndex("ProiectId");

                    b.ToTable("Apartamente");
                });

            modelBuilder.Entity("ClientRestApi.Admin.CasaVanduta", b =>
                {
                    b.Property<int>("CasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetaliiCasa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Etaje")
                        .HasColumnType("int");

                    b.Property<int>("NumarCamere")
                        .HasColumnType("int");

                    b.Property<int>("Suprafata")
                        .HasColumnType("int");

                    b.HasKey("CasaId");

                    b.ToTable("CasaVandutas");
                });

            modelBuilder.Entity("ClientRestApi.Admin.Imagine", b =>
                {
                    b.Property<int>("ImagineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProiectId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImagineId");

                    b.HasIndex("ProiectId");

                    b.ToTable("Imagini");
                });

            modelBuilder.Entity("ClientRestApi.Admin.Proiect", b =>
                {
                    b.Property<int>("ProiectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descriere1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumarApartamente")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImgProiect")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProiectId");

                    b.ToTable("Proiecte");
                });

            modelBuilder.Entity("ClientRestApi.Angajati.EchipaConstructorBlocuri", b =>
                {
                    b.Property<int>("ConstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProiectId")
                        .HasColumnType("int");

                    b.HasKey("ConstructorId");

                    b.HasIndex("ProiectId")
                        .IsUnique()
                        .HasFilter("[ProiectId] IS NOT NULL");

                    b.ToTable("EchipaConstructorBlocuris");

                    b.HasData(
                        new
                        {
                            ConstructorId = 1,
                            ConsName = "FDIWorkerTeam 1",
                            ConsStatus = "disponibil"
                        },
                        new
                        {
                            ConstructorId = 2,
                            ConsName = "FDIWorkerTeam 2",
                            ConsStatus = "disponibil"
                        },
                        new
                        {
                            ConstructorId = 3,
                            ConsName = "FDIWorkerTeam 3",
                            ConsStatus = "disponibil"
                        },
                        new
                        {
                            ConstructorId = 4,
                            ConsName = "FDIWorkerTeam 4",
                            ConsStatus = "disponibil"
                        });
                });

            modelBuilder.Entity("ClientRestApi.Constructori.AssignmentHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<string>("EstimatedTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProiectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AssignmentHistories");
                });

            modelBuilder.Entity("ClientRestApi.Constructori.AssignmentHistoryHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CasaId")
                        .HasColumnType("int");

                    b.Property<int>("ConstructorCaseId")
                        .HasColumnType("int");

                    b.Property<string>("EstimatedTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssignmentHistoryHouses");
                });

            modelBuilder.Entity("ClientRestApi.Constructori.EchipaConstructorCase", b =>
                {
                    b.Property<int>("ConstructorCaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CasaId")
                        .HasColumnType("int");

                    b.Property<string>("ConsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConstructorCaseId");

                    b.HasIndex("CasaId")
                        .IsUnique()
                        .HasFilter("[CasaId] IS NOT NULL");

                    b.ToTable("EchipaConstructorCases");

                    b.HasData(
                        new
                        {
                            ConstructorCaseId = 1,
                            ConsName = "FDIHouseWorkerTeam 1",
                            ConsStatus = "disponibil"
                        },
                        new
                        {
                            ConstructorCaseId = 2,
                            ConsName = "FDIHouseWorkerTeam 2",
                            ConsStatus = "disponibil"
                        },
                        new
                        {
                            ConstructorCaseId = 3,
                            ConsName = "FDIHouseWorkerTeam 3",
                            ConsStatus = "disponibil"
                        },
                        new
                        {
                            ConstructorCaseId = 4,
                            ConsName = "FDIHouseWorkerTeam 4",
                            ConsStatus = "disponibil"
                        });
                });

            modelBuilder.Entity("ClientRestApi.Contracte.ContracteApartamente", b =>
                {
                    b.Property<int>("ContractApId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("ApartamentId")
                        .HasColumnType("int");

                    b.Property<int?>("ApartamentId1")
                        .HasColumnType("int");

                    b.Property<int>("Costuri")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataSemnarii")
                        .HasColumnType("datetime2");

                    b.Property<int>("PretVanzare")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("ContractApId");

                    b.HasIndex("AdminId");

                    b.HasIndex("ApartamentId");

                    b.HasIndex("ApartamentId1")
                        .IsUnique()
                        .HasFilter("[ApartamentId1] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1")
                        .IsUnique()
                        .HasFilter("[UserId1] IS NOT NULL");

                    b.ToTable("ContracteApartamentes");
                });

            modelBuilder.Entity("ClientRestApi.Contracte.ContracteCase", b =>
                {
                    b.Property<int>("ContractCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("CasaId")
                        .HasColumnType("int");

                    b.Property<int>("Costuri")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataSemnarii")
                        .HasColumnType("datetime2");

                    b.Property<int>("PretVanzare")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ContractCId");

                    b.HasIndex("AdminId");

                    b.HasIndex("CasaId");

                    b.HasIndex("UserId");

                    b.ToTable("ContracteCases");
                });

            modelBuilder.Entity("ClientRestApi.House_Config.ConfigCamera", b =>
                {
                    b.Property<int>("ConfigCameraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConfigCasaId")
                        .HasColumnType("int");

                    b.Property<bool>("IncalzirePardoseala")
                        .HasColumnType("bit");

                    b.Property<string>("NumeCamera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Suprafata")
                        .HasColumnType("int");

                    b.HasKey("ConfigCameraId");

                    b.HasIndex("ConfigCasaId");

                    b.ToTable("ConfigCameras");
                });

            modelBuilder.Entity("ClientRestApi.House_Config.ConfigCasa", b =>
                {
                    b.Property<int>("ConfigCasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColectareReziduri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Finisaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipIncalzire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Ventilatie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConfigCasaId");

                    b.HasIndex("UserId");

                    b.ToTable("ConfigCasas");
                });

            modelBuilder.Entity("ClientRestApi.House_Config.Finish", b =>
                {
                    b.Property<int>("FinishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FinName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Finish_xm2")
                        .HasColumnType("float");

                    b.HasKey("FinishId");

                    b.ToTable("Finishes");

                    b.HasData(
                        new
                        {
                            FinishId = 1,
                            FinName = "Standard",
                            Finish_xm2 = 1.0
                        },
                        new
                        {
                            FinishId = 2,
                            FinName = "Premium",
                            Finish_xm2 = 2.0
                        },
                        new
                        {
                            FinishId = 3,
                            FinName = "De Lux",
                            Finish_xm2 = 3.5
                        });
                });

            modelBuilder.Entity("ClientRestApi.House_Config.Heating", b =>
                {
                    b.Property<int>("HeatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HeatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HeatPrice")
                        .HasColumnType("int");

                    b.HasKey("HeatingId");

                    b.ToTable("Heatings");

                    b.HasData(
                        new
                        {
                            HeatingId = 1,
                            HeatName = "Centrala Termica (pe gaz)",
                            HeatPrice = 3000
                        },
                        new
                        {
                            HeatingId = 2,
                            HeatName = "Centrala Termica (electrica)",
                            HeatPrice = 2000
                        },
                        new
                        {
                            HeatingId = 3,
                            HeatName = "Pompa De Caldura (aer-aer)",
                            HeatPrice = 6500
                        },
                        new
                        {
                            HeatingId = 4,
                            HeatName = "Pompa De Caldura (aer-apa)",
                            HeatPrice = 10500
                        },
                        new
                        {
                            HeatingId = 5,
                            HeatName = "Pompa De Caldura (sol-apa)",
                            HeatPrice = 21500
                        },
                        new
                        {
                            HeatingId = 6,
                            HeatName = "Soba Moderna (pe lemne/pellet)",
                            HeatPrice = 2500
                        },
                        new
                        {
                            HeatingId = 7,
                            HeatName = "Soba Moderna (pe gaz)",
                            HeatPrice = 3500
                        });
                });

            modelBuilder.Entity("ClientRestApi.House_Config.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Material_xm2")
                        .HasColumnType("float");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            MaterialId = 1,
                            MatName = "BCA",
                            Material_xm2 = 1.0
                        },
                        new
                        {
                            MaterialId = 2,
                            MatName = "Caramida Rosie",
                            Material_xm2 = 1.5
                        });
                });

            modelBuilder.Entity("ClientRestApi.House_Config.Ventilation", b =>
                {
                    b.Property<int>("VentilationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VentPrice")
                        .HasColumnType("int");

                    b.HasKey("VentilationId");

                    b.ToTable("Ventilations");

                    b.HasData(
                        new
                        {
                            VentilationId = 1,
                            VentName = "Ventilatie Naturala",
                            VentPrice = 125
                        },
                        new
                        {
                            VentilationId = 2,
                            VentName = "Ventilatie Mecanica Simpla",
                            VentPrice = 650
                        },
                        new
                        {
                            VentilationId = 3,
                            VentName = "Ventilatie Mecanica Controlata (VMC)",
                            VentPrice = 2000
                        },
                        new
                        {
                            VentilationId = 4,
                            VentName = "Ventilatie Mecanica Cu Recuperare De Caldura (VMC-R)",
                            VentPrice = 5250
                        });
                });

            modelBuilder.Entity("ClientRestApi.House_Config.Waste", b =>
                {
                    b.Property<int>("WasteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WasteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WastePrice")
                        .HasColumnType("int");

                    b.HasKey("WasteId");

                    b.ToTable("Wastes");

                    b.HasData(
                        new
                        {
                            WasteId = 1,
                            WasteName = "Canalizare",
                            WastePrice = 1250
                        },
                        new
                        {
                            WasteId = 2,
                            WasteName = "Fosa Septica",
                            WastePrice = 6000
                        });
                });

            modelBuilder.Entity("ClientRestApi.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "fertuionutdragos@yahoo.com",
                            FirstName = "Dragos Ionut",
                            LastName = "Fertu",
                            Password = "Jmek123",
                            PhoneNumber = "0769258202"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "romeofantastik@yahoo.com",
                            FirstName = "Romeo",
                            LastName = "Fantastik",
                            Password = "Crrmrr69",
                            PhoneNumber = "0762413567"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "roserose@yahoo.com",
                            FirstName = "Dragos",
                            LastName = "Pardafir",
                            Password = "Aaaahhhh3",
                            PhoneNumber = "0745667893"
                        });
                });

            modelBuilder.Entity("ClientRestApi.Admin.AdminUser", b =>
                {
                    b.HasOne("ClientRestApi.Contracte.ContracteApartamente", "ContracteApartamente")
                        .WithMany()
                        .HasForeignKey("ContracteApartamenteContractApId");

                    b.Navigation("ContracteApartamente");
                });

            modelBuilder.Entity("ClientRestApi.Admin.Apartament", b =>
                {
                    b.HasOne("ClientRestApi.Admin.Proiect", "Proiect")
                        .WithMany("Apartamente")
                        .HasForeignKey("ProiectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proiect");
                });

            modelBuilder.Entity("ClientRestApi.Admin.Imagine", b =>
                {
                    b.HasOne("ClientRestApi.Admin.Proiect", "Proiect")
                        .WithMany("Imagini")
                        .HasForeignKey("ProiectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proiect");
                });

            modelBuilder.Entity("ClientRestApi.Angajati.EchipaConstructorBlocuri", b =>
                {
                    b.HasOne("ClientRestApi.Admin.Proiect", "Proiect")
                        .WithOne("EchipaConstructorBlocuri")
                        .HasForeignKey("ClientRestApi.Angajati.EchipaConstructorBlocuri", "ProiectId");

                    b.Navigation("Proiect");
                });

            modelBuilder.Entity("ClientRestApi.Constructori.EchipaConstructorCase", b =>
                {
                    b.HasOne("ClientRestApi.Admin.CasaVanduta", "CasaVanduta")
                        .WithOne("EchipaConstructorCase")
                        .HasForeignKey("ClientRestApi.Constructori.EchipaConstructorCase", "CasaId");

                    b.Navigation("CasaVanduta");
                });

            modelBuilder.Entity("ClientRestApi.Contracte.ContracteApartamente", b =>
                {
                    b.HasOne("ClientRestApi.Admin.AdminUser", "AdminUser")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientRestApi.Admin.Apartament", "Apartament")
                        .WithMany()
                        .HasForeignKey("ApartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientRestApi.Admin.Apartament", null)
                        .WithOne("ContracteApartamente")
                        .HasForeignKey("ClientRestApi.Contracte.ContracteApartamente", "ApartamentId1");

                    b.HasOne("ClientRestApi.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientRestApi.User", null)
                        .WithOne("ContracteApartamente")
                        .HasForeignKey("ClientRestApi.Contracte.ContracteApartamente", "UserId1");

                    b.Navigation("AdminUser");

                    b.Navigation("Apartament");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClientRestApi.Contracte.ContracteCase", b =>
                {
                    b.HasOne("ClientRestApi.Admin.AdminUser", "AdminUser")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientRestApi.Admin.CasaVanduta", "CasaVanduta")
                        .WithMany()
                        .HasForeignKey("CasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientRestApi.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminUser");

                    b.Navigation("CasaVanduta");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClientRestApi.House_Config.ConfigCamera", b =>
                {
                    b.HasOne("ClientRestApi.House_Config.ConfigCasa", "ConfigCasa")
                        .WithMany("ConfigCameras")
                        .HasForeignKey("ConfigCasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConfigCasa");
                });

            modelBuilder.Entity("ClientRestApi.House_Config.ConfigCasa", b =>
                {
                    b.HasOne("ClientRestApi.User", "User")
                        .WithMany("ConfigCasas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClientRestApi.Admin.Apartament", b =>
                {
                    b.Navigation("ContracteApartamente");
                });

            modelBuilder.Entity("ClientRestApi.Admin.CasaVanduta", b =>
                {
                    b.Navigation("EchipaConstructorCase");
                });

            modelBuilder.Entity("ClientRestApi.Admin.Proiect", b =>
                {
                    b.Navigation("Apartamente");

                    b.Navigation("EchipaConstructorBlocuri");

                    b.Navigation("Imagini");
                });

            modelBuilder.Entity("ClientRestApi.House_Config.ConfigCasa", b =>
                {
                    b.Navigation("ConfigCameras");
                });

            modelBuilder.Entity("ClientRestApi.User", b =>
                {
                    b.Navigation("ConfigCasas");

                    b.Navigation("ContracteApartamente");
                });
#pragma warning restore 612, 618
        }
    }
}

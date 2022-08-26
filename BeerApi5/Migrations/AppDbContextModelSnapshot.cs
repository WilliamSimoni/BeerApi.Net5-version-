﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.DataContext;

namespace BeerApi5.Migrations
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

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AlcoholContent")
                        .HasColumnType("float");

                    b.Property<int>("BreweryId")
                        .HasColumnType("int");

                    b.Property<bool>("InProduction")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OutOfProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SellingPriceToClients")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<decimal>("SellingPriceToWholesalers")
                        .HasColumnType("Decimal(10,2)");

                    b.HasKey("BeerId");

                    b.HasIndex("BreweryId");

                    b.HasIndex("Name", "OutOfProductionDate", "BreweryId")
                        .IsUnique();

                    b.ToTable("Beer");

                    b.HasData(
                        new
                        {
                            BeerId = 1,
                            AlcoholContent = 11.0,
                            BreweryId = 1,
                            InProduction = true,
                            Name = "forte hendrik quadrupel",
                            OutOfProductionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPriceToClients = 10.99m,
                            SellingPriceToWholesalers = 3.99m
                        },
                        new
                        {
                            BeerId = 2,
                            AlcoholContent = 6.0,
                            BreweryId = 1,
                            InProduction = true,
                            Name = "brugse zot blond",
                            OutOfProductionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPriceToClients = 12.99m,
                            SellingPriceToWholesalers = 4.99m
                        },
                        new
                        {
                            BeerId = 3,
                            AlcoholContent = 0.40000000000000002,
                            BreweryId = 1,
                            InProduction = true,
                            Name = "sportzot",
                            OutOfProductionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPriceToClients = 6.99m,
                            SellingPriceToWholesalers = 1.59m
                        },
                        new
                        {
                            BeerId = 4,
                            AlcoholContent = 5.0,
                            BreweryId = 2,
                            InProduction = true,
                            Name = "bourgogne des flandres",
                            OutOfProductionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SellingPriceToClients = 2.59m,
                            SellingPriceToWholesalers = 0.29m
                        },
                        new
                        {
                            BeerId = 5,
                            AlcoholContent = 7.5,
                            BreweryId = 1,
                            InProduction = false,
                            Name = "Brugse Zot Dubbel",
                            OutOfProductionDate = new DateTime(2022, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            SellingPriceToClients = 19.99m,
                            SellingPriceToWholesalers = 8.99m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Brewery", b =>
                {
                    b.Property<int>("BreweryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BreweryId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brewery");

                    b.HasData(
                        new
                        {
                            BreweryId = 1,
                            Address = "walplein 26 8000 brugge",
                            Email = "info@halvemaan.be",
                            Name = "huisbrouwerij de halve maan"
                        },
                        new
                        {
                            BreweryId = 2,
                            Address = "kartuizerinnenstraat 6 8000 brugge",
                            Email = "visits@bourgognedesflandres",
                            Name = "bourgogne des flandres"
                        });
                });

            modelBuilder.Entity("Domain.Entities.InventoryBeer", b =>
                {
                    b.Property<int>("InventoryBeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("WholesalerId")
                        .HasColumnType("int");

                    b.HasKey("InventoryBeerId");

                    b.HasIndex("WholesalerId");

                    b.HasIndex("BeerId", "WholesalerId")
                        .IsUnique();

                    b.ToTable("InventoryBeer");

                    b.HasData(
                        new
                        {
                            InventoryBeerId = 1,
                            BeerId = 1,
                            Quantity = 250,
                            WholesalerId = 1
                        },
                        new
                        {
                            InventoryBeerId = 2,
                            BeerId = 2,
                            Quantity = 30,
                            WholesalerId = 2
                        },
                        new
                        {
                            InventoryBeerId = 3,
                            BeerId = 1,
                            Quantity = 70,
                            WholesalerId = 2
                        },
                        new
                        {
                            InventoryBeerId = 4,
                            BeerId = 5,
                            Quantity = 12,
                            WholesalerId = 3
                        },
                        new
                        {
                            InventoryBeerId = 5,
                            BeerId = 4,
                            Quantity = 500,
                            WholesalerId = 3
                        },
                        new
                        {
                            InventoryBeerId = 6,
                            BeerId = 3,
                            Quantity = 437,
                            WholesalerId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<decimal>("NumberOfUnits")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<int>("WholesalerId")
                        .HasColumnType("int");

                    b.HasKey("SaleId");

                    b.HasIndex("BeerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("Sale");

                    b.HasData(
                        new
                        {
                            SaleId = 1,
                            BeerId = 1,
                            Discount = 0,
                            NumberOfUnits = 1000m,
                            PricePerUnit = 3.99m,
                            SaleDate = new DateTime(2020, 9, 4, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 3990m,
                            WholesalerId = 1
                        },
                        new
                        {
                            SaleId = 2,
                            BeerId = 5,
                            Discount = 0,
                            NumberOfUnits = 1000m,
                            PricePerUnit = 8.99m,
                            SaleDate = new DateTime(2020, 10, 4, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 8990m,
                            WholesalerId = 1
                        },
                        new
                        {
                            SaleId = 3,
                            BeerId = 2,
                            Discount = 0,
                            NumberOfUnits = 200m,
                            PricePerUnit = 4.99m,
                            SaleDate = new DateTime(2020, 11, 4, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 998m,
                            WholesalerId = 1
                        },
                        new
                        {
                            SaleId = 4,
                            BeerId = 1,
                            Discount = 2,
                            NumberOfUnits = 300m,
                            PricePerUnit = 3.99m,
                            SaleDate = new DateTime(2021, 2, 3, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 978.04m,
                            WholesalerId = 2
                        },
                        new
                        {
                            SaleId = 5,
                            BeerId = 2,
                            Discount = 0,
                            NumberOfUnits = 2000m,
                            PricePerUnit = 4.59m,
                            SaleDate = new DateTime(2021, 8, 6, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 9180m,
                            WholesalerId = 3
                        },
                        new
                        {
                            SaleId = 6,
                            BeerId = 4,
                            Discount = 0,
                            NumberOfUnits = 200m,
                            PricePerUnit = 0.29m,
                            SaleDate = new DateTime(2021, 5, 4, 14, 7, 0, 0, DateTimeKind.Unspecified),
                            Total = 196m,
                            WholesalerId = 2
                        },
                        new
                        {
                            SaleId = 7,
                            BeerId = 2,
                            Discount = 0,
                            NumberOfUnits = 200m,
                            PricePerUnit = 4.99m,
                            SaleDate = new DateTime(2022, 1, 2, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 998m,
                            WholesalerId = 1
                        },
                        new
                        {
                            SaleId = 8,
                            BeerId = 1,
                            Discount = 0,
                            NumberOfUnits = 100m,
                            PricePerUnit = 3.99m,
                            SaleDate = new DateTime(2022, 2, 2, 20, 10, 0, 0, DateTimeKind.Unspecified),
                            Total = 399m,
                            WholesalerId = 2
                        },
                        new
                        {
                            SaleId = 9,
                            BeerId = 2,
                            Discount = 0,
                            NumberOfUnits = 150m,
                            PricePerUnit = 4.99m,
                            SaleDate = new DateTime(2022, 3, 4, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 748.5m,
                            WholesalerId = 3
                        },
                        new
                        {
                            SaleId = 10,
                            BeerId = 3,
                            Discount = 10,
                            NumberOfUnits = 1431m,
                            PricePerUnit = 1.59m,
                            SaleDate = new DateTime(2022, 5, 5, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Total = 998m,
                            WholesalerId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Wholesaler", b =>
                {
                    b.Property<int>("WholesalerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WholesalerId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Wholesaler");

                    b.HasData(
                        new
                        {
                            WholesalerId = 1,
                            Address = "jump street 21",
                            Email = "info@thebeer.be",
                            Name = "thebeer"
                        },
                        new
                        {
                            WholesalerId = 2,
                            Address = "evergreen street 32",
                            Email = "contact@berallaxcorp.com",
                            Name = "berallax corp"
                        },
                        new
                        {
                            WholesalerId = 3,
                            Address = "sesame street 77",
                            Email = "thebeercorporationinfo@beercorp.com",
                            Name = "the beer corporation"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.HasOne("Domain.Entities.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewery");
                });

            modelBuilder.Entity("Domain.Entities.InventoryBeer", b =>
                {
                    b.HasOne("Domain.Entities.Beer", "Beer")
                        .WithMany("InventoryBeers")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Wholesaler", "Wholesaler")
                        .WithMany("InventoryBeers")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("Domain.Entities.Sale", b =>
                {
                    b.HasOne("Domain.Entities.Beer", "Beer")
                        .WithMany("Sales")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Wholesaler", "Wholesaler")
                        .WithMany("Sales")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.Navigation("InventoryBeers");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Domain.Entities.Brewery", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("Domain.Entities.Wholesaler", b =>
                {
                    b.Navigation("InventoryBeers");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}

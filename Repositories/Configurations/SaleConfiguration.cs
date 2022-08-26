﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repositories.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {

        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasData(
                new Sale()
                {
                    SaleId = 1,
                    SaleDate = new DateTime(2020, 09, 04, 18, 0, 0),
                    Total = 3990,
                    NumberOfUnits = 1000,
                    PricePerUnit = 3.99m,
                    Discount = 0,
                    WholesalerId = 1,
                    BeerId = 1,
                },
                new Sale()
                {
                    SaleId = 2,
                    SaleDate = new DateTime(2020, 10, 04, 18, 0, 0),
                    Total = 8990,
                    NumberOfUnits = 1000,
                    PricePerUnit = 8.99m,
                    Discount = 0,
                    WholesalerId = 1,
                    BeerId = 5,
                },
                new Sale()
                {
                    SaleId = 3,
                    SaleDate = new DateTime(2020, 11, 04, 17, 0, 0),
                    Total = 998,
                    NumberOfUnits = 200,
                    PricePerUnit = 4.99m,
                    Discount = 0,
                    WholesalerId = 1,
                    BeerId = 2,
                },
                new Sale()
                {
                    SaleId = 4,
                    SaleDate = new DateTime(2021, 02, 03, 16, 0, 0),
                    Total = 978.04m,
                    NumberOfUnits = 300,
                    PricePerUnit = 3.99m,
                    Discount = 2,
                    BeerId = 1,
                    WholesalerId = 2
                },
                new Sale()
                {
                    SaleId = 5,
                    SaleDate = new DateTime(2021, 08, 06, 18, 0, 0),
                    Total = 9180,
                    NumberOfUnits = 2000,
                    PricePerUnit = 4.59m,
                    Discount = 0,
                    BeerId = 2,
                    WholesalerId = 3
                },
                new Sale()
                {
                    SaleId = 6,
                    SaleDate = new DateTime(2021, 05, 04, 14, 7, 0),
                    Total = 196,
                    NumberOfUnits = 200,
                    PricePerUnit = 0.29m,
                    Discount = 0,
                    BeerId = 4,
                    WholesalerId = 2
                },
                new Sale()
                {
                    SaleId = 7,
                    SaleDate = new DateTime(2022, 01, 02, 15, 0, 0),
                    Total = 998,
                    NumberOfUnits = 200,
                    PricePerUnit = 4.99m,
                    Discount = 0,
                    BeerId = 2,
                    WholesalerId = 1
                },
                new Sale()
                {
                    SaleId = 8,
                    SaleDate = new DateTime(2022, 02, 02, 20, 10, 0),
                    Total = 399,
                    NumberOfUnits = 100,
                    PricePerUnit = 3.99m,
                    Discount = 0,
                    BeerId = 1,
                    WholesalerId = 2
                },
                new Sale()
                {
                    SaleId = 9,
                    SaleDate = new DateTime(2022, 03, 04, 15, 0, 0),
                    Total = 748.5m,
                    NumberOfUnits = 150,
                    PricePerUnit = 4.99m,
                    Discount = 0,
                    BeerId = 2,
                    WholesalerId = 3
                },
                new Sale()
                {
                    SaleDate = new DateTime(2022, 05, 05, 16, 0, 0),
                    Total = 998,
                    SaleId = 10,
                    NumberOfUnits = 1431,
                    PricePerUnit = 1.59m,
                    Discount = 10,
                    BeerId = 3,
                    WholesalerId = 1
                }
                );
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //reflection
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature()
                {
                    Id = 1,
                    Color = "Kırmzıı",
                    Height = 100,
                    Width = 200,
                    ProductId = 1
                },
                new ProductFeature()
                {
                    Id = 2,
                    Color = "Mavi",
                    Height = 300,
                    Width = 300,
                    ProductId = 2
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}

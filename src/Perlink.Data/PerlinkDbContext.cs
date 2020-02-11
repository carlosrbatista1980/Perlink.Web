using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Perlink.Data.Data;


namespace Perlink.Data
{
    public class PerlinkDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Lawoffice> Lawoffice { get; set; }
        public DbSet<Lawsuit> Lawsuit { get; set; }

        public PerlinkDbContext(DbContextOptions<PerlinkDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lawoffice>().ToTable(nameof(Lawoffice));
            modelBuilder.Entity<Lawsuit>().ToTable(nameof(Lawsuit));

            //<Entities Configuration>

            //Lawoffice
            modelBuilder.Entity<Lawoffice>().HasKey(key => key.Id);
            modelBuilder.Entity<Lawoffice>().Property(prop => prop.Id).ValueGeneratedOnAdd();

            //relationship configuration
            modelBuilder.Entity<Lawoffice>().HasMany(x => x.Lawsuits).WithOne(x => x.Lawoffice).OnDelete(DeleteBehavior.Restrict);

            //Lawsuit
            modelBuilder.Entity<Lawsuit>().HasKey(key => key.Id);
            modelBuilder.Entity<Lawsuit>().Property(prop => prop.Id).ValueGeneratedOnAdd();
            
            //<Entities Configuration>

            //<Seeding default group>
            modelBuilder.Entity<IdentityRole>().HasData(new
            {
                Id = "1", Name = "admin", NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new
            {
                Id = "1",
                UserName = "admin",
                NormalizedName = "ADMIN",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            });

            //</Seeding default group>

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseMySql(configuration.GetConnectionString("Default"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        
    }
}

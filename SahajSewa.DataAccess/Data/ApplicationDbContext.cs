﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SahajSewa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Province> Provinces{ get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<DrivingCategory> DrivingCategories { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<LicenseRegistration> LicenseRegistrations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserCategory>()
                .HasKey(c => new { c.UserId, c.CategoryId });
            builder.Entity<UserCategory>().HasOne(sc => sc.ApplicationUser)
                .WithMany(c => c.UserCategory).HasForeignKey(sc => sc.UserId);
            builder.Entity<UserCategory>().HasOne(sc => sc.DrivingCategory)
                .WithMany(c => c.UserCategory).HasForeignKey(sc => sc.CategoryId);
        }

    }
}

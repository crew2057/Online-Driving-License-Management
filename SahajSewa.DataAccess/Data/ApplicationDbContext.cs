
using Microsoft.EntityFrameworkCore;
using SahajSewa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Province> Provinces{ get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<LicenseRegistration> LicenseRegistrations { get; set; }

    }
}

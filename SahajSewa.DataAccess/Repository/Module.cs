using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Repository
{
    public class Module : IModule
    {
        private readonly ApplicationDbContext _db;
        public Module(ApplicationDbContext db)
        {
            _db = db;
            LicenseRegistration = new LicenseRegistrationRepository(_db);
            License = new LicenseRepository(_db);
            UserCategory = new UserCategoryRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }

        public ILicenseRegistrationRepository LicenseRegistration { get; private set; }

        public ILicenseRepository License { get; private set; }

        public IUserCategoryRepository UserCategory { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.DataAccess.Repository
{
    public class LicenseRepository : Repository<License>, ILicenseRepository
    {
        private ApplicationDbContext _db;
        public LicenseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(License obj)
        {
            var objFromDb = _db.Licenses.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.LicenseNo = obj.LicenseNo;
                objFromDb.ProvinceId = obj.ProvinceId;
                objFromDb.OfficeId = obj.OfficeId;
                objFromDb.Phone = obj.Phone;
                objFromDb.IssueDate = obj.IssueDate;
                objFromDb.ExpiryDate = obj.ExpiryDate;
                objFromDb.LicensePhoto = obj.LicensePhoto;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Category = obj.Category;
            }

        }
    }
}

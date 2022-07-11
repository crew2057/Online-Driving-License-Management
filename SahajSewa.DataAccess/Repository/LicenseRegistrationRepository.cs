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
    public class LicenseRegistrationRepository : Repository<LicenseRegistration>, ILicenseRegistrationRepository
    {
        private ApplicationDbContext _db;
        public LicenseRegistrationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(LicenseRegistration obj)
        {
            var objFromDb = _db.LicenseRegistrations.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Fname = obj.Fname;
                objFromDb.Mname = obj.Mname;
                objFromDb.Lname = obj.Lname;
                objFromDb.DOB = obj.DOB;
                objFromDb.Gender = obj.Gender;
                objFromDb.Pnumber = obj.Pnumber;
                objFromDb.Bgroup = obj.Bgroup;
                objFromDb.Gname = obj.Gname;

                objFromDb.Pprovince = obj.Pprovince;
                objFromDb.Pdistrict = obj.Pdistrict;
                objFromDb.Pvillage = obj.Pvillage;
                objFromDb.Pward = obj.Pward;
                objFromDb.Ptole = obj.Ptole;
                objFromDb.Email = obj.Email;
                objFromDb.Tprovince = obj.Tprovince;
                objFromDb.Tdistrict = obj.Tdistrict;
                objFromDb.Tvillage = obj.Tvillage;
                objFromDb.Tward = obj.Tward;
                objFromDb.Ttole = obj.Ttole;

                objFromDb.CitizenNo = obj.CitizenNo;
                objFromDb.CitizenDistrict = obj.CitizenDistrict;
                objFromDb.CitizenDate = obj.CitizenDate;

                objFromDb.OfficeProvince = obj.OfficeProvince;
                objFromDb.OfficeVisit = obj.OfficeVisit;
                objFromDb.Category = obj.Category;

                if (obj.Photo != null)
                    objFromDb.Photo = obj.Photo;
                if (obj.CitizenFront != null)
                    objFromDb.CitizenFront = obj.CitizenFront;
                if (obj.CitizenBack != null)
                    objFromDb.CitizenBack = obj.CitizenBack;
                if (obj.Signature != null)
                    objFromDb.Signature = obj.Signature;
                if (obj.Thumb != null)
                    objFromDb.Thumb = obj.Thumb;

                if (obj.TrailCount != null)
                    objFromDb.TrailCount = obj.TrailCount;
                if (obj.WrittenResult != null)
                    objFromDb.WrittenResult = obj.WrittenResult;
                if (obj.TrailResult != null)
                    objFromDb.TrailResult = obj.TrailResult;
                if (obj.LicenseId != null)
                    objFromDb.LicenseId = obj.LicenseId;
                if (obj.PassportId != null)
                    objFromDb.PassportId = obj.PassportId;
            }
        }
    }
}

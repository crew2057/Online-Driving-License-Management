using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using SahajSewa.Models.ViewModels;

namespace SahajSewa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManageAllController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IModule _module;

        public ManageAllController(ApplicationDbContext db, IModule module)
        {
            _db = db;
            _module = module;
        }

        public IActionResult Index()
        {
            List<LicenseRegistration> userList= _module.LicenseRegistration.GetAll(includeProperties: "ApplicationUser").OrderByDescending(u=>u.Id).DistinctBy(u => u.ApplicantId).ToList();
            return View(userList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(List<LicenseRegistration> obj)
        {
            for(int i = 0; i < obj.Count(); i++)
            {
                LicenseRegistration item = _module.LicenseRegistration.GetFirstOrDefault(u => u.Id == obj[i].Id);
                if (obj[i].WrittenResult!=null)
                item.WrittenResult = obj[i].WrittenResult;
                if (obj[i].TrailResult!=null)
                item.TrailResult = obj[i].TrailResult;
                _module.LicenseRegistration.Update(item);
                _module.Save();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Approval(int id)
        {
            LicenseRegistration obj = _db.LicenseRegistrations.FirstOrDefault(u => u.Id == id);
            ViewBag.Pprovince = _db.Provinces.FirstOrDefault(u => u.Id == obj.Pprovince).Name;
            ViewBag.Pdistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.Pdistrict).Name;
            ViewBag.Pvillage = _db.Villages.FirstOrDefault(u => u.Id == obj.Pvillage).Name;
            if (obj.Tprovince != null)
            {
                ViewBag.Tprovince = _db.Provinces.FirstOrDefault(u => u.Id == obj.Tprovince).Name;
                ViewBag.Tdistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.Tdistrict).Name;
                ViewBag.Tvillage = _db.Villages.FirstOrDefault(u => u.Id == obj.Tvillage).Name;
            }
            ViewBag.CitizenDistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.CitizenDistrict).Name;
            ViewBag.OfficeProvince = _db.Provinces.FirstOrDefault(u => u.Id == obj.OfficeProvince).Name;
            ViewBag.OfficeVisit = _db.Offices.FirstOrDefault(u => u.Id == obj.OfficeVisit).Name;
            ViewBag.CategoryName = _db.DrivingCategories.FirstOrDefault(u => u.Id == obj.Category).Name;
            ViewBag.CategorySymbol = _db.DrivingCategories.FirstOrDefault(u => u.Id == obj.Category).Symbol;
            return View(obj);
        }

        [HttpPost]
        [ActionName("Approval")]
        [ValidateAntiForgeryToken]
        public IActionResult ApprovalPost(LicenseRegistration obj)
        {
            return RedirectToAction("index","Home");
        }
        public IActionResult WrittenList()
        {
            List<LicenseRegistration> userList = _module.LicenseRegistration.GetAll(includeProperties: "DrivingCategory").Where(u=>u.WrittenResult==null).OrderByDescending(u => u.Id).DistinctBy(u => u.ApplicantId).ToList();
            return View(userList);
        }

        public IActionResult TrailList()
        {
            List<LicenseRegistration> userList = _module.LicenseRegistration.GetAll(includeProperties: "DrivingCategory").Where(u=>u.WrittenResult=="pass"&&u.TrailResult==null).OrderByDescending(u => u.Id).DistinctBy(u => u.ApplicantId).ToList();
            return View(userList);
        }

    
        //public IActionResult UpdateStatus(int id)
        //{
        //    LicenseRegistration obj = _module.LicenseRegistration.GetFirstOrDefault(u => u.Id == id);
        //    //obj.WrittenResult = test;
        //    //_module.LicenseRegistration.Update(obj);
        //    //_module.Save();
        //    return RedirectToAction("Index");
        //}
    }
}

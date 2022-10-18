using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using System.Security.Claims;

namespace SahajSewa.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class AddCategoryController : Controller
    {
        private readonly IModule _module;
        private readonly ApplicationDbContext _db;
        
        public AddCategoryController(IModule module, ApplicationDbContext db)
        {
            _module = module;
            _db=db;
        }
        public IActionResult Insert()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            LicenseRegistration obj = _db.LicenseRegistrations.OrderBy(u => u.Id).LastOrDefault(u => u.ApplicantId == claim.Value);
            if (obj==null)
                return RedirectToAction("Upsert", "LicenseRegistration");
            else if (obj.TrailResult == "fail" || obj.WrittenResult == "fail")
                return View(obj);

            License check = _module.License.GetFirstOrDefault(u => u.ApplicantId == claim.Value);
            if (check == null)
            {
                TempData["error"] = "Please add your license details before proceeding with adding category";
                return RedirectToAction("Index", "Home");
            }

            //LicenseRegistration obj = _db.LicenseRegistrations.OrderBy(u=>u.Id).LastOrDefault(u=>u.ApplicantId==claim.Value);
            //if (obj == null)
            return View(obj);
        }

        public JsonResult Pprovince()
        {
            var pro = _db.Provinces.ToList();
            return new JsonResult(pro);
        }
        public JsonResult Oname(int Id)
        {
            var obj = _db.Offices.Where(u => u.ProvinceId == Id).ToList();
            return new JsonResult(obj);
        }
        public JsonResult Category()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var asset = _module.UserCategory.GetAll(u => u.UserId == claim.Value);
            IEnumerable<DrivingCategory> obj = _db.DrivingCategories.ToList();
            foreach (var item in asset)
            {
                obj = obj.Where(u => u.Id != item.CategoryId);
            }
            return new JsonResult(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(LicenseRegistration obj)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            LicenseRegistration obj1 = _db.LicenseRegistrations.OrderBy(u=>u.Id).LastOrDefault(u => u.ApplicantId==claim.Value);
            obj1.OfficeProvince = obj.OfficeProvince;
            obj1.OfficeVisit = obj.OfficeVisit;
            obj1.Category = obj.Category;
            obj1.Id = obj.Id;
            obj1.TrailCount = 1;
            obj1.TrailResult = obj.TrailResult;
            obj1.OldSessionId = obj.OldSessionId;
            obj1.SessionId = obj.SessionId;
            if (obj1.LicenseAvailability == true)
                obj.WrittenResult = "pass";
            else
                obj1.WrittenResult = obj.WrittenResult;

            //UserCategory addcategory = new UserCategory()
            //{
            //    UserId = claim.Value,
            //    CategoryId = obj.Category
            //};
            //_module.UserCategory.Add(addcategory);
            _module.LicenseRegistration.Add(obj1);
            _module.Save();
            return RedirectToAction("Details", "LicenseRegistration", obj1);
        }
    }
}

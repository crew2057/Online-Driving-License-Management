using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;

namespace SahajSewa.Areas.Users.Controllers
{
    public class LicenseRegistrationController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IModule _module;
        private readonly ApplicationDbContext _db;

        public LicenseRegistrationController(
            ApplicationDbContext db,
            IModule module,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _module = module;
            _hostEnvironment = hostEnvironment;
        }
        //Get
        public IActionResult Create()
        {
            LicenseRegistration obj = new();
            return View(obj);
        }


        public JsonResult Pprovince()
        {
            var pro = _db.Provinces.ToList();
            return new JsonResult(pro);
        }
        public JsonResult Pdistrict(int Id)
        {
            var dis = _db.Districts.Where(u => u.ProvinceId == Id).ToList();
            return new JsonResult(dis);
        }

        public JsonResult Pvillage(int Id)
        {
            var vil = _db.Villages.Where(u => u.DistrictId== Id).ToList();
            return new JsonResult(vil);
        }

        public JsonResult Idistrict()
        {
            var dis = _db.Districts.ToList();
            return new JsonResult(dis);
        }
        public JsonResult Oname(int Id)
        {
            var obj = _db.Offices.Where(u=>u.ProvinceId==Id).ToList();
            return new JsonResult(obj);
        }

        public JsonResult Category()
        {
            var obj = _db.DrivingCategories.ToList();
            return new JsonResult(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LicenseRegistration obj)
        {
            if(ModelState.IsValid)
            {
                _module.LicenseRegistration.Add(obj);
                _module.Save();
                TempData["success"] = "Product Created Successfully";
                RedirectToAction("Index", "Home");
            }
            return View(obj);
        }
    }
}

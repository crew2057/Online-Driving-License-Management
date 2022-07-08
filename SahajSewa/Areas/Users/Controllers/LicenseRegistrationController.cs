using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models.ViewModels;

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
            LicenseRegistrationVM VM = new()
            {
                LicenseRegistration = new(),
                ProvinceList = _db.Provinces.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                DistrictList = _db.Districts.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillageList = _db.Villages.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                OfficeList = _db.Offices.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CategoryList = _db.DrivingCategories.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(VM);
        }


    }
}

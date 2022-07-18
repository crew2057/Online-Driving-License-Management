using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;

namespace SahajSewa.Areas.Users.Controllers
{

    [Area("Users")]
    [Authorize]
    public class LicenseController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IModule _module;
        private readonly ApplicationDbContext _db;

        public LicenseController(
            ApplicationDbContext db,
            IModule module,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _module = module;
            _hostEnvironment = hostEnvironment;
        }
        //Get
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                License obj = new();
                return View(obj);
            }
            else
            {
                License obj = _module.License.GetFirstOrDefault(u => u.Id == id);
                return View(obj);
            }

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
        public IActionResult Details()
        {
            return View();
        }
    }
}

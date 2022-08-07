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

        public IActionResult UpdateStatus(int id)
        {
            LicenseRegistration obj = _module.LicenseRegistration.GetFirstOrDefault(u => u.Id == id);
            //obj.WrittenResult = test;
            //_module.LicenseRegistration.Update(obj);
            //_module.Save();
            return RedirectToAction("Index");
        }
    }
}

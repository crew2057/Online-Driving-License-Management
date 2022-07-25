using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using SahajSewa.Models.ViewModels;
using System.Security.Claims;

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
            var item = _db.DrivingCategories.ToList();
            if (id == null || id == 0)
            {
                LicenseVM obj = new LicenseVM {
                    AvailableCategory = item.Select(vm => new CheckBoxVM()
                    {
                        Id = vm.Id,
                        Name = vm.Symbol,
                        IsChecked = false
                    }).ToList(),
                    License = new()
            };
                return View(obj);
            }
            else
            {
                LicenseVM obj = new LicenseVM
                {
                    License = _module.License.GetFirstOrDefault(u => u.Id == id),
                    AvailableCategory = item.Select(vm => new CheckBoxVM()
                    {
                        Id = vm.Id,
                        Name = vm.Symbol,
                        IsChecked = false
                    }).ToList()
                };
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(LicenseVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images");
                    var extension = Path.GetExtension(file.FileName);
                    if (obj.License.LicensePhoto != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.License.LicensePhoto.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.License.LicensePhoto = @"\images\" + fileName + extension;
                }

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                obj.License.ApplicantId = claim.Value;
                _module.License.Add(obj.License);
                _module.Save();
                List<UserCategory> data = new List<UserCategory>();
                foreach(var item in obj.AvailableCategory)
                {
                    if (item.IsChecked == true)
                    {
                        data.Add(new UserCategory() { UserId = obj.License.ApplicantId, CategoryId = item.Id });
                    }
                }
                foreach(var item in data)
                {
                    _db.UserCategories.Add(item);
                }
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View();

        }
        public IActionResult Details()
        {
            return View();
        }
    }
}

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
        public IActionResult Upsert()
        {
            var item = _db.DrivingCategories.ToList();
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
            //else
            //{
            //    LicenseVM obj = new LicenseVM
            //    {
            //        License = _module.License.GetFirstOrDefault(u => u.Id == id),
            //        AvailableCategory = item.Select(vm => new CheckBoxVM()
            //        {
            //            Id = vm.Id,
            //            Name = vm.Symbol,
            //            IsChecked = false
            //        }).ToList()
            //    };
            //    var data = _module.UserCategory.GetAll(u => u.UserId == obj.License.ApplicantId);
            //    foreach(var val in data)
            //    {
            //        foreach(var value in obj.AvailableCategory)
            //        {
            //            if (val.CategoryId == value.Id)
            //                value.IsChecked = true;
            //        }
            //    }
            //    return View(obj);
            //}

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

                foreach(var item in obj.AvailableCategory)
                {
                    if (item.IsChecked == true)
                    {
                        UserCategory data = new UserCategory()
                        {
                            UserId = obj.License.ApplicantId,
                            CategoryId = item.Id
                        };
                        if(!_db.UserCategories.Contains(data))
                        _module.UserCategory.Add(data);
                    }
                }
                _module.Save();

                License container = _module.License.GetFirstOrDefault(u => u.ApplicantId == claim.Value);
                return RedirectToAction("Details",new { container.Id});
            }
            return View(obj);

        }
        public IActionResult Details(int Id)
        {
            License obj = _module.License.GetFirstOrDefault(u => u.Id == Id);
            ViewBag.ProvinceName = _db.Provinces.FirstOrDefault(u => u.Id == obj.ProvinceId).Name;
            ViewBag.OfficeName = _db.Offices.FirstOrDefault(u => u.Id == obj.OfficeId).Name;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<UserCategory> obj1 = _module.UserCategory.GetAll(u => u.UserId == claim.Value);
            IEnumerable<DrivingCategory> obj2 = _db.DrivingCategories;
            foreach (var item in obj1)
            {
                obj2 = obj2.Where(u => item.CategoryId != u.Id);
            }
            IEnumerable<DrivingCategory> obj3 = _db.DrivingCategories;
            foreach(var item in obj2)
            {
                obj3 = obj3.Where(u => u.Id != item.Id);
            }
            ViewBag.CategoryList = obj3;
                return View(obj);
        }
    }
}

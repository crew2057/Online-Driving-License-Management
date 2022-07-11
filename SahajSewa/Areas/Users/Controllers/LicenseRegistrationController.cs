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
        public IActionResult Create(LicenseRegistration obj,IFormFile? file1, IFormFile? file2, IFormFile? file3, IFormFile? file4, IFormFile? file5)
        {
         if(ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file1 != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images");
                    var extension = Path.GetExtension(file1.FileName);
                    if (obj.Photo != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Photo.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                    file1.CopyTo(fileStreams);
                    }
                    obj.Photo = @"\images\products" + fileName + extension;
                }
            if (file2 != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images");
                var extension = Path.GetExtension(file2.FileName);
                if (obj.CitizenFront != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.CitizenFront.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file2.CopyTo(fileStreams);
                }
                obj.CitizenFront = @"\images\products" + fileName + extension;
            }
            if (file3 != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images");
                var extension = Path.GetExtension(file3.FileName);
                if (obj.CitizenBack != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.CitizenBack.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file3.CopyTo(fileStreams);
                }
                obj.CitizenBack = @"\images\products" + fileName + extension;
            }
            if (file4 != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images");
                var extension = Path.GetExtension(file4.FileName);
                if (obj.Signature != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Signature.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file4.CopyTo(fileStreams);
                }
                obj.Signature = @"\images\products" + fileName + extension;
            }
            if (file5 != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images");
                var extension = Path.GetExtension(file5.FileName);
                if (obj.Thumb != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Thumb.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file5.CopyTo(fileStreams);
                }
                obj.Thumb = @"\images\products" + fileName + extension;
            }

                _module.LicenseRegistration.Add(obj);
                _module.Save();
              return  RedirectToAction("Index", "Home");
            }
            return View(obj);
        }
    }
}

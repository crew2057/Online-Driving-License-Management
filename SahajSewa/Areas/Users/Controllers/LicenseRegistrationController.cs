using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using Stripe.Checkout;

namespace SahajSewa.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
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
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                LicenseRegistration obj = new();
                return View(obj);
            }
            else
            {
                LicenseRegistration obj = _module.LicenseRegistration.GetFirstOrDefault(u => u.Id == id);
                return View(obj);
            }
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
            var vil = _db.Villages.Where(u => u.DistrictId == Id).ToList();
            return new JsonResult(vil);
        }

        public JsonResult Idistrict()
        {
            var dis = _db.Districts.ToList();
            return new JsonResult(dis);
        }
        public JsonResult Oname(int Id)
        {
            var obj = _db.Offices.Where(u => u.ProvinceId == Id).ToList();
            return new JsonResult(obj);
        }

        public JsonResult Category()
        {
            var obj = _db.DrivingCategories.ToList();
            return new JsonResult(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(LicenseRegistration obj, IFormFile? file1, IFormFile? file2, IFormFile? file3, IFormFile? file4, IFormFile? file5)
        {
            if (ModelState.IsValid)
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
                    obj.Photo = @"\images\" + fileName + extension;
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
                    obj.CitizenFront = @"\images\" + fileName + extension;
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
                    obj.CitizenBack = @"\images\" + fileName + extension;
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
                    obj.Signature = @"\images\" + fileName + extension;
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
                    obj.Thumb = @"\images\" + fileName + extension;
                }

                if (obj.Id == 0)
                    _module.LicenseRegistration.Add(obj);
                else
                    _module.LicenseRegistration.Update(obj);
                _module.Save();
                return RedirectToAction("Details", "LicenseRegistration", obj);
            }
            TempData["error"] = "Please fill up all the required details";
            return View(obj);
        }

        //Details in progress
        public IActionResult Details(LicenseRegistration obj)
        {
            ViewBag.Pprovince = _db.Provinces.FirstOrDefault(u => u.Id == obj.Pprovince).Name;
            ViewBag.Pdistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.Pdistrict).Name;
            ViewBag.Pvillage = _db.Villages.FirstOrDefault(u => u.Id == obj.Pvillage).Name;
            ViewBag.Tprovince = _db.Provinces.FirstOrDefault(u => u.Id == obj.Tprovince).Name;
            ViewBag.Tdistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.Tdistrict).Name;
            ViewBag.Tvillage = _db.Villages.FirstOrDefault(u => u.Id == obj.Tvillage).Name;
            ViewBag.CitizenDistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.CitizenDistrict).Name;
            ViewBag.OfficeProvince = _db.Provinces.FirstOrDefault(u => u.Id == obj.OfficeProvince).Name;
            ViewBag.OfficeVisit = _db.Offices.FirstOrDefault(u => u.Id == obj.OfficeVisit).Name;
            ViewBag.Category = _db.DrivingCategories.FirstOrDefault(u => u.Id == obj.Category).Name;
            return View(obj);
        }
        
        [HttpPost]
        [ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(LicenseRegistration obj)
        {
            //Stripe settings
            var domain = "https://localhost:44305/";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                        {
                            new SessionLineItemOptions
                            {
                                PriceData = new SessionLineItemPriceDataOptions
                                {
                                    UnitAmount = 50000,
                                    Currency = "npr",
                                    ProductData = new SessionLineItemPriceDataProductDataOptions
                                    {
                                        Name = "License Registration Fee",
                                    },

                                },
                                Quantity = 1,
                            },
                        },
                Mode = "payment",
                SuccessUrl = domain + $"Users/LicenseRegistration/DownloadFile?id={obj.Id}",
                CancelUrl = domain + $"Users/LicenseRegistration/Details?id={obj.Id}",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            obj.SessionId = session.Id;
            obj.PaymentIntentId = session.PaymentIntentId;
            _module.LicenseRegistration.Update(obj);
            _module.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
            //End stripe settings
        }

        public IActionResult DownloadFile(int id)
        {
            LicenseRegistration obj = _module.LicenseRegistration.GetFirstOrDefault(u => u.Id == id);

            ViewBag.Pprovince = _db.Provinces.FirstOrDefault(u => u.Id == obj.Pprovince).Name;
            ViewBag.Pdistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.Pdistrict).Name;
            ViewBag.Pvillage = _db.Villages.FirstOrDefault(u => u.Id == obj.Pvillage).Name;
            ViewBag.OfficeVisit = _db.Offices.FirstOrDefault(u => u.Id == obj.OfficeVisit).Name;
            ViewBag.Category = _db.DrivingCategories.FirstOrDefault(u => u.Id == obj.Category).Name;


            var service = new SessionService();
            Session session = service.Get(obj.SessionId);
            //check if payment is actually made
            if (session.PaymentStatus.ToLower() == "paid")
            {
                obj.TrailCount=1;
                TempData["success"] = "License registration successful";
                return View(obj);
            }
            TempData["error"] = "Unspecified access to stripe";
            return RedirectToAction("Index", "Home");

        }


    }
}

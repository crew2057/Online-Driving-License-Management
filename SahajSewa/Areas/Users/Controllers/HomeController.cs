using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using SahajSewa.Models.ViewModels;
using Stripe.Checkout;
using System.Diagnostics;
using System.Security.Claims;

namespace SahajSewa.Controllers
{
    [Area("Users")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModule _module;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment hostEnvironment, IModule module,
            ApplicationDbContext db)
        {
            _logger = logger;
            _module = module;
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            IndexVM user = new IndexVM();
            user.ApplicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == claim.Value);
            user.LicenseRegistration = _db.LicenseRegistrations.OrderBy(u=>u.Id).LastOrDefault(u => u.ApplicantId == claim.Value);
            if (user.LicenseRegistration == null)
                user.LicenseRegistration = new LicenseRegistration();      
            user.License = _db.Licenses.FirstOrDefault(u => u.ApplicantId == claim.Value);
            if (user.License == null)
                user.License = new License();
            user.Passport = _db.Passports.FirstOrDefault(u => u.ApplicantId == claim.Value);
            if (user.Passport == null)
                user.Passport = new Passport();

            if (user.LicenseRegistration != null && user.LicenseRegistration.TrailResult == "pass")
            {
                UserCategory sample = new UserCategory()
                {
                    UserId = claim.Value,
                    CategoryId = user.LicenseRegistration.Category
                };
                if (!_db.UserCategories.Contains(sample))
                {
                    _module.UserCategory.Add(sample);
                    _module.Save();
                }
            }


            LicenseRegistration obj = user.LicenseRegistration;
            if (obj.Id != 0)
            {
                if (obj.SessionId == null)
                {
                    LicenseRegistration same = _db.LicenseRegistrations.FirstOrDefault(u => u.ApplicantId == claim.Value);
                    if (obj == same)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        var file1 = Path.Combine(wwwRootPath, obj.Photo.TrimStart('\\'));
                        System.IO.File.Delete(file1);

                        var file2 = Path.Combine(wwwRootPath, obj.CitizenFront.TrimStart('\\'));
                        System.IO.File.Delete(file2);

                        var file3 = Path.Combine(wwwRootPath, obj.CitizenBack.TrimStart('\\'));
                        System.IO.File.Delete(file3);

                        var file4 = Path.Combine(wwwRootPath, obj.Signature.TrimStart('\\'));
                        System.IO.File.Delete(file4);

                        var file5 = Path.Combine(wwwRootPath, obj.Thumb.TrimStart('\\'));
                        System.IO.File.Delete(file5);
                    }
                    _module.LicenseRegistration.Remove(obj);
                    _module.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    var service = new SessionService();
                    Session session = service.Get(obj.SessionId);
                    if (session.PaymentStatus.ToLower() != "paid")
                    {
                        if (obj.OldSessionId != null)
                        {
                            obj.SessionId = obj.OldSessionId;
                            session = service.Get(obj.SessionId);
                            obj.PaymentIntentId = session.PaymentIntentId;
                            obj.TrailCount--;
                        }
                        else
                            obj.SessionId = null;
                        _module.LicenseRegistration.Update(obj);
                        _module.Save();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
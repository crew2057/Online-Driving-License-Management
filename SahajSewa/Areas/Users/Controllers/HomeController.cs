using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using Stripe.Checkout;
using System.Diagnostics;

namespace SahajSewa.Controllers
{
    [Area("Users")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModule _module;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment hostEnvironment, IModule module)
        {
            _logger = logger;
            _module = module;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<LicenseRegistration> objects = _module.LicenseRegistration.GetAll();
            foreach (var obj in objects)
            {
                    if (obj.SessionId == null)
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
                    
                    _module.LicenseRegistration.Remove(obj);
                    _module.Save();
                }
                else
                {
                    var service = new SessionService();
                    Session session = service.Get(obj.SessionId);
                    if(session.PaymentStatus.ToLower() != "paid")
                    {
                        obj.SessionId = null;
                        _module.Save();
                        return RedirectToAction("Index");
                    }
                    else
                    return View(obj);
                }
            }
            LicenseRegistration temp = new();
            return View(temp);
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
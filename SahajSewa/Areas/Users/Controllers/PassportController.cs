using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahajSewa.DataAccess.Data;
using SahajSewa.Models;
using System.Security.Claims;

namespace SahajSewa.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class PassportController : Controller
    {

        public readonly IWebHostEnvironment _hostEnvironment;
        public readonly ApplicationDbContext _db;

        public PassportController(IWebHostEnvironment hostEnvironment,
            ApplicationDbContext db)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Insert()
        {
            Passport obj = new();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Passport obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images");
                    var extension = Path.GetExtension(file.FileName);
                    if (obj.PassportPhoto != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.PassportPhoto.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.PassportPhoto = @"\images\" + fileName + extension;
                }

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                obj.ApplicantId = claim.Value;
                _db.Passports.Add(obj);
                _db.SaveChanges();
                Passport container = _db.Passports.FirstOrDefault(u => u.ApplicantId == claim.Value);
                return RedirectToAction("Details",new {container.Id});
            }
            return View(obj);
        }

        public IActionResult Details(int Id)
        {
            Passport obj = _db.Passports.FirstOrDefault(u => u.Id == Id);
            return View(obj);
        }
    }
}

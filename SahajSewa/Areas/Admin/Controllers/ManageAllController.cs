using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SahajSewa.DataAccess.Data;
using SahajSewa.DataAccess.Repository.IRepository;
using SahajSewa.Models;
using SahajSewa.Models.ViewModels;
using SahajSewa.Utility;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SahajSewa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManageAllController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IModule _module;
        private readonly IEmailSender _emailSender;
        private TwilioSettings _twilioOptions { get; set; }

        public ManageAllController(ApplicationDbContext db, IEmailSender emailSender, IModule module, IOptions<TwilioSettings> twilioOptions)
        {
            _db = db;
            _module = module;
            _twilioOptions = twilioOptions.Value;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            List<LicenseRegistration> userList= _module.LicenseRegistration.GetAll(includeProperties: "DrivingCategory").OrderByDescending(u=>u.Id).DistinctBy(u => u.ApplicantId).ToList();
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

        public IActionResult Approval(int id)
        {
            LicenseRegistration obj = _db.LicenseRegistrations.OrderBy(u => u.Id).LastOrDefault(u => u.Id == id);
            if (obj.Approved != true)
            {
                ViewBag.Pprovince = _db.Provinces.FirstOrDefault(u => u.Id == obj.Pprovince).Name;
                ViewBag.Pdistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.Pdistrict).Name;
                ViewBag.Pvillage = _db.Villages.FirstOrDefault(u => u.Id == obj.Pvillage).Name;
                if (obj.Tprovince != null)
                {
                    ViewBag.Tprovince = _db.Provinces.FirstOrDefault(u => u.Id == obj.Tprovince).Name;
                    ViewBag.Tdistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.Tdistrict).Name;
                    ViewBag.Tvillage = _db.Villages.FirstOrDefault(u => u.Id == obj.Tvillage).Name;
                }
                ViewBag.CitizenDistrict = _db.Districts.FirstOrDefault(u => u.Id == obj.CitizenDistrict).Name;
                ViewBag.OfficeProvince = _db.Provinces.FirstOrDefault(u => u.Id == obj.OfficeProvince).Name;
                ViewBag.OfficeVisit = _db.Offices.FirstOrDefault(u => u.Id == obj.OfficeVisit).Name;
                ViewBag.CategoryName = _db.DrivingCategories.FirstOrDefault(u => u.Id == obj.Category).Name;
                ViewBag.CategorySymbol = _db.DrivingCategories.FirstOrDefault(u => u.Id == obj.Category).Symbol;
                return View(obj);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        [ActionName("Approval")]
        [ValidateAntiForgeryToken]
        public IActionResult ApprovalPost(int id)
        {
            LicenseRegistration obj = _db.LicenseRegistrations.OrderBy(u => u.Id).LastOrDefault(u => u.Id == id);
            ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == obj.ApplicantId);
            TwilioClient.Init(_twilioOptions.AccountSid, _twilioOptions.AuthToken);
            try
            {
                var message = MessageResource.Create(
                    body: "Your License Registration have been successfully approved. Your written examination is in " + obj.RegisterDate.AddDays(3).ToShortDateString(),
                    from: new Twilio.Types.PhoneNumber(_twilioOptions.PhoneNumber),
                    to: new Twilio.Types.PhoneNumber("+977" + user.PhoneNumber)
                    );
            }
            catch (Exception ex)
            {

            }

            _emailSender.SendEmailAsync(user.Email, "License Registration Approved", "<p>Your License Registration have been successfully approved. Your written examination is in " + obj.RegisterDate.AddDays(3).ToShortDateString() + "<p>");
            obj.Approved = true;
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Disapproval(int id)
        {
            LicenseRegistration obj = _db.LicenseRegistrations.OrderBy(u => u.Id).LastOrDefault(u => u.Id == id);
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult WrittenList()
        {
            List<LicenseRegistration> userList = _module.LicenseRegistration.GetAll(includeProperties: "DrivingCategory").Where(u=>u.WrittenResult==null && u.Approved==true).OrderByDescending(u => u.Id).DistinctBy(u => u.ApplicantId).ToList();
            return View(userList);
        }

        public IActionResult TrailList()
        {
            List<LicenseRegistration> userList = _module.LicenseRegistration.GetAll(includeProperties: "DrivingCategory").Where(u=>u.WrittenResult=="pass"&&u.TrailResult==null).OrderByDescending(u => u.Id).DistinctBy(u => u.ApplicantId).ToList();
            return View(userList);
        }
    }
}

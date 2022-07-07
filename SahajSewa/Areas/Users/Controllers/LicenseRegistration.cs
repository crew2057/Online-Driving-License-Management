using Microsoft.AspNetCore.Mvc;

namespace SahajSewa.Areas.Users.Controllers
{
    public class LicenseRegistration : Controller
    {
        //Get
        public IActionResult Upsert()
        {
            return View();
        }
    }
}

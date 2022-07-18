using Microsoft.AspNetCore.Mvc;

namespace SahajSewa.Areas.Users.Controllers
{
    public class LicenseController : Controller
    {
        public IActionResult Upsert(int? id)
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}

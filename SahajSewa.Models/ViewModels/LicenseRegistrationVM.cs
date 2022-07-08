using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models.ViewModels
{
    public class LicenseRegistrationVM
    {
        public LicenseRegistration LicenseRegistration { get; set; }
        public IEnumerable<SelectListItem> ProvinceList { get; set; }
        public IEnumerable<SelectListItem> DistrictList { get; set; }
        public IEnumerable<SelectListItem> VillageList { get; set; }
        public IEnumerable<SelectListItem> OfficeList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}

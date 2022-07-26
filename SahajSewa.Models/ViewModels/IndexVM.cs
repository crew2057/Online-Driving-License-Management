using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models.ViewModels
{
    public class IndexVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public LicenseRegistration LicenseRegistration { get; set; }
        public License License { get; set; }
        public Passport Passport { get; set; }
    }
}

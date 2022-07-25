using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models.ViewModels
{
    public class LicenseVM
    {
        public License License { get; set; }
        public List<CheckBoxVM> AvailableCategory { get; set; }
    }
}

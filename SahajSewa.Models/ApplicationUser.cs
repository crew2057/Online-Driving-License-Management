using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class ApplicationUser :IdentityUser
    {

        public List<UserCategory> UserCategory { get; set; }
        
        [Display(Name = "License Availability")]
        public int? LicenseId { get; set; }
        [ForeignKey("LicenseId")]
        public License? License { get; set; }
        [Display(Name = "Passport Availability")]
        public int? PassportId { get; set; }
        [ForeignKey("PassportId")]
        public Passport? Passport { get; set; }

    }
}

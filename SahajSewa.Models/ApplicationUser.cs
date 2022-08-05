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


    }
}

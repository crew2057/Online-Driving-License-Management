using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class UserCategory
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int CategoryId { get; set; }
        public DrivingCategory DrivingCategory { get; set; }
    }
}

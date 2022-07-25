using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class DrivingCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public string Name { get; set; }
        public List<UserCategory> UserCategory { get; set; }
        
    }
}

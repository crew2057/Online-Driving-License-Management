using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class Office
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Province")]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }
    }
}

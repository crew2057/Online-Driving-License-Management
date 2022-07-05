using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        [Display(Name="Zone")]
        public int ZoneId { get; set; }
        [ForeignKey("ZoneId")]
        public Zone Zone { get; set; }
    }
}

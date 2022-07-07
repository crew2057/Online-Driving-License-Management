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
        public string Name{ get; set; }
        [Display(Name="Province")]
        public int ProvinceDid { get; set; }
        [ForeignKey("ProvinceDid")]
        public Province Province{ get; set; }
    }
}

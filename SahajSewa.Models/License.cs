using SahajSewa.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "License No")]
        public string LicenseNo { get; set; }
        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province? Province { get; set; }
        [Display(Name = "Issue Office")]
        public int OfficeId { get; set; }
        [ForeignKey("OfficeId")]
        public Office? Office { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Display(Name = "Issue Date"), DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } = DateTime.Today;
        [Display(Name = "Expiry Date"), DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; } = DateTime.Today;
        [Display(Name = "License Photo")]
        public string? LicensePhoto { get; set; }
        public string? ApplicantId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class Passport
    {
        [Key]
        public int Id { get; set; }
        public string? ApplicantId { get; set; }
        [Display(Name ="Passport No")]
        public string PassportNo { get; set; }
        [Display(Name ="Personal No")]
        public int PersonalNo { get; set; }
        [Display(Name = "Issue Date"), DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } = DateTime.Today;
        [Display(Name = "Expiry Date"), DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; } = DateTime.Today;
        [Display(Name ="Issue Office")]
        public string IssueOffice { get; set; }
        [Display(Name ="Passport Photo")]
        public string? PassportPhoto { get; set; }
    }
}

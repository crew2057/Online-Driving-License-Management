using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahajSewa.Models
{
    public class LicenseRegistration
    {

        #region General Details
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Display(Name = "Middle Name")]
        public string? Mname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "Date of Birth"), DataType(DataType.Date)]

        public DateTime DOB { get; set; } = DateTime.Today;
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Pnumber { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string Bgroup { get; set; }
        [Required]
        [Display(Name = "Guardian's Name")]
        public string Gname { get; set; }
        #endregion

        #region Address Details
        //permanent
        [Required]
        [Display(Name = "Province")]
        public int Pprovince { get; set; }
        [ForeignKey("Pprovince")]
        public Province? Province { get; set; }
        [Required]
        [Display(Name = "District")]
        public int Pdistrict { get; set; }
        [ForeignKey("Pdistrict")]
        public District? District { get; set; }
        [Required]
        [Display(Name = "Village / Municipality")]
        public int Pvillage { get; set; }
        [ForeignKey("Pvillage")]
        public Village? Village { get; set; }
        [Required]
        [Display(Name = "Ward No.")]
        public int Pward { get; set; }
        [Required]
        [Display(Name = "Tole")]
        public string Ptole { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        //temporary
        [Required]
        [Display(Name = "Province")]
        public int Tprovince { get; set; }
        [Required]
        [Display(Name = "District")]
        public int Tdistrict { get; set; }
        [Required]
        [Display(Name = "Village / Municipality")]
        public int Tvillage { get; set; }
        [Required]
        [Display(Name = "Ward No.")]
        public int Tward { get; set; }
        [Required]
        [Display(Name = "Tole")]
        public string Ttole { get; set; }
        #endregion

        #region Citizenship Details
        [Required]
        [Display(Name = "Citizenship No")]
        public string CitizenNo { get; set; }
        [Required]
        [Display(Name = "Citizenship Issue District")]
        public int CitizenDistrict { get; set; }

        [Required]
        [Display(Name = "Citizenship Issue Date"), DataType(DataType.Date)]
        public DateTime CitizenDate { get; set; } = DateTime.Today;
        #endregion

        #region Exam Details
        [Display(Name = "Registration Date"), DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; } = DateTime.Today;
        [Required]
        [Display(Name = "Office Province")]
        public int OfficeProvince { get; set; }
        [Required]
        [Display(Name = "Visit Office")]
        public int OfficeVisit { get; set; }
        [ForeignKey("OfficeVisit")]
        public Office? Office { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int Category { get; set; }
        [ForeignKey("Category")]
        public DrivingCategory? DrivingCategory { get; set; }

        #endregion

        #region Documents Upload
        [Display(Name = "Applicant's Photo")]
        public string? Photo { get; set; }

        [Display(Name = "Citizenship Front")]
        public string? CitizenFront { get; set; }

        [Display(Name = "Citizenship Back")]
        public string? CitizenBack { get; set; }

        [Display(Name = "Signature")]
        public string? Signature { get; set; }

        [Display(Name = "Thumb Impression")]
        public string? Thumb { get; set; }
        #endregion

        #region Backend Details
        [Display(Name = "Trail Count")]
        public int? TrailCount { get; set; }
        [Display(Name = "Written Result")]
        public string? WrittenResult { get; set; }
        [Display(Name = "Trail Result")]
        public string? TrailResult { get; set; }
        public string? SessionId { get; set; }
        public string? OldSessionId { get; set; }
        public string? PaymentIntentId { get; set; }
        #endregion
    }
}

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
        public string Mname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Pnumber { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string Bgroup { get; set; }
        [Required]
        [Display(Name = "Guardian Name")]
        public string Gname { get; set; }
        #endregion

        #region Address Details
        //permanent
        [Required]
        [Display(Name = "Province")]
        public int Pprovince { get; set; }
        [ForeignKey("Pprovince")]
        public Province Province { get; set; }
        [Required]
        [Display(Name = "District")]
        public int Pdistrict { get; set; }
        [ForeignKey("Pdistrict")]
        public District District { get; set; }
        [Required]
        [Display(Name = "Village / Municipality")]
        public int Pvillage { get; set; }
        [ForeignKey("Pvillage")]
        public Village Village { get; set; }
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
        public string Tprovince { get; set; }
        [Required]
        [Display(Name = "District")]
        public string Tdistrict { get; set; }
        [Required]
        [Display(Name = "Village / Municipality")]
        public string Tvillage { get; set; }
        [Required]
        [Display(Name = "Ward No.")]
        public int Tward { get; set; }
        [Required]
        [Display(Name = "Tole")]
        public string Ttole { get; set; }
        #endregion

        #region Citizenship Details
        [Required]
        [Display(Name ="Citizenship No")]
        public string CitizenNo { get; set; }
        [Required]
        [Display(Name ="Citizenship Issue District")]
        public string CitizenDistrict { get; set; }

        [Required]
        [Display(Name ="Citizenship Issue Date")]
        public DateTime CitizenDate { get; set; }
        #endregion

        #region Exam Details
        [Required]
        [Display(Name ="Office Province")]
        public string OfficeProvince { get; set; }
        [Required]
        [Display(Name ="Office")]
        public int OfficeVisit { get; set; }
        [ForeignKey("OfficeVisit")]
        public Office Office { get; set; }
        [Required]
        [Display(Name ="Category")]
        public int Category { get; set; }
        [ForeignKey("Category")]
        public DrivingCategory DrivingCategory { get; set; }

        #endregion

        #region Documents Upload
        [Required]
        [Display(Name ="Applicant's Photo")]
        public string Photo { get; set; }
        [Required]
        [Display(Name ="Citizenship Front Photo")]
        public string CitizenFront { get; set; }
        [Required]
        [Display(Name ="Citizenship Back Photo")]
        public string CitizenBack { get; set; }
        [Required]
        [Display(Name ="Signature Photo")]
        public string Signature { get; set; }
        [Required]
        [Display(Name ="Thumb Impression")]
        public string Thumb { get; set; }
        #endregion

        #region Backend Details
        [Display(Name ="Trail Count")]
        public int TrailCount { get; set; }
        [Display(Name ="Written Result")]
        public string WrittenResult { get; set; }
        [Display(Name ="Trail Result")]
        public string TrailResult { get; set; }
        [Display(Name ="License Availability")]
        public int LicenseId { get; set; }
        [ForeignKey("LicenseId")]
        public License License { get; set; }
        [Display(Name ="Passport Availability")]
        public int PassportId { get; set; }
        [ForeignKey("PassportId")]
        public Passport Passport { get; set; }
        #endregion
    }
}

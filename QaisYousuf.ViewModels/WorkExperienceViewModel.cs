using System;
using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class WorkExperienceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }


        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Location")]
        public string CompanyLocation { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Job Description")]
        public string JobDesicription { get; set; }

        [Required]
        [Display(Name = "Company log Url")]
        [DataType(DataType.Url)]
        public string LogoUrl { get; set; }


        [Required]
        [Display(Name = "Job Sub Description")]
        public string JobSubDescription { get; set; }
    }
}

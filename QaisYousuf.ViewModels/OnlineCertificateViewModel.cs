using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class OnlineCertificateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "Program Name")]
        public string ProgramName { get; set; }

        [Required]
        [Display(Name = "Course Location")]
        public string CourseLocation { get; set; }

        [Required]
        [Display(Name = "Icon Url")]
        [DataType(DataType.Url)]
        public string IconUrl { get; set; }

        [Required]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Required]
        [Display(Name = "Button Text")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name = "Button Url")]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }
    }
}

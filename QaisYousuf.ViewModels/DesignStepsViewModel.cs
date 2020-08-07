using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class DesignStepsViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [Display(Name ="Step Icon")]
        [DataType(DataType.Url)]
        public string StepIcon { get; set; }

        [Required]
        [Display(Name ="Step title")]
        public string StepTitle { get; set; }

        [Required]
        [Display(Name ="Step Content")]
        public string StepContent { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string StepImageUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class UIBannerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [Display(Name ="Button Url")]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}

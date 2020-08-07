using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class PortfolioBannerViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [Display(Name = "Background Image")]
        public string BackgroundImage { get; set; }

        [Required]
        [Display(Name = "Slider Image Url")]
        public string SliderImagesUrl { get; set; }

        [Required]
        [Display(Name = "Button Url")]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name = "Button Text")]
        public string ButtonText { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class HomeBannerViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Background Img Url")]
        public string BackgroundImage { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Slider Img Url")]
        public string SliderImagesUrl { get; set; }

        [Display(Name ="Button Url")]
        [Required]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

    }
}

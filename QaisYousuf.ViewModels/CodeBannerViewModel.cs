using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class CodeBannerViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [Display(Name ="Button Url")]
        public string ButtonUrl { get; set; }

        [Display(Name ="Button Text")]
        [Required]
        public string ButtonText { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; }

    }
}

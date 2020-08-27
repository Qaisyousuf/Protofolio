using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class PlatformDesignViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }


        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

      

        [Required]
        [Display(Name ="Content Image")]
        [DataType(DataType.Url)]
        public string ImageContent { get; set; }

    }
}

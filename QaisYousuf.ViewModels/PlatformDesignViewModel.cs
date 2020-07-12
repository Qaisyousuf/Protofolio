using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class PlatformDesignViewModel
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
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

        [Display(Name ="Model Title")]
        [Required]
        public string ModalTitle { get; set; }

        [Required]
        [Display(Name ="Modal Content")]
        public string ModalsContent { get; set; }

    }
}

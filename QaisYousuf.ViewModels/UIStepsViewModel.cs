using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class UIStepsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; }

    }
}

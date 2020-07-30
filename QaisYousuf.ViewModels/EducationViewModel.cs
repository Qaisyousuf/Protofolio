using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class EducationViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class InterestViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "Main Title")]
        public string Subtitle { get; set; }

        [Display(Name ="Icon Url")]
        [DataType(DataType.Url)]
        [Required]
        public string UrlIcon { get; set; }
    }
}

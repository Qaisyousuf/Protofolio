using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class UIUXToolsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Icon Url")]
        [DataType(DataType.Url)]
        public string IconUrl { get; set; }

        [Required]
        [Display(Name ="Program Title")]
        public string ProgramTitle { get; set; }

        [Display(Name ="Image Url")]
        [Required]
        public string ImageUrl { get; set; }
    }
}

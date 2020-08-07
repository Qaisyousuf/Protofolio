using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class WebProgrammingToolsViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [DataType(DataType.Url)]
        [Display(Name ="Image Url")]
        [Required]
        public string ImageUrl { get; set; }


        [DataType(DataType.Url)]
        [Display(Name ="Icon Url")]
        [Required]
        public string IconUrl { get; set; }

        [Display(Name ="Web Programming Title")]
        [Required]
        public string ProgramTitle { get; set; }
    }
}

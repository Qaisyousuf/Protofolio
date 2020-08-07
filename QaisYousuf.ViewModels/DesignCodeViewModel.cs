using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class DesignCodeViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}

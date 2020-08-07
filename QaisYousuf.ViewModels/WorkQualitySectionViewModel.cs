using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class WorkQualitySectionViewModel:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name ="Modal Title")]
        public string ModalTitle { get; set; }

        [Required]
        [Display(Name ="Modal Content")]
        public string ModalsContent { get; set; }
    }
}

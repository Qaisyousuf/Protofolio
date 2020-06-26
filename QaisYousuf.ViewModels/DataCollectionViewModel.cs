using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QaisYousuf.ViewModels
{
    public class DataCollectionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ProjectCountingViewModel:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Display(Name ="Sub Title")]
        [Required]
        public string SubTitle { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Counting Number")]
        [DataType(DataType.PhoneNumber)]
        public string CountingNumber { get; set; }

    }
}

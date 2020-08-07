using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ContactMattersViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        
        [Display(Name ="Map API")]
        public string MapApi { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        public string ImageUrl { get; set; }
    }
}

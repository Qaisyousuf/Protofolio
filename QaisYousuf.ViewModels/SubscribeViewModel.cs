using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class SubscribeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Button Text")]
        public string Buttontext { get; set; }

        [Required]
        [Display(Name ="Modal Message")]
        public string ModalMessage { get; set; }


        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}

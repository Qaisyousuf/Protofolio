using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ContactFormViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Moible { get; set; }

        public string Message { get; set; }

        public string IpAddress { get; set; }
    }
}

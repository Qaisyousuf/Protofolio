using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class ContactDetailsViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Home Addres")]
        public string HomeAddress { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Moible { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Sale Email")]
        public string SaleEamil { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name ="Working Time")]
        public DateTime WorkingTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Working Date")]
        public DateTime WorkingData { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Working Date of Week")]
        public DateTime WorkingTimeofWeek { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Working Time Of Week")]
        public DateTime WrokingDateOfWeek { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.ViewModels
{
    public class EditUserViewModel
    {

        public EditUserViewModel()
        {
            Roles = new List<CheckBoxViewModel>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "confirm password doesn't match")]
        public string ConfirmPassword { get; set; }

        public List<CheckBoxViewModel> Roles { get; set; }
    }
}

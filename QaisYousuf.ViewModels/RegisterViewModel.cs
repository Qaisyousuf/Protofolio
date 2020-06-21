using System.ComponentModel.DataAnnotations;


namespace QaisYousuf.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Confirm password doesn't match")]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
              
    }
}

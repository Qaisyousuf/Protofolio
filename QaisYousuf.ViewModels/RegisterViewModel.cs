using System.ComponentModel.DataAnnotations;



namespace QaisYousuf.ViewModels
{
    
    public class RegisterViewModel
    {
        
        [Display(Name ="User Name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Must be between 6 and 10 characters", MinimumLength = 6)]
        public string Password { get; set; }

       
        [Required]
        [Compare("Password",ErrorMessage ="Confirm password not match")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
              
    }
}

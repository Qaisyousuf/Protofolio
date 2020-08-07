using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

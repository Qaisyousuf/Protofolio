using QaisYousuf.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.ViewModels
{
    public class RolesViewModel
    {
        public RolesViewModel()
        {
            Users = new List<UserModel>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name="Authorization name")]
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}

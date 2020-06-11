using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaisYousuf.Models
{
    [Table("Users")]
    public class UserModel:EntityBase
    {
        public UserModel()
        {
            Roles = new List<RoleModel>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<RoleModel> Roles { get; set; }
        
    }
}

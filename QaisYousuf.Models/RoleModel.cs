using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace QaisYousuf.Models
{
    [Table("Roles")]
    public class RoleModel:EntityBase
    {
        public RoleModel()
        {
            Users = new List<UserModel>();
        }
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }

    }
}

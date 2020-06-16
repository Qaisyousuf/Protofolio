using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using QaisYousuf.Models;

namespace QaisYousuf.Data.FluentAPI
{
   public class UserMapping:EntityTypeConfiguration<UserModel>
    {
        public UserMapping()
        {
            HasMany(r => r.Roles)
                .WithMany(u => u.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("RoleId");
                    cs.ToTable("UserRoles");
                });

        }
    }
}

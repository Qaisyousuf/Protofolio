using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaisYousuf.Data.Interfaces
{
    public interface IUserRepository:IRepository<UserModel>
    {
        UserModel GetUserWithRoles(string username);

        bool UserExists(string username);

        string GetPassword(string username);

        IEnumerable<RoleModel> GetRoles();

        IEnumerable<UserModel> GetUserWithRoles();

        IEnumerable<RoleModel> GetRolesById(int[] ids);
    }
}

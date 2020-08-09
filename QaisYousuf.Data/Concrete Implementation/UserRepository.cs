using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace QaisYousuf.Data.Concrete_Implementation
{
    public class UserRepository:Repository<UserModel>,IUserRepository
    {
        public UserRepository(UIContext context):base(context)
        {

        }

        public void AddUserToRoles(int? userId, int[] roleIds,UIContext context)
        {
            var user = context.Users.Where(x => x.Id == userId).SingleOrDefault();

            var rolesFromdb = GetRolesById(roleIds);

            foreach (var role in rolesFromdb)
            {
                user.Roles.Add(role);
            }
        }

        public string GetPassword(string username)
        {
            return _context.Users.Where(x => x.UserName == username).Select(x => x.PasswordHash).SingleOrDefault();
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public IEnumerable<RoleModel> GetRolesById(int[] ids)
        {
            return _context.Roles.Where(x => ids.Contains(x.Id)).ToList();
        }

        public UserModel GetUserWithRoles(string username)
        {
            var user = _context.Users.Include(u => u.Roles).SingleOrDefault();

            UserModel currentUser = new UserModel
            {
                Id = user.Id,
                UserName=user.UserName,
                Email=user.Email,
                Roles=user.Roles,
            };
            return currentUser;

        }

        public IEnumerable<UserModel> GetUserWithRoles()
        {
            var users = _context.Users.Include(u => u.Roles);

            List<UserModel> userWithRoles = new List<UserModel>();

            foreach (var user in users)
            {
                userWithRoles.Add(new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = user.Roles
                });
            }
            return userWithRoles;
        }

        public bool UserExists(string username)
        {
            return _context.Users.Any(x => x.UserName == username);
        }
    }
}

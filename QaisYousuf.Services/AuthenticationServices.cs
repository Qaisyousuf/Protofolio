using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;

namespace QaisYousuf.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUnitOfWork uow;

        public AuthenticationServices(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddUserToRoles(int? userId, int[] roleIds)
        {
            uow.UserRepository.AddUserToRoles(userId, roleIds,uow.Context);
            uow.Commit();
        }

        public string GenerateHash(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public UserModel Login(string username, string password)
        {
            var user = uow.UserRepository.GetUserWithRoles(username);
            if (user == null)
                return null;
            bool hashValidet = VerifyHash(user.UserName, password);

            if(hashValidet)
            {
                return user;

            }
            return null;
        }

        public bool Register(string email, string username, string password,out int? userId)
        {
            var userExists = uow.UserRepository.UserExists(username);
            if(!userExists)
            {
                string hashedPassword = GenerateHash(password);

                UserModel user = new UserModel
                {
                    Email = email,
                    UserName=username,
                    PasswordHash=hashedPassword,
                };
                uow.UserRepository.Add(user);
                uow.Commit();
                userId = user.Id;
                return true;
            }
            userId = null;
            return false;
        }

        public bool VerifyHash(string username, string password)
        {
            var hashedPassword = uow.UserRepository.GetPassword(username);
            bool hashedMatched = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            return hashedMatched;
        }
    }
}

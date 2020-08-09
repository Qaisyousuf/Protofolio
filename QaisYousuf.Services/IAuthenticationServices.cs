using QaisYousuf.Models;

namespace QaisYousuf.Services
{
    public interface IAuthenticationServices
    {
        bool Register(string email, string username, string password,out int? userId);

        UserModel Login(string username, string password);

        bool VerifyHash(string username, string password);

        string GenerateHash(string password);

        void AddUserToRoles(int? userId, int[] roleIds);
    }
}

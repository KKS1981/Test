using Model.Account;
using System;
using System.Security.Principal;
namespace AccountService
{
    public interface IAccountService
    {
        System.Threading.Tasks.Task<string> GenerateAuthKey(string username, string password, string deviceID = "");
        System.Security.Principal.IIdentity GetIIdentityByAuthkey(string authKey);
        bool IsInRole(string role, IIdentity identity);

        UserModel CreateUser(string userName, string passWord);
        UserModel CreateUser(string userName, string passWord, string role);

        UserModel CreateUser(string userName, string passWord, params string[] roles);

        bool IsInRole(string[] roles, IIdentity _identity);

        string GenerateAuthKeyByUserName(string username, string deviceId = "");
    }
}

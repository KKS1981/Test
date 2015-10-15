using AccountService;
using Model;
using Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class LoginService : SchoolService.ILoginService
    {
        private readonly IAccountService _accountService;
        public LoginService(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<string> GetAuthKey(LoginModel model)
        {
            var authkey = await _accountService.GenerateAuthKey(model.UserName, model.Password);
            return authkey;
        }

        public UserModel Register(RegisterModel model)
        {
            var userModel = _accountService.CreateUser(model.UserName, model.Password);
            return userModel;
        }

    }
}

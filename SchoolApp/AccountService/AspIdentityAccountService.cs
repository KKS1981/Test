using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccountService
{
    public class AspIdentityAccountService : AccountService.IAccountService
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _manager;
        private UserStore<ApplicationUser> _store;
        public AspIdentityAccountService(ApplicationDbContext context)
        {
            _context = context;
            _store = new UserStore<ApplicationUser>(_context);
            _manager = new UserManager<ApplicationUser>(_store);
        }

        public async Task<string> GenerateAuthKey(string username, string password, string deviceID = "")
        {
            var user = await _manager.FindAsync(username, password);
            if (user != null)
            {
                var key = Guid.NewGuid().ToString().Replace("-", "");
                user.Keys.Add(new UserKey { DeviceID = deviceID, ExpiredOn = DateTime.UtcNow.AddYears(1), Key = key, User = user, Id = Guid.NewGuid().ToString() });
                _context.SaveChanges();
                return key;
            }
            throw new Exception("Invalid username or password");
        }

        public IIdentity GetIIdentityByAuthkey(string authKey)
        {
            var user = _context.Users.SingleOrDefault(x => x.Keys.Any(y => y.Key == authKey));
            ClaimsIdentity _identity;
            if (user != null)
            {
                _identity = _manager.CreateIdentity<ApplicationUser, string>(user, DefaultAuthenticationTypes.ExternalBearer);
            }
            else
                _identity = new ClaimsIdentity();
            return _identity;
        }

        public bool IsInRole(string role, IIdentity identity)
        {
            if (identity != null && identity.IsAuthenticated)
            {
                var userID = identity.GetUserId();
                var userrole = _context.Roles.SingleOrDefault(x => x.Users.Any(y => y.UserId == userID) && x.Name == role);
                if (userrole != null)
                {
                    return true;
                }
            }
            return false;
        }


        public UserModel CreateUser(string userName, string passWord)
        {

            var user = new ApplicationUser();
            user.UserName = userName;
            var result = _manager.Create(user, passWord);
            if (!result.Succeeded)
                throw new Exception("An Error Occurred to Register User");
            user = _manager.FindByName(userName);
            return new UserModel { UserID = user.Id, UserName = user.UserName };
        }


        public UserModel CreateUser(string userName, string passWord, string role)
        {
            var user = new ApplicationUser();
            user.UserName = userName;
            var result = _manager.Create(user, passWord);
            user = _manager.FindByName(userName);
            _manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Role, role));
            if (!result.Succeeded)
                throw new Exception("An Error Occurred to Register User");
            return new UserModel { UserID = user.Id, UserName = user.UserName };
        }
        public UserModel CreateUser(string userName, string passWord, params string[] roles)
        {
            var user = new ApplicationUser();
            user.UserName = userName;
            var result = _manager.Create(user, passWord);
            user = _manager.FindByName(userName);
            foreach (var role in roles)
                _manager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Role, role));
            if (!result.Succeeded)
                throw new Exception("An Error Occurred to Register User");
            return new UserModel { UserID = user.Id, UserName = user.UserName };
        }


        public bool IsInRole(string[] roles, IIdentity identity)
        {
            if (identity != null && identity.IsAuthenticated)
            {
                var userID = identity.GetUserId();
                var userrole = _context.Roles.FirstOrDefault(x => x.Users.Any(y => y.UserId == userID) && roles.Contains(x.Name));
                if (userrole != null)
                {
                    return true;
                }
            }
            return false;
        }


        public string GenerateAuthKeyByUserName(string username, string deviceID = "")
        {
            var user = _manager.FindByName<ApplicationUser, string>(username);
            if (user != null)
            {
                var key = Guid.NewGuid().ToString().Replace("-", "");
                user.Keys.Add(new UserKey { DeviceID = deviceID, ExpiredOn = DateTime.UtcNow.AddYears(1), Key = key, User = user, Id = Guid.NewGuid().ToString() });
                _context.SaveChanges();
                return key;
            }
            throw new Exception("Invalid username");
        }


        public bool IsUserExist(string userName)
        {
            var user = _manager.FindByName(userName);
            if (user != null)
                return true;
            return false;
        }


        public bool IsEmailExist(string email)
        {
            var user = _manager.FindByEmail(email);
            if (user != null)
                return true;
            return false;
        }


        public UserModel CreateUser(string userName, string email, string passWord, string role)
        {
            var user = new ApplicationUser();
            user.Email = email;
            user.UserName = userName;
            var result = _manager.Create(user, passWord);
            if (!result.Succeeded)
                throw new Exception("An Error Occurred to Register User");
            user = _manager.FindByName(userName);
            return new UserModel { UserID = user.Id, UserName = user.UserName };
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Project2.Models.Account;
using Project2.Models.UserData;
using Project2.Models.Users;
using Project2.Services.Interfaces;

namespace Project2.Services
{
    public class AccountService: IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<UserData?> GetUser()
        {
            if (_httpContextAccessor.HttpContext?.User == null)
            {
                return null; 
            }
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return null;
            }
            UserData userData = UserDataFactory.CreateFromUser(user,user.Role.ToString());
            return userData;
        }

        public async Task LoginOutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool>LoginUser(UserLogin user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);
            return result.Succeeded;
        }

        public async  Task<bool> ModifyPassword(UserPassword password)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.ChangePasswordAsync(user, password.OldPassword, password.NewPassword);
            if (!result.Succeeded)
            {
                return false;
            }
            await _signInManager.RefreshSignInAsync(user);
            return true;

        }

        public async Task<bool> ModifyUser(UserData userData)
        {
            if (_httpContextAccessor.HttpContext?.User == null)
            {
                return false;
            }
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return false;
            }
            UserUpdater userUpdater = new UserUpdater();
            userUpdater.Visit(user,userData);
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;

        }
    }
}

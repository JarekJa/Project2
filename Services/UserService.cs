using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project2.DataBase;
using Project2.Models.Enums;
using Project2.Models.ManageUser;
using Project2.Models.Users;
using Project2.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Project2.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accountService;
        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IAccountService accountService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _accountService = accountService;
        }
        public async Task<IEnumerable<UserList>> GetUserList()
        {
            if (_httpContextAccessor.HttpContext.User!=null)
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                if (user != null)
                {
                    var role = await _userManager.GetRolesAsync(user);
                    if (role.Contains("Administrator")|| role.Contains("Boss"))
                    {
                        var users = _userManager.Users.Select(u => new UserList
                        {
                            id = u.Id,
                            Login = u.UserName,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Role = u.Role,
                        }).ToList();

                        return users;
                    }
                    else if (role.Contains("HRManager"))
                    {
                        var users = _userManager.Users
                            .OfType<Employee>()
                            .Where(e => e.AddedByHRManagerId == user.Id)
                            .Select(u => new UserList
                            {
                                id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Role = u.Role,

                            }).ToList();

                        return users;
                    }
                    else if (role.Contains("ProjectManager"))
                    {
                        var users = _userManager.Users
                            .OfType<ProjectEmployee>()
                            .Select(u => new UserList
                            {
                                id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Role = u.Role,
                            }).ToList();

                        return users;
                    }
                }
            }
            return new List<UserList>();
        }
        public async Task<bool> DeleteUser(string id)
        {
            User? user = await _userManager.FindByIdAsync(id);

            if (user!=null)
            {
                if (_httpContextAccessor.HttpContext.User!=null) {
                    var userLog = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                    if (userLog != null) {
                        if (userLog.Id == id)
                        {
                            await _accountService.LoginOutUser();
                        }
                    }
                }
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

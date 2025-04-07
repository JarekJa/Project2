using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2.Models.Account;
using Project2.Models.UserData;
using Project2.Models.Users;
using Project2.Services.Interfaces;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                if (await _accountService.LoginUser(userLogin))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userLogin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LoginOutUser();
            return RedirectToAction("Login", "Account");
        }
        [Authorize]
        public async Task<IActionResult> MyAccount()
        {
            UserData? user = await _accountService.GetUser();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login", "Account");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            UserData? user = await _accountService.GetUser();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Login", "Account");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Manage(UserData model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await _accountService.ModifyUser(model)) 
            {
                return RedirectToAction("MyAccount", "Account");

            }
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserPassword password)
        {
            if (!ModelState.IsValid)
            {
                return View(password);
            }
            if (password != null)
            {
                if( await _accountService.ModifyPassword(password))
                {
                    return RedirectToAction("MyAccount", "Account");
                }
            }
            return View(password);

        }
    }
}

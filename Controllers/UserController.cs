using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2.Models.ManageUser;
using Project2.Services.Interfaces;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    
    public  class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize(Roles = "Administrator, HRmanager, ProjectManager,Boss")]
        public async Task<IActionResult> UsersList()
        {
            return View(await _userService.GetUserList());
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction("UsersList", "User");
        }
        [HttpGet]
        [Authorize(Roles = "Administrator, HRmanager,Boss")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserCreationModel userCreationModel)
        {


            return View();
        }
    }
}

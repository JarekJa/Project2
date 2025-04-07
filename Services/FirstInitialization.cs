using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.Models.Enums;
using Project2.Models.Users;
using Project2.Services.Interfaces;

namespace Project2.Services
{
    public class FirstInitialization: IFirstInitialization
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public FirstInitialization(UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task InitializeAdminAsync()
        {
            bool hasAdmin = (await _userManager.GetUsersInRoleAsync("Administrator")).Any();
            if (!hasAdmin)
            {
                Admin admin = new Admin() { FirstName = "admin" ,LastName="admin",UserName="admin", Role = RoleEnum.Administrator, CreatedDate= DateTime.Today };

                var createResult = await _userManager.CreateAsync(admin, "admin");
                if (createResult.Succeeded)
                {
                   await _userManager.AddToRoleAsync(admin, RoleEnum.Administrator.ToString());
                }
            }
        }

        public async Task InitializeBossAsync()
        {
            bool hasBoss = (await _userManager.GetUsersInRoleAsync("Boss")).Any();
            if (!hasBoss)
            {
                Boss boss = new Boss() { FirstName = "boss", LastName = "boss", UserName = "boss", Role = RoleEnum.Boss, CreatedDate = DateTime.Today };

                var createResult = await _userManager.CreateAsync(boss, "boss");
                if (createResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(boss, RoleEnum.Boss.ToString());
                }
            }
        }

        public async Task InitializeRolesAsync()
        {
            string[] roleNames = Enum.GetNames(typeof(RoleEnum));

            foreach (var roleName in roleNames)
            {
                if (roleName!= "Unknown")
                {
                    var roleExist = await _roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        }
    }
}

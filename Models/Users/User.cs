using Microsoft.AspNetCore.Identity;
using Project2.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public RoleEnum Role { get; set; }
        public bool PasswordChanged { get; set; } = false;

        public User()
        {
                
        }

    }
}

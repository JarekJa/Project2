using Project2.Models.Enums;
using Project2.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models.UserData
{
    public class UserData
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login {  get; set; }

        public RoleEnum Role { get; set; }
        public UserData()
        {
                
        }


    }
}

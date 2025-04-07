using Project2.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models.ManageUser
{
    public class UserList
    {
        [Required]
        public string id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
        public UserList()
        {
            
        }
    }
}

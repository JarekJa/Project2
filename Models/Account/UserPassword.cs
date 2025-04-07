using System.ComponentModel.DataAnnotations;

namespace Project2.Models.Account
{
    public class UserPassword
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}

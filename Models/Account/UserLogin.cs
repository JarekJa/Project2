using System.ComponentModel.DataAnnotations;

namespace Project2.Models.Account
{
    public class UserLogin
    {
        [Required]

        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

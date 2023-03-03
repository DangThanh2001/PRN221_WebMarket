using System.ComponentModel.DataAnnotations;

namespace ObjectModel
{
    public class UserDTO
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
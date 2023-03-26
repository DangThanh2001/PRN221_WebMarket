using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Gender { get; set; } = true;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime? DayCreated { get; set; } = DateTime.Now;
        public DateTime? DayUpdated { get; set; }= DateTime.Now;
        public string? AvatarImage { get; set; }
        // 0 = admin, 1 = mod, 2 = normal
        public int Type { get; set; } = 2;
        // so du tai khoan
        public Double Balance { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set;} = false;
    }
}

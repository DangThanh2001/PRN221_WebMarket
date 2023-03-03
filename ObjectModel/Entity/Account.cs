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
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime DayCreated { get; set; }
        public DateTime DayUpdated { get; set; }
        public string AvatarImage { get; set; }
        // 0 = admin, 1 = mod, 2 = normal
        public int Type { get; set; }
        // so du tai khoan
        public Double Balance { get; set; } 
        public bool IsActive { get; set; }
        public bool IsDelete { get; set;}
    }
}

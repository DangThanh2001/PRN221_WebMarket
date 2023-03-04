using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
    }
}

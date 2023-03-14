using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Card
    {
        [Key]
        public int UserID { get; set; }
        public string ProductIdAndQuantity { get; set; } //8182@2;2323@2;2434@2;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public Double Price { get; set; }
        // con thua lai
        public int Quantity { get; set;}
        public String Image { get; set; }
        public int CompanyId { get; set; }
        // so luong tren 1 don vi mua
        public int QuantityPerUnit { get; set;}
        public DateTime ImportDay { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}

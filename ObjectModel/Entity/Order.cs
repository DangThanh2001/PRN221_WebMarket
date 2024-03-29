﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        // nguoi tao hoa don
        public int AccountId { get; set; }
        public DateTime DayCreated { get; set; }
        public DateTime? ModifiedDate { get; set;}
        // so luong san pham trong don hang
        public int Quantity { get; set; }
        // 0 = process, 1 = , 2 = Vanchuye, 3= done 
        public DateTime DaySend { get; set; }
        public DateTime DayRecive { get; set; }
        public int Success { get; set; }
        // tong tien 
        public double TotalPrice { get; set; }
        //tong tien da thanh toan
        public double Payed { get; set; }
        // ngay thanh toan het
        public DateTime DayPayedDone { get; set; }
        public bool IsDelete { get; set; } = false;
        public string Address { get; set; }
        public bool Shipped { get; set; } = false;
    }
}

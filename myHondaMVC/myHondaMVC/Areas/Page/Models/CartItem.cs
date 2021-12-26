using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myHondaMVC.Areas.Page.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public string tensp { get; set; }
        public double? dongia { get; set; }
        public int soluong { get; set; }
        public string img { get; set; }
        public int ThanhTien
        {
            get
            {
                return soluong * Convert.ToInt32(dongia);
            }
        }
    }
}
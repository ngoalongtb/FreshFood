using FreshFood.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFood.AppCode
{
    public class Session
    {
        public static User LoginAccount { get; set; }
        public static User TaiKhoanQLDV { get; set; }
        public static SellOrder Cart = new SellOrder();

    }
}

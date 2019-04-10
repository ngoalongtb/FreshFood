using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFood.AppCode
{
    public class ReportItem
    {
        public string TenSanPham { get; set; }
        public string Gia { get; set; }
        public String SoLuong { get; set; }
        public int STT { get; set; }
        public string ThanhTien { get; set; }

        public ReportItem() { }

        public ReportItem(int stt, String tenSanPham, string gia, string soLuong, string thanhTien)
        {
            this.STT = stt;
            this.TenSanPham = tenSanPham;
            this.Gia = gia;
            this.SoLuong = soLuong;
            this.ThanhTien = thanhTien;
        }
    }
}

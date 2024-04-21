using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Chitiethoadonban
    {
        public int Id { get; set; }
        public int? SanPhamId { get; set; }
        public int? HoaDonBanId { get; set; }
        public int? GiaBan { get; set; }
        public int? SoLuong { get; set; }
        public int? ThanhTien { get; set; }

        public virtual Hoadonban? HoaDonBan { get; set; }
        public virtual Sanpham? SanPham { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Hoadonban
    {
        public Hoadonban()
        {
            Chitiethoadonbans = new HashSet<Chitiethoadonban>();
        }

        public int Id { get; set; }
        public int? KhachHangId { get; set; }
        public string? HoTen { get; set; }
        public int? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? GhiChu { get; set; }
        public string? TrangThaiDonHang { get; set; }
        public bool? TrangThaiThanhToan { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public int? TongTien { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Khachhang? KhachHang { get; set; }
        public virtual ICollection<Chitiethoadonban> Chitiethoadonbans { get; set; }
    }
}

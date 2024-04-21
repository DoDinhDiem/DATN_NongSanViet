using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Tintuc
    {
        public int Id { get; set; }
        public int? LoaiTinId { get; set; }
        public int? NguoiVietId { get; set; }
        public string TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public string? DuongDanAnh { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Loaitintuc? LoaiTin { get; set; }
        public virtual Nhanvien? NguoiViet { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Loainongsan
    {
        public Loainongsan()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int Id { get; set; }
        public string? TenLoai { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}

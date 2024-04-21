using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Quyen
    {
        public Quyen()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public int Id { get; set; }
        public string? TenQuyen { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}

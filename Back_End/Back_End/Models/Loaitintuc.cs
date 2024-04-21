using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Loaitintuc
    {
        public Loaitintuc()
        {
            Tintucs = new HashSet<Tintuc>();
        }

        public int Id { get; set; }
        public string? TenLoaiTin { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}

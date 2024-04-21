using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Slide
    {
        public int Id { get; set; }
        public string? DuongDanAnh { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

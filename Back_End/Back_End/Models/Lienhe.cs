using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Lienhe
    {
        public int Id { get; set; }
        public string? BanDo { get; set; }
        public string? DiaChi { get; set; }
        public int? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

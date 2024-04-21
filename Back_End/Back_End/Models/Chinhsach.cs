using System;
using System.Collections.Generic;

namespace Back_End.Models
{
    public partial class Chinhsach
    {
        public int Id { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

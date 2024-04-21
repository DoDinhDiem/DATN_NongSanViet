using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        private doantotnghiepContext _context;
        public HoaDonNhapController(doantotnghiepContext context)
        {
            _context = context;
        }

        [Route("GetAll_HoaDonNhap")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var query = _context.Hoadonnhaps.Select(x => new
                {
                    id = x.Id,
                    tenNhanVien = x.NhanVien.HoTen,
                    tenNhaCungCap = x.NhaCungCap.TenNhaCungCap,
                    tongTien = x.TongTien,
                    trangThaiThanhToan = x.TrangThaiThanhToan
                }).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_HoaDonNhap/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var query = _context.Hoadonnhaps.Where(x => x.Id == id).Select(x => new
                {
                    id = x.Id,
                    nhanVienId = x.NhanVienId,
                    nhaCungCapId = x.NhaCungCapId,
                    tenNhanVien = x.NhanVien.HoTen,
                    tenNhaCungCap = x.NhaCungCap.TenNhaCungCap,
                    tongTien = x.TongTien,
                    trangThaiThanhToan = x.TrangThaiThanhToan,
                    createdAt = x.CreatedAt,
                    chiTietHoaDon = _context.Chitiethoadonnhaps
                       .Where(u => u.HoaDonNhapId == x.Id)
                       .Select(s => new
                       {
                           sanPhamId = _context.Sanphams
                               .Where(sp => sp.Id == s.SanPhamId)
                               .Select(sp => sp.TenSanPham)
                               .FirstOrDefault(),
                           soLuong = s.SoLuong,
                           giaNhap = s.GiaNhap,
                           thanhTien = s.ThanhTien
                       }).ToList()
                }).FirstOrDefault();

                return Ok(query);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_HoaDonNhap")]
        [HttpPost]
        public IActionResult Create([FromBody] Hoadonnhap model)
        {
            try
            {
                _context.Hoadonnhaps.Add(model);
                var newHoaDon = new List<Chitiethoadonnhap>();
                foreach (var invoice in model.Chitiethoadonnhaps)
                {
                    var ct = new Chitiethoadonnhap()
                    {
                        HoaDonNhapId = model.Id,
                        SanPhamId = invoice.SanPhamId,
                        SoLuong = invoice.SoLuong,
                        GiaNhap = invoice.GiaNhap,
                        ThanhTien = invoice.ThanhTien
                    };

                    var SanPham = _context.Sanphams.Find(ct.SanPhamId);

                    if (SanPham != null)
                    {
                        SanPham.SoLuong += ct.SoLuong;
                        _context.Sanphams.Update(SanPham);
                    }

                    newHoaDon.Add(ct);
                }
                int? totalAmount = newHoaDon.Sum(ct => ct.ThanhTien);
                model.TongTien = totalAmount;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Thêm hóa đơn thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_HoaDonNhap")]
        [HttpPut]
        public IActionResult Update([FromBody] Hoadonnhap model)
        {
            try
            {
                var query = _context.Hoadonnhaps.Find(model.Id);
                query.NhaCungCapId = model.NhaCungCapId;
                query.TrangThaiThanhToan = model.TrangThaiThanhToan;
                _context.SaveChanges();

                return Ok(new
                {
                    message = "Cập nhập hóa đơn thành công"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

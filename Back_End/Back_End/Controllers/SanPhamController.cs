using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private doantotnghiepContext _context;
        public static IWebHostEnvironment _environment;

        public SanPhamController(doantotnghiepContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Route("GetAll_SanPham")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var query = _context.Sanphams.Select(x => new
                {
                    id = x.Id,
                    tenLoai = x.Loai.TenLoai,
                    tenSanPham = x.TenSanPham,
                    moTa = x.MoTa,
                    giaBan = x.GiaBan,
                    khuyenMai = x.KhuyenMai,
                    soLuong = x.SoLuong,
                    donViTinh = x.DonViTinh,
                    TrangThai = x.TrangThai,
                    imageMain = x.Anhsanphams.Where(a => a.TrangThai == true).Select(a => a.DuongDanAnh).FirstOrDefault(),
                }).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_SanPham/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var query = _context.Sanphams
                                    .Where(x => x.Id == id)
                                    .Select(x => new
                                    {
                                        id = x.Id,
                                        loaiId = x.LoaiId,
                                        tenLoai = x.Loai.TenLoai,
                                        tenSanPham = x.TenSanPham,
                                        moTa = x.MoTa,
                                        giaBan = x.GiaBan,
                                        khuyenMai = x.KhuyenMai,
                                        donViTinh = x.DonViTinh,
                                        imageMain = x.Anhsanphams.Where(a => a.SanPhamId == id && a.TrangThai == true).Select(a => a.DuongDanAnh).FirstOrDefault(),
                                        imageList = x.Anhsanphams.Where(a => a.SanPhamId == id && a.TrangThai != true).Select(a => new { image = a.DuongDanAnh }).ToList()

                                    }).FirstOrDefault();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_SanPham")]
        [HttpPost]
        public IActionResult Create([FromBody] Sanpham model)
        {
            try
            {
                model.SoLuong = 0;
                _context.Sanphams.Add(model);
                var images = new List<Anhsanpham>();
                foreach (var imgs in model.Anhsanphams)
                {
                    var img = new Anhsanpham
                    {
                        SanPhamId = model.Id,
                        DuongDanAnh = imgs.DuongDanAnh,
                        TrangThai = imgs.TrangThai
                    };
                    images.Add(img);
                }

                _context.SaveChanges();

                return Ok(new
                {
                    message = "Thêm sản phẩm thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_SanPham")]
        [HttpPut]
        public IActionResult Update([FromBody] Sanpham model)
        {
            try
            {
                var query = _context.Sanphams.Find(model.Id);

                query.LoaiId = model.LoaiId;
                query.TenSanPham = model.TenSanPham;
                query.MoTa = model.MoTa;
                query.GiaBan = model.GiaBan;
                query.KhuyenMai = model.KhuyenMai;

                _context.Anhsanphams.RemoveRange(_context.Anhsanphams.Where(a => a.SanPhamId == model.Id));
                foreach (var imgs in model.Anhsanphams)
                {
                    var img = new Anhsanpham
                    {
                        SanPhamId = model.Id,
                        DuongDanAnh = imgs.DuongDanAnh,
                        TrangThai = imgs.TrangThai
                    };
                    query.Anhsanphams.Add(img);
                }

                _context.SaveChanges();

                return Ok(new
                {
                    message = "Sửa sản phẩm thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("TrangThai/{id}")]
        [HttpPut]
        public IActionResult TrangThai(int id)
        {
            try
            {
                var query = _context.Sanphams.Find(id);
                query.TrangThai = !query.TrangThai;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa sản phẩm thành công"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete_SanPham/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var query = _context.Sanphams.Find(id);
                _context.Sanphams.Remove(query);
                _context.SaveChanges();

                return Ok(new
                {
                    message = "Xóa sản phẩm thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Upload_Image")]
        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            try
            {
                List<string> fileNames = new List<string>();

                foreach (var file in files)
                {
                    if (file == null || file.Length == 0)
                    {
                        continue;
                    }

                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads", "Products");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string filePath = Path.Combine(uploadsFolder, file.FileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    fileNames.Add(file.FileName);
                }

                return Ok(fileNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

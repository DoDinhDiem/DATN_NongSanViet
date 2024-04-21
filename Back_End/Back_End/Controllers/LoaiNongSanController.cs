using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiNongSanController : ControllerBase
    {
        private doantotnghiepContext _context;
        public static IWebHostEnvironment _environment;
        public LoaiNongSanController(doantotnghiepContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Route("GetAll_Loai")]
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                var query = _context.Loainongsans.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAll_Loai_TrangThai")]
        [HttpGet]
        public IActionResult GetALLTrangThai()
        {
            try
            {
                var query = _context.Loainongsans.Where(x => x.TrangThai == true).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_Loai/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var query = _context.Loainongsans.Find(id);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_Loai")]
        [HttpPost]
        public IActionResult Create([FromBody] Loainongsan model)
        {
            try
            {
                _context.Loainongsans.Add(model);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Thêm loại nông sản thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_Loai")]
        [HttpPut]
        public IActionResult Update([FromBody] Loainongsan model)
        {
            try
            {
                var query = _context.Loainongsans.Find(model.Id);
                query.TenLoai = model.TenLoai;
                query.TrangThai = model.TrangThai;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa loại nông sản thành công"
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
                var query = _context.Loainongsans.Find(id);
                query.TrangThai = !query.TrangThai;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa loại nông sản thành công"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete_Loai/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var query = _context.Loainongsans.Find(id);
                _context.Loainongsans.Remove(query);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Xóa loại nông sản thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Upload_Image")]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads", "Loainongsans");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string filePath = Path.Combine(uploadsFolder, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok(new { fileName = file.FileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

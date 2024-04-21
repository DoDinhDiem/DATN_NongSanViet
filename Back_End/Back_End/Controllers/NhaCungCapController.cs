using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private doantotnghiepContext _context;
        public NhaCungCapController(doantotnghiepContext context)
        {
            _context = context;
        }

        [Route("GetAll_NhaCungCap")]
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                var query = _context.Nhacungcaps.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_NhaCungCap/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var query = _context.Nhacungcaps.Find(id);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_NhaCungCap")]
        [HttpPost]
        public IActionResult Create([FromBody] Nhacungcap model)
        {
            try
            {
                _context.Nhacungcaps.Add(model);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Thêm nhà cung cấp thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_NhaCungCap")]
        [HttpPut]
        public IActionResult Update([FromBody] Nhacungcap model)
        {
            try
            {
                var query = _context.Nhacungcaps.Find(model.Id);
                query.TenNhaCungCap = model.TenNhaCungCap;
                query.Email = model.Email;
                query.SoDienThoai = model.SoDienThoai;
                query.DiaChi = model.DiaChi;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa nhà cung cấp thành công"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete_NhaCungCap/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var query = _context.Nhacungcaps.Find(id);
                _context.Nhacungcaps.Remove(query);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Xóa nhà cung cấp thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

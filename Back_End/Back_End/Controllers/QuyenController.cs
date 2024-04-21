using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuyenController : ControllerBase
    {
        private doantotnghiepContext _context;
        public QuyenController(doantotnghiepContext context)
        {
            _context = context;
        }

        [Route("GetAll_Quyen")]
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                var query = _context.Quyens.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_Quyen/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var query = _context.Quyens.Find(id);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_Quyen")]
        [HttpPost]
        public IActionResult Create([FromBody] Quyen model)
        {
            try
            {
                _context.Quyens.Add(model);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Thêm quyền thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_Quyen")]
        [HttpPut]
        public IActionResult Update([FromBody] Quyen model)
        {
            try
            {
                var query = _context.Quyens.Find(model.Id);
                query.TenQuyen = model.TenQuyen;
                query.TrangThai = model.TrangThai;
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa quyền thành công"
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
                var query = _context.Quyens.Find(id);
                query.TrangThai = !query.TrangThai;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa quyền thành công"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete_Quyen/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var query = _context.Quyens.Find(id);
                _context.Quyens.Remove(query);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Xóa quyền thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

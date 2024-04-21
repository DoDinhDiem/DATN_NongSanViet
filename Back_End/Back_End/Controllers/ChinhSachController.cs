using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChinhSachController : ControllerBase
    {
        private readonly doantotnghiepContext _context;
        public ChinhSachController(doantotnghiepContext context)
        {
            _context = context;
        }

        [Route("GetAll_ChinhSach")]
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                var query = _context.Chinhsaches.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_ChinhSach/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var query = _context.Chinhsaches.Find(id);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_ChinhSach")]
        [HttpPost]
        public IActionResult Create([FromBody] Chinhsach model)
        {
            try
            {
                _context.Chinhsaches.Add(model);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Thêm chính sách thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_ChinhSach")]
        [HttpPut]
        public IActionResult Update([FromBody] Chinhsach model)
        {
            try
            {
                var query = _context.Chinhsaches.Find(model.Id);
                query.TieuDe = model.TieuDe;
                query.NoiDung = model.NoiDung;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa chính sách thành công"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete_ChinhSach/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var query = _context.Chinhsaches.Find(id);
                _context.Chinhsaches.Remove(query);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Xóa chính sách thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

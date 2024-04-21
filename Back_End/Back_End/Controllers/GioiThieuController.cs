using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioiThieuController : ControllerBase
    {
        private doantotnghiepContext _context;
        public GioiThieuController(doantotnghiepContext context)
        {
            _context = context;
        }

        [Route("GetAll_GioiThieu")]
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                var query = _context.Gioithieus.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_GioiThieu/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var query = _context.Gioithieus.Find(id);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_GioiThieu")]
        [HttpPost]
        public IActionResult Create([FromBody] Gioithieu model)
        {
            try
            {
                _context.Gioithieus.Add(model);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Thêm giới thiệu thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_GioiThieu")]
        [HttpPut]
        public IActionResult Update([FromBody] Gioithieu model)
        {
            try
            {
                var query = _context.Gioithieus.Find(model.Id);
                query.GioiThieu1 = model.GioiThieu1;

                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sửa giới thiệu thành công"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete_GioiThieu/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var query = _context.Gioithieus.Find(id);
                _context.Gioithieus.Remove(query);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Xóa giới thiệu thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiTinTucController : ControllerBase
    {
        private readonly doantotnghiepContext _context;
        public LoaiTinTucController(doantotnghiepContext context)
        {
            _context = context;
        }

        [Route("GetAll_LoaiTinTuc")]
        [HttpGet]
        public IActionResult GetAllLoaiTinTuc()
        {
            try
            {
                var query = _context.Loaitintucs
                                          .Select(x => new
                                          {
                                              id = x.Id,
                                              tenLoaiTin = x.TenLoaiTin,
                                              trangThai = x.TrangThai
                                          }).ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAll_TrangThai_LoaiTinTuc")]
        [HttpGet]
        public IActionResult GetAllTrangThaiLoaiTinTuc()
        {
            try
            {
                var query = _context.Loaitintucs
                                          .Where(x => x.TrangThai == true)
                                          .Select(x => new
                                          {
                                              id = x.Id,
                                              tenLoaiTin = x.TenLoaiTin,
                                              trangThai = x.TrangThai
                                          }).ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById_LoaiTinTuc/{id}")]
        [HttpGet]
        public IActionResult GetByIdLoaiTinTuc(int id)
        {
            try
            {
                var query = _context.Loaitintucs.Find(id);
                if (query == null)
                {
                    return BadRequest(new { message = "Loại tin tức không tồn tại!" });
                }
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_LoaiTinTuc")]
        [HttpPost]
        public IActionResult CreateLoaiTinTuc([FromBody] Loaitintuc model)
        {
            try
            {
                _context.Loaitintucs.Add(model);
                _context.SaveChanges();

                return Ok(new { message = "Thêm loại tin tức thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update_LoaiTinTuc")]
        [HttpPut]
        public IActionResult UpdateLoaiTinTuc([FromBody] Loaitintuc model)
        {
            try
            {
                var query = _context.Loaitintucs.Find(model.Id);

                if (query == null)
                {
                    return BadRequest(new { message = "Loại tin tức không tồn tại!" });
                }

                query.TenLoaiTin = model.TenLoaiTin;
                query.TrangThai = model.TrangThai;

                _context.SaveChanges();

                return Ok(new { message = "Cập nhập loại tin tức thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("TrangThai/{id}")]
        [HttpPut]
        public IActionResult UpdateTrangThai(int id)
        {
            try
            {
                var query = _context.Loaitintucs.Find(id);
                if (query == null)
                {
                    return BadRequest(new { message = "Loại tin tức không tồn tại!" });
                }

                query.TrangThai = !query.TrangThai;
                _context.SaveChanges();

                return Ok(new { message = "Cập nhập trạng thái loại tin tức thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete_LoaiTinTuc/{id}")]
        [HttpDelete]
        public IActionResult DeleteLoaiTinTuc(int id)
        {
            try
            {
                var query = _context.Loaitintucs.Find(id);

                if (query == null)
                {
                    return BadRequest(new { message = "Loại tin tức không tồn tại!" });
                }

                _context.Loaitintucs.Remove(query);
                _context.SaveChanges();

                return Ok(new { message = "Xóa loại tin tức thành công!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

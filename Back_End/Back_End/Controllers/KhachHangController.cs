using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private doantotnghiepContext _context;

        public KhachHangController(doantotnghiepContext context)
        {
            _context = context;
        }

        [Route("GetAll_KhacHang")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var query = _context.Khachhangs.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Back_End.Models;
using Back_End.Models.Dto;
using Back_End.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private doantotnghiepContext _context;
        private AppSettings _appSettings;


        public ClientController(doantotnghiepContext context, IOptions<AppSettings> appSetting)
        {
            _context = context;
            _appSettings = appSetting.Value;
        }

        [Route("All_Loai")]
        [HttpGet]
        public IActionResult GetAllLoai()
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

        [Route("All_Slide")]
        [HttpGet]
        public IActionResult GetAllSlide()
        {
            try
            {
                var query = _context.Slides.Where(x => x.TrangThai == true).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSanPhamGiamGia")]
        [HttpGet]
        public IActionResult GetSanPhamGiamGia()
        {
            try
            {
                var query = _context.Sanphams
                                    .OrderByDescending(p => p.KhuyenMai)
                                    .Where(p => p.Loai.TrangThai == true && p.KhuyenMai > 0 && p.TrangThai == true)
                                    .Select(x => new
                                    {
                                        id = x.Id,
                                        tenSanPham = x.TenSanPham,
                                        giaBan = x.GiaBan,
                                        khuyenMai = x.KhuyenMai,
                                        image = x.Anhsanphams.Where(p => p.TrangThai == true).Select(p => p.DuongDanAnh).FirstOrDefault(),
                                    }).Take(15).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSanPhamMoi")]
        [HttpGet]
        public IActionResult GetSanPhamMoi()
        {
            try
            {
                var query = _context.Sanphams
                                    .OrderByDescending(p => p.CreatedAt)
                                    .Where(p => p.Loai.TrangThai == true && p.TrangThai == true)
                                    .Select(x => new
                                    {
                                        id = x.Id,
                                        tenSanPham = x.TenSanPham,
                                        giaBan = x.GiaBan,
                                        KhuyenMai = x.KhuyenMai,
                                        image = x.Anhsanphams.Where(p => p.TrangThai == true).Select(p => p.DuongDanAnh).FirstOrDefault(),
                                    }).Take(15).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSanPhamBanChay")]
        [HttpGet]
        public IActionResult GetSanPhamBanChay()
        {
            try
            {
                var query = (from x in _context.Sanphams
                             join ct in _context.Chitiethoadonbans on x.Id equals ct.SanPhamId
                             where x.Loai.TrangThai == true && x.TrangThai == true
                             group x by new
                             {
                                 x.Id,
                                 x.TenSanPham,
                                 x.LoaiId,
                                 x.GiaBan,
                                 x.KhuyenMai,
                             } into g
                             select new
                             {
                                 id = g.Key.Id,
                                 tenSanPham = g.Key.TenSanPham,
                                 giaBan = g.Key.GiaBan,
                                 khuyenMai = g.Key.KhuyenMai,
                                 image = _context.Anhsanphams.Where(p => p.TrangThai == true).Select(p => p.DuongDanAnh).FirstOrDefault(),
                                 total = g.Count()
                             }).Take(15).ToList();

                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetChiTiet/{id}")]
        [HttpGet]
        public IActionResult GetChiTiet(int id)
        {
            try
            {
                var query = _context.Sanphams
                                   .Where(p => p.Id == id)
                                   .Select(x => new
                                   {
                                       id = x.Id,
                                       loaiId = x.LoaiId,
                                       tenLoai = x.Loai.TenLoai,
                                       tenSanPham = x.TenSanPham,
                                       moTa = x.MoTa,
                                       giaBan = x.GiaBan,
                                       khuyenMai = x.KhuyenMai,
                                       imageList = x.Anhsanphams.Select(p => new { image = p.DuongDanAnh }).ToList(),
                                   }).FirstOrDefault();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSanPhamToLoai")]
        [HttpGet]
        public IActionResult GetSanPhamToLoai([FromQuery] int id, string? sapXep)
        {
            try
            {
                var query = _context.Sanphams.Where(p => p.Loai.TrangThai == true && p.LoaiId == id && p.TrangThai == true);

                if (!string.IsNullOrEmpty(sapXep))
                {
                    switch (sapXep.ToLower())
                    {
                        case "pricemin":
                            query = query.OrderBy(p => p.GiaBan);
                            break;
                        case "pricemax":
                            query = query.OrderByDescending(p => p.GiaBan);
                            break;
                        case "name":
                            query = query.OrderBy(p => p.TenSanPham);
                            break;
                        case "date":
                            query = query.OrderByDescending(p => p.CreatedAt);
                            break;
                        default:
                            break;
                    }
                }

                var totalItems = query.Count();
                var loaisp = _context.Loainongsans.Where(x => x.Id == id).Select(x => x.TenLoai).FirstOrDefault();
                var sanPham = query.Select(x => new
                {
                    id = x.Id,
                    tenLoai = x.Loai.TenLoai,
                    tenSanPham = x.TenSanPham,
                    giaBan = x.GiaBan,
                    khuyenMai = x.KhuyenMai,
                    image = x.Anhsanphams.Where(p => p.TrangThai == true).Select(p => p.DuongDanAnh).FirstOrDefault(),
                }).ToList();

                var response = new
                {
                    TotalItems = totalItems,
                    category = loaisp,
                    Items = sanPham
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTuongTu/{id}/{loaiid}")]
        [HttpGet]
        public IActionResult GetTuongTu(int id, int loaiid)
        {
            try
            {
                var query = _context.Sanphams
                                   .OrderByDescending(p => p.CreatedAt)
                                   .Where(p => p.Id != id && p.LoaiId == loaiid && p.TrangThai == true)
                                   .Select(x => new
                                   {
                                       id = x.Id,
                                       tenSanPham = x.TenSanPham,
                                       giaBan = x.GiaBan,
                                       khuyenMai = x.KhuyenMai,
                                       image = x.Anhsanphams.Where(p => p.TrangThai == true).Select(p => p.DuongDanAnh).FirstOrDefault(),
                                   }).Take(10).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetLoaiTinTuc")]
        [HttpGet]
        public IActionResult GetLoaiTinTuc()
        {
            try
            {
                var query = _context.Loaitintucs.Where(x => x.TrangThai == true).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTinTuc")]
        [HttpGet]
        public IActionResult GetTinTuc()
        {
            try
            {
                var query = _context.Tintucs
                                    .Where(x => x.LoaiTin.TrangThai == true)
                                    .Select(x => new
                                    {
                                        id = x.Id,
                                        name = x.NguoiViet.HoTen,
                                        tieuDe = x.TieuDe,
                                        noiDung = x.NoiDung,
                                        image = x.DuongDanAnh,
                                        ngayTao = x.CreatedAt
                                    }).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("GetTinTucByLoai/{id}")]
        [HttpGet]
        public IActionResult GetTinTuc(int id)
        {
            try
            {
                var query = _context.Tintucs
                                    .Where(x => x.LoaiTinId == id && x.LoaiTin.TrangThai == true)
                                    .Select(x => new
                                    {
                                        id = x.Id,
                                        tenLoai = x.LoaiTin.TenLoaiTin,
                                        name = x.NguoiViet.HoTen,
                                        tieuDe = x.TieuDe,
                                        noiDung = x.NoiDung,
                                        image = x.DuongDanAnh,
                                        ngayTao = x.CreatedAt
                                    }).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetTinTucById/{id}")]
        [HttpGet]
        public IActionResult GetTinTucById(int id)
        {
            try
            {
                var query = _context.Tintucs.Where(p => p.Id == id)
                                    .Select(x => new
                                    {
                                        id = x.Id,
                                        name = x.NguoiViet.HoTen,
                                        tieuDe = x.TieuDe,
                                        noiDung = x.NoiDung,
                                        image = x.DuongDanAnh,
                                        ngayTao = x.CreatedAt
                                    }).FirstOrDefault();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetLienHe")]
        [HttpGet]
        public IActionResult GetLienHe()
        {
            try
            {
                var query = _context.Lienhes.FirstOrDefault();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetGioiThieu")]
        [HttpGet]
        public IActionResult GetGioiThieu()
        {
            try
            {
                var query = _context.Gioithieus.FirstOrDefault();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetChinhSach")]
        [HttpGet]
        public IActionResult GetChinhSach()
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

        [Route("GetSearchSanPham")]
        [HttpGet]
        public IActionResult GetSearchSanPham([FromQuery] string key)
        {
            try
            {
                var query = _context.Sanphams.AsQueryable();

                query = query.Where(l => l.TenSanPham.Contains(key));

                var totalItems = query.Count();
                var sanPham = query.Select(x => new
                {
                    id = x.Id,
                    tenSanPham = x.TenSanPham,
                    giaBan = x.GiaBan,
                    khuyenMai = x.KhuyenMai,
                    image = x.Anhsanphams.Where(p => p.TrangThai == true).Select(p => p.DuongDanAnh).FirstOrDefault(),
                }).ToList();

                var response = new
                {
                    TotalItems = totalItems,
                    Items = sanPham
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetKhacHangById/{id}")]
        [HttpGet]
        public IActionResult GetKhacHangById(int id)
        {
            try
            {
                var query = _context.Khachhangs.Find(id);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create_HoaDonBan")]
        [HttpPost]
        public IActionResult CreateHoaDonBan([FromBody] Hoadonban model)
        {
            try
            {
                _context.Hoadonbans.Add(model);

                var newHoaDon = new List<Chitiethoadonban>();

                foreach (var cthd in model.Chitiethoadonbans)
                {
                    var sanPham = _context.Sanphams.Find(cthd.SanPhamId);

                    if (sanPham.SoLuong < cthd.SoLuong || sanPham.SoLuong < 1)
                    {
                        return BadRequest(new { message = "Số lượng sản phẩm không đủ " });
                    }

                    sanPham.SoLuong -= cthd.SoLuong;

                    var ct = new Chitiethoadonban
                    {
                        HoaDonBanId = model.Id,
                        SanPhamId = cthd.SanPhamId,
                        SoLuong = cthd.SoLuong,
                        GiaBan = cthd.GiaBan,
                        ThanhTien = cthd.ThanhTien
                    };
                    newHoaDon.Add(ct);

                }
                int? totalAmount = newHoaDon.Sum(ct => ct.ThanhTien);
                model.TongTien = totalAmount;

                _context.SaveChanges();
                return Ok(new
                {

                    id = model.Id,
                    message = "Đặt hàng thành công!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Tài khoản
        [Route("Signin")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] Khachhang model)
        {
            if (model == null)
                return BadRequest();

            var query = _context.Khachhangs
                .FirstOrDefault(x => x.UserName == model.UserName);

            if (query == null)
                return NotFound(new { Message = "Tài khoản không tồn tại! Vui lòng nhập lại." });

            if (query.PassWord != model.PassWord)
            {
                return BadRequest(new { Message = "Mật khẩu không đúng! Vui lòng nhập lại." });
            }

            query.Token = CreateJwt(query);
            var newAccessToken = query.Token;
            var newRefreshToken = CreateRefreshToken();
            query.RefreshToken = newRefreshToken;
            query.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            _context.SaveChanges();

            return Ok(new TokenApiDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Khachhang model)
        {
            if (model == null)
                return BadRequest();

            // check email
            if (await CheckUserNameExistAsync(model.UserName))
                return BadRequest(new { Message = "UserName đã tồn tại!" });

            if (await CheckEmailExistAsync(model.UserName))
                return BadRequest(new { Message = "Email đã tồn tại!" });

            var passMessage = CheckPasswordStrength(model.PassWord);
            if (!string.IsNullOrEmpty(passMessage))
                return BadRequest(new { message = passMessage.ToString() });

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Status = 200,
                message = "Đăng ký thành công!"
            });
        }

        [Route("RefreshToken")]
        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] TokenApiDto tokenApiDto)
        {
            if (tokenApiDto is null)
                return BadRequest("Yêu cầu của khách hàng không hợp lệ");
            string accessToken = tokenApiDto.AccessToken;
            string refreshToken = tokenApiDto.RefreshToken;
            var principal = GetPrincipleFromExpiredToken(accessToken);
            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _context.Khachhangs.FirstOrDefaultAsync(u => u.Email == email);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest("Yêu cầu không hợp lệ");
            var newAccessToken = CreateJwt(user);
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();
            return Ok(new TokenApiDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            });
        }



        private Task<bool> CheckUserNameExistAsync(string? userName)
            => _context.Khachhangs.AnyAsync(x => x.UserName == userName);
        private Task<bool> CheckEmailExistAsync(string? email)
        => _context.Khachhangs.AnyAsync(x => x.Email == email);

        private static string CheckPasswordStrength(string pass)
        {
            StringBuilder sb = new StringBuilder();
            if (pass.Length < 9)
                sb.Append("Độ dài mật khẩu tối thiểu phải là 8" + Environment.NewLine);
            if (!(Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[0-9]")))
                sb.Append("Mật khẩu phải chứa cả chữ và số" + Environment.NewLine);
            if (!Regex.IsMatch(pass, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                sb.Append("Mật khẩu phải chứa ký tự đặc biệt" + Environment.NewLine);
            return sb.ToString();
        }

        private string CreateJwt(Khachhang model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var identity = new ClaimsIdentity(new Claim[]
            {
                        new Claim("UserName", model.UserName),
                        new Claim(ClaimTypes.Name, model.HoTen),
                        new Claim("id", model.Id.ToString()),
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var tokenInUser = _context.Khachhangs
                .Any(a => a.RefreshToken == refreshToken);
            if (tokenInUser)
            {
                return CreateRefreshToken();
            }
            return refreshToken;
        }

        private ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Đây là mã thông báo không hợp lệ");
            return principal;

        }
    }
}

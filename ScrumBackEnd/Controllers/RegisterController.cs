using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumBackEnd.Dto;
using ScrumBackEnd.Model;

namespace ScrumBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly CampaignContext _context;
        public RegisterController(CampaignContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Đảm bảo context không bị null
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<RegisterDto>> GetAll()
        {
            var result = (from rc in _context.RegisterCampains
                          join c in _context.Campaigns on rc.CampaignId equals c.Id
                          select new RegisterDto
                          {
                              Id = rc.Id,
                              NameCampaign = c.Name,
                              Name = rc.Name,
                              SDT = rc.SDT,
                              Email = rc.Email,
                              Address = rc.Address,
                              SDTParent = rc.SDTParent,
                              Reason = rc.Reason,
                              Aim = rc.Aim,
                              MSSV = rc.MSSV,
                              Status = rc.Status,

                          }).ToList();
            return result;
        }
        // GET: api/<UserController>
        [HttpPost("RegisterCampaign")]
        public async Task<IActionResult> RegisterCampaign([FromBody] RegisterCampaignDto dto)
        {
            var data = _context.RegisterCampains.Where(x => x.MSSV == dto.MSSV).FirstOrDefault();
            if (data != null)
            {
                LoginRespone res = new()
                {
                    Success = false,
                    Data = "Tài khoản đã đăng ký 1 chiến dịch",
                    Role = "Student"
                };
                return Ok(res);
            }
            var datauser = _context.Users.Where(x => x.UserName == dto.MSSV).FirstOrDefault();
            if (datauser == null)
            {
                LoginRespone res = new()
                {
                    Success = false,
                    Data = "Tài khoản không có trong Hệ Thống",
                    Role = "Student"
                };
                return Ok(res);
            }
            RegisterCampain newregister = new()
            {
                Id = new Guid(),
                CampaignId = dto.CampaignId,
                Name = dto.Name,
                SDT = dto.SDT,
                Email = dto.Email,
                Address = dto.Address,
                SDTParent = dto.SDTParent,
                Reason = dto.Reason,
                Aim = dto.Aim,
                MSSV = dto.MSSV,
                CreatedAt = DateTime.Now,
                Status = "Wait",
            };
            _context.RegisterCampains.Add(newregister);
            await _context.SaveChangesAsync();
            LoginRespone ress = new()
            {
                Success = true,
                Data = "Đăng ký thành công",
                Role = "Student"
            };
            return Ok(ress);
        }
        // GET: api/<UserController>
        [HttpGet("ApproveRegister")]
        public async Task<IActionResult> ApproveRegister([FromQuery] string mssv)
        {
            var data = _context.RegisterCampains.Where(x => x.MSSV == mssv).FirstOrDefault();
            if (data == null)
            {
                LoginRespone ress = new()
                {
                    Success = false,
                    Data = "Không có sinh viên với MSSV này",
                    Role = "Community"
                };
                return Ok(ress);
            }
            data.Status = "Accepted";
            _context.RegisterCampains.Update(data);
            await _context.SaveChangesAsync();

            LoginRespone res = new()
            {
                Success = true,
                Data = "Duyệt sinh viên thành công",
                Role = "Community"
            };
            return Ok(res);
        }
        // GET: api/<UserController>
        [HttpGet("RejectRegister")]
        public async Task<IActionResult> RejectRegister([FromQuery] string mssv)
        {
            var data = _context.RegisterCampains.Where(x => x.MSSV == mssv).FirstOrDefault();
            if (data == null)
            {
                LoginRespone ress = new()
                {
                    Success = false,
                    Data = "Không có sinh viên với MSSV này",
                    Role = "Community"
                };
                return Ok(ress);
            }
            data.Status = "Rejected";
            _context.RegisterCampains.Update(data);
            await _context.SaveChangesAsync();

            LoginRespone res = new()
            {
                Success = true,
                Data = "Từ chối sinh viên thành công",
                Role = "Community"
            };
            return Ok(res);
        }
        // GET: api/<UserController>
        [HttpGet("GetRegisterAwait")]
        public async Task<IEnumerable<RegisterDto>> GetRegisterAwait()
        {
            var result = (from rc in _context.RegisterCampains
                            where rc.Status == "Wait"
                          join c in _context.Campaigns on rc.CampaignId equals c.Id
                          select new RegisterDto
                          {
                              Id = rc.Id,
                              NameCampaign = c.Name,
                              Name = rc.Name,
                              SDT = rc.SDT,
                              Email = rc.Email,
                              Address = rc.Address,
                              SDTParent = rc.SDTParent,
                              Reason = rc.Reason,
                              Aim = rc.Aim,
                              MSSV = rc.MSSV,
                              Status = rc.Status,
                          })
                          .OrderBy(r => r.NameCampaign)
                          .ToList();
            return result;
        }
        // GET: api/<UserController>
        [HttpGet("GetRegisterAccept")]
        public async Task<IEnumerable<RegisterDto>> GetRegisterAccept()
        {
            var result = (from rc in _context.RegisterCampains
                          where rc.Status == "Accepted"
                          join c in _context.Campaigns on rc.CampaignId equals c.Id
                          select new RegisterDto
                          {
                              Id = rc.Id,
                              NameCampaign = c.Name,
                              Name = rc.Name,
                              SDT = rc.SDT,
                              Email = rc.Email,
                              Address = rc.Address,
                              SDTParent = rc.SDTParent,
                              Reason = rc.Reason,
                              Aim = rc.Aim,
                              MSSV = rc.MSSV,
                              Status = rc.Status,
                          })
                          .OrderBy(r => r.NameCampaign)
                          .ToList();
            return result;
        }

    }
}

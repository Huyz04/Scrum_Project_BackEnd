using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumBackEnd.Dto;
using ScrumBackEnd.Model;

namespace ScrumBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignContext _context;
        public CampaignController(CampaignContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Đảm bảo context không bị null
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<Campaign>> GetAll()
        {
            return _context.Campaigns.ToList();
        }
        [HttpGet("CampaignOnGoing")]
        public async Task<IEnumerable<Campaign>> GetCampaignOnGoing()
        {
            return  _context.Campaigns.Where(x => x.Status == "OnGoing").ToList();
        }
        [HttpGet("CampaignWaiting")]
        public async Task<IEnumerable<Campaign>> GetCampaignWaiting()
        {
            return _context.Campaigns.Where(x => x.Status == "Waiting").ToList();
        }
        [HttpGet("Campaign{id}")]
        public async Task<Campaign> GetCampaignWaiting([FromQuery] Guid id)
        {
            return _context.Campaigns.Where(x => x.Id == id).FirstOrDefault();
        }
        [HttpPut("ApproveCampaign")]
        public async Task<IActionResult> ApproveCampaign([FromQuery] Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                var res = new LoginRespone()
                {
                    Success = false,
                    Data = $"Error: Fill this Id",
                    Role = "University"
                };
                return Ok(res);
            } 
                
            try
            {
                var cp = _context.Campaigns.Where(x => x.Id == id).FirstOrDefault();
                cp.Status = "OnGoing";
                _context.Campaigns.Update(cp);
                await _context.SaveChangesAsync();
                var res = new LoginRespone()
                {
                    Success = true,
                    Data = "Approve Successfully",
                    Role = "University"
                };
                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new LoginRespone()
                {
                    Success = false,
                    Data = $"Error: {ex}",
                    Role = "University"
                };
                return Ok(res);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaign createDto)
        {
            try
            {
                Campaign add = new()
                {
                    Id = Guid.NewGuid(),
                    Name = createDto.Name,
                    University = createDto.University,
                    Time = createDto.TimeStart.ToShortDateString() + " - " + createDto.TimeEnd.ToShortDateString(),
                    Quantity = createDto.Quantity,
                    Description = createDto.Description,
                    CreatedAt = DateTime.Now,
                    Status = "Waiting",
                    Location = createDto.Location,
                };

                _context.Campaigns.Add(add);
                await _context.SaveChangesAsync();

                // Return a DTO
                var campaignDto = add.Name + " "+add.Location+ " "+add.Time;
                var res = new LoginRespone()
                {
                    Success = true,
                    Data = campaignDto.ToString(),
                    Role = "Community"
                };
                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new LoginRespone()
                {
                    Success = false,
                    Data = $"Error: {ex}",
                    Role = "Community"
                };
                return Ok(res);
            }
        }

    }
}

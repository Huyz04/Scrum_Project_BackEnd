using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumBackEnd.Dto;
using ScrumBackEnd.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CampaignContext _context;
        public UserController(CampaignContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Đảm bảo context không bị null
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUser()
        {
            var data = _context.Users.ToList();
            return Ok(data);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var find = _context.Users.Where(x => x.UserName == login.Username).FirstOrDefault();
            if (find == null)
            {
                LoginRespone respone = new LoginRespone()
                {
                    Success = false,
                    Data = $"No User match with UserName: {login.Username}"
                };
                return Ok(respone);
            }
            else
            {

                if (find.Password != login.Password)
                {
                    LoginRespone respone = new LoginRespone()
                    {
                        Success = false,
                        Data = "Wrong Password"
                    };
                    return Ok(respone);
                }
                else
                {
                    LoginRespone respone = new LoginRespone()
                    {
                        Success = true,
                        Data = "Login successfully",
                        Role = find.Role
                    };
                    return Ok(respone);
                }
            }
        }
    }
}

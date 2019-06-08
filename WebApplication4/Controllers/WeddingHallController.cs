using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WeddingGo.Dtos;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/WeddingHall")]
    public class WeddingHallController : ControllerBase
    {
        private readonly IClientRepositery<WeddingHall> db;
        private readonly IConfiguration config;

        public WeddingHallController(IClientRepositery<WeddingHall> _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        // GET: api/WeddingHall
        [HttpGet]
        public IActionResult GetWeddingHalls()
        {
            List<WeddingHall> weddingHalls = db.GetAll();

            if (weddingHalls.Count > 0)
                return Ok(weddingHalls);
            else
                return NotFound();
        }

        // GET: api/WeddingHall/5
        [HttpGet("{id}")]
        public IActionResult GetWeddingHall([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weddingHall = db.GetById(id);

            if (weddingHall == null)
            {
                return NotFound();
            }

            return Ok(weddingHall);
        }

        // PUT: api/WeddingHall/5
        [HttpPut("{id}")]
        public IActionResult PutWeddingHall([FromRoute] int id, [FromBody] WeddingHall weddingHall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weddingHall.Id)
            {
                return BadRequest();
            }

            db.Update(weddingHall);

            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(200); ;
        }

        // POST: api/WeddingHall
        [HttpPost]
        public IActionResult PostWeddingHall([FromBody] WeddingHall weddingHall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(weddingHall);
            db.Save();

            return StatusCode(201); ;
        }

        // DELETE: api/WeddingHall/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWeddingHall([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weddingHall = db.GetById(id);
            if (weddingHall == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(weddingHall);

        }

        [HttpPost("register")]
        //public async Task<IActionResult> Register(string username,string password)
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto UserForRegiterDto)
        {

            UserForRegiterDto.Username = UserForRegiterDto.Username.ToLower();

            if (await db.UserExists(UserForRegiterDto.Username))
                return BadRequest("username already exists ");

            var userTocreate = new WeddingHall
            {
                Name = UserForRegiterDto.Username,
				Location = UserForRegiterDto.Location,
				Phone = UserForRegiterDto.Phone,
				Rating = UserForRegiterDto.Rating,
				Description = UserForRegiterDto.Description,
				Email = UserForRegiterDto.Email
			};

            var createdUser = await db.Register(userTocreate, UserForRegiterDto.Password);

            return StatusCode(201);  //status for created

        }
        //url:http://.../api/User/register
        //---------------------------------------------------------
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto UserForLoginDto)
        {

            var userFromRepo = await db.Login(UserForLoginDto.Username.ToLower(), UserForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();
            //Token contain UserId,UserName
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),  //24 hours
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var Token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(Token)
            });

        }
    }
}
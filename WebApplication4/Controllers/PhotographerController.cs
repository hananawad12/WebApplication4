using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
    [Route("api/Photographer")]
    public class PhotographerController : ControllerBase
    {
        private readonly IClientRepositery<Photographer> db;
        private readonly IConfiguration config;

        public PhotographerController(IClientRepositery<Photographer> _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        // GET: api/Photographer
        [HttpGet]
        public IActionResult GetPhotographers()
        {
            List<Photographer> photographers = db.GetAll();

            if (photographers.Count > 0)
                return Ok(photographers);
            else
                return NotFound();
        }

        // GET: api/Photographer/5
        [HttpGet("{id}")]
        public IActionResult GetPhotographer([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var photographer = db.GetById(id);

            if (photographer == null)
            {
                return NotFound();
            }

            return Ok(photographer);
        }

        // PUT: api/Photographer/5
        [HttpPut("{id}")]
        public IActionResult PutPhotographer([FromRoute] int id, [FromBody] Photographer photographer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photographer.Id)
            {
                return BadRequest();
            }

            db.Update(photographer);

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

            return  StatusCode(200); ;
        }

        // POST: api/Photographer
        [HttpPost]
        public IActionResult PostPhotographer([FromBody] Photographer photographer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(photographer);
            db.Save();

            return  StatusCode(201); ;
        }

        // DELETE: api/Photographers/5
        [HttpDelete("{id}")]
        public IActionResult DeletePhotographer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var photographer = db.GetById(id);
            if (photographer == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(photographer);

        }

        [HttpPost("register")]
        //public async Task<IActionResult> Register(string username,string password)
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto UserForRegiterDto)
        {

            UserForRegiterDto.Username = UserForRegiterDto.Username.ToLower();

            if (await db.UserExists(UserForRegiterDto.Username))
                return BadRequest("username already exists ");

            var userTocreate = new Photographer
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
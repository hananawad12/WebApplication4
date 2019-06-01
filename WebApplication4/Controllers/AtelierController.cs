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
    [Route("api/Atelier")]
    public class AtelierController : ControllerBase
    {
        private readonly IClientRepositery<Atelier> db;
        private readonly IConfiguration config;

        public AtelierController(IClientRepositery<Atelier> _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        // GET: api/Atelier
        [HttpGet]
        public IActionResult GetAteliers()
        {
            List<Atelier> ateliers = db.GetAll();

            if (ateliers.Count > 0)
                return Ok(ateliers);
            else
                return NotFound();
        }

        // GET: api/Atelier/5
        [HttpGet("{id}")]
        public IActionResult GetAtelier([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atelier = db.GetById(id);

            if (atelier == null)
            {
                return NotFound();
            }

            return Ok(atelier);
        }

        // PUT: api/Atelier/5
        [HttpPut("{id}")]
        public IActionResult PutAtelier([FromRoute] int id, [FromBody] Atelier atelier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atelier.Id)
            {
                return BadRequest();
            }

            db.Update(atelier);

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

        // POST: api/Atelier
        [HttpPost]
        public IActionResult PostAtelier([FromBody] Atelier atelier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(atelier);
            db.Save();

            return StatusCode(201); ;
        }

        // DELETE: api/Atelier/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAtelier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atelier = db.GetById(id);
            if (atelier == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(atelier);

        }

        [HttpPost("register")]
        //public async Task<IActionResult> Register(string username,string password)
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto UserForRegiterDto)
        {

            UserForRegiterDto.Username = UserForRegiterDto.Username.ToLower();

            if (await db.UserExists(UserForRegiterDto.Username))
                return BadRequest("username already exists ");

            var userTocreate = new Atelier
            {
                Name = UserForRegiterDto.Username
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

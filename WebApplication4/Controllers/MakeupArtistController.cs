using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WeddingGo.Dtos;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/MakeupArtist")]
    public class MakeupArtistController : ControllerBase
    {

        private readonly IClientRepositery<MakeupArtist> db;
        private readonly IConfiguration config;
		public MakeupArtistController (IClientRepositery<MakeupArtist> _db,IConfiguration _config)
		{
			db = _db;
            config = _config;
		}
      
        /// GRUD Operations
       
		[HttpGet]
		public IActionResult Get()
		{

			List<MakeupArtist> makeupArtists = db.GetAll();

            if (makeupArtists.Count > 0)
                return Ok(makeupArtists);
            else
                return NotFound();



        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MakeupArtist makeup = db.GetById(id);

            if (makeup == null)
                return NotFound();

            return Ok(makeup);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody]MakeupArtist makeup)
        {
            if (makeup == null)
                return NotFound();
           
            else
            {
                db.Insert(makeup);
                db.Save();
                return StatusCode(201);
            }

        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            MakeupArtist makeup = db.GetById(id);

            if (makeup == null)
                return NotFound();

            else
            {
                db.Delete(id);
                db.Save();
                return StatusCode(200);
            }
      
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody]MakeupArtist makeup)
        {

            if (makeup == null)
                return BadRequest();
            
            else
            {
                db.Update(makeup);
                db.Save();
                return StatusCode(200);
                
                   
            }


        }

        ///Token

        [HttpPost("register")]
        //public async Task<IActionResult> Register(string username,string password)
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto UserForRegiterDto)
        {

            //validate request
            /*2-*if(!ModelState.IsValid)
                return BadRequest(ModelState);*/
            //[apiController] :by use this attribute you don't need to 1,2
            //1:if username and password =null-->are converted to ""(empty string)
            //2-if username and password are empty string

            UserForRegiterDto.Username = UserForRegiterDto.Username.ToLower();

            if (await db.UserExists(UserForRegiterDto.Username))
                return BadRequest("username already exists ");

            var userTocreate = new MakeupArtist
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
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WeddingGo.Dtos;
using WeddingGo.Helpers;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/MakeupArtist")]
    public class MakeupArtistController : ControllerBase
    {

        private readonly IClientRepositery<MakeupArtist> db;
		private readonly IMapper _mapper;
        private readonly IConfiguration config;
        private readonly IPhotoRepository _repo;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public MakeupArtistController (IClientRepositery<MakeupArtist> _db,IConfiguration _config,IMapper mapper, IPhotoRepository repo, IOptions<CloudinarySettings> cloudinaryConfig)
		{
             db = _db;
            config = _config;
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
                );


            _cloudinary = new Cloudinary(acc);
        }

        /// GRUD Operations

        // GET: api/MakeupArtist
        [HttpGet]
        public IActionResult GetMakeupArtists()
        {
            List<MakeupArtist> makeupArtists = db.GetAll();
		
				var makeupToReturn = _mapper.Map<IEnumerable<UserForListDto>>(makeupArtists);

				if (makeupToReturn != null)
					return Ok(makeupToReturn);
			

            
            else
                return NotFound();
        }

        // GET: api/MakeupArtist/5
        [HttpGet("{id}")]
        public IActionResult GetMakeupArtist([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var makeupArtist = db.GetById(id);
			var makeupToReturn = _mapper.Map<UserForDetailed>(makeupArtist);

            if (makeupToReturn == null)
            {
                return NotFound();
            }

            return Ok(makeupToReturn);
        }

        // PUT: api/MakeupArtist/5
        [HttpPut("{id}")]
        public IActionResult PutMakeupArtist([FromRoute] int id, [FromBody] MakeupArtist makeupArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != makeupArtist.Id)
            {
                return BadRequest();
            }

            db.Update(makeupArtist);

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

            return StatusCode(200);
        }

        // POST: api/MakeupArtist
        [HttpPost]
        public IActionResult PostMakeupArtist([FromBody] MakeupArtist makeupArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(makeupArtist);
            db.Save();

            return StatusCode(201);
        }

        // DELETE: api/MakeupArtist/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMakeupArtist([FromRoute] int id)
        {
			//bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var makeupArtist = db.GetById(id);
            if (makeupArtist == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(makeupArtist);

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
				Name = UserForRegiterDto.Username,
				Location = UserForRegiterDto.Location,
				Phone = UserForRegiterDto.Phone,
				Rating = UserForRegiterDto.Rating,
				Description = UserForRegiterDto.Description,
				Email = UserForRegiterDto.Email,
				Type = UserForRegiterDto.Type
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

        //---------------------------------------------------------------------------------------------------------------
        //for uploading images
        //-------------------------
        [HttpGet("GetPhoto/{id}")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);
            return Ok(photo);
        }


        [HttpPost]
        [Route("AddPhoto/{MakeupArtistId}")]
        public async Task<IActionResult> AddPhotoMakeupArtist([FromRoute]int MakeupArtistId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            //i do not understand why ???
            //not correct
            //if (AtelierId != int.Parse(Atelier.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            //correct
            //if (AtelierId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var userFromRepo = db.GetById(MakeupArtistId);
            var file = photoForCreationDto.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        //Transformation = new Transformation().Width(500).Height(500).Crop("Fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);

                }
            }

            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForCreationDto);
            if (userFromRepo.Photos.Any(m => m.IsMain))
                photo.IsMain = true;
            userFromRepo.Photos.Add(photo);


            if (await _repo.SaveAll())
            {
                var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
                //return Ok();

            }
            else
                return BadRequest("could not add the photo");
        }



    }
}
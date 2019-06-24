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
    [Route("api/Photographer")]
    public class PhotographerController : ControllerBase
    {
        private readonly IClientRepositery<Photographer> db;
        private readonly IConfiguration config;
        private readonly IPhotoRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotographerController(IClientRepositery<Photographer> _db, IConfiguration _config, IPhotoRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
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


        [HttpGet("SearchByName/{name}")]
        public IActionResult GetPhotographers([FromRoute] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Photographer> Photographers = db.GetByName(name);

            if (Photographers.Count > 0)
                return Ok(Photographers);
            else
                return NotFound();
        }

        [HttpGet("SearchByFullName/{name}")]
        public IActionResult GetPhotographer([FromRoute] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Photographer = db.GetByFullName(name);

            if (Photographer == null)
            {
                return NotFound();
            }

            return Ok(Photographer);
        }

        [HttpGet("Notify/{id}")]
        public IActionResult Notify([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = db.GetNotification(id);

            if (users.Count > 0)
                return Ok(users);
            else
                return NotFound();
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
        [Route("AddPhoto/{PhotographerId}")]
        public async Task<IActionResult> AddPhotoPhotographer([FromRoute]int PhotographerId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            //i do not understand why ???
            //not correct
            //if (PhotographerId != int.Parse(Photographer.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            //correct
            //if (PhotographerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var userFromRepo = db.GetById(PhotographerId);
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
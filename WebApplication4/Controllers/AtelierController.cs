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
    [Route("api/Atelier")]
    public class AtelierController : ControllerBase
    {
        private readonly IClientRepositery<Atelier> db;
        private readonly IConfiguration config;
        private readonly IPhotoRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public AtelierController(IClientRepositery<Atelier> _db, IConfiguration _config, IPhotoRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
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
                Name = UserForRegiterDto.Username,
				Location = UserForRegiterDto.Location,
				Phone = UserForRegiterDto.Phone,
				Rating = UserForRegiterDto.Rating,
				Description = UserForRegiterDto.Description,
				Email = UserForRegiterDto.Email,
				Type= UserForRegiterDto.Type
		
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
        [HttpGet("{id}", Name = "GetPhotoAtelier")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);
            return Ok(photo);
        }


        [HttpPost]
        [Route("AddPhoto/{AtelierId}")]
        public async Task<IActionResult> AddPhotoAtelier([FromRoute]int AtelierId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            //i do not understand why ???
            //not correct
            //if (AtelierId != int.Parse(Atelier.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            //correct
            //if (AtelierId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var userFromRepo = db.GetById(AtelierId);
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
                return CreatedAtRoute("GetPhotoAtelier", new { id = photo.Id }, photoToReturn);
                //return Ok();

            }
            else
                return BadRequest("could not add the photo");
        }
    }



}

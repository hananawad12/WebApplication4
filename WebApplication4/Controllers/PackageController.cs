using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WeddingGo.Dtos;
using WeddingGo.Helpers;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/Package")]
    public class PackageController : ControllerBase
    {
		private readonly IRepository<Package> db;
        private readonly PackageRepositery dbp;
        private readonly IConfiguration config;
        private readonly IPhotoRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;


        public PackageController(IRepository<Package> _db, PackageRepositery _dbp, IConfiguration _config, IPhotoRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
		{
			db = _db;
            dbp = _dbp;
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

		// GET: api/Package
		[HttpGet]
		public IActionResult GetPackages()
		{
			List<Package> Packages = db.GetAll();

			if (Packages.Count > 0)
				return Ok(Packages);
			else
				return NotFound();
		}

		// GET: api/Package/5
		[HttpGet("{id}")]
		public IActionResult GetPackage([FromRoute] int id)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Packages = dbp.GetAll();


			if (Packages == null)
			{
				return NotFound();
			}

			return Ok(Packages);
		}

		// PUT: api/Package/5
		[HttpPut("{id}")]
		public IActionResult PutPackage([FromRoute] int id, [FromBody] Package Package)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Package.Id)
			{
				return BadRequest();
			}

			db.Update(Package);

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

		// POST: api/Package
		[HttpPost]
		public IActionResult PostPackage([FromBody] Package Package)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Insert(Package);
			db.Save();

			return StatusCode(201);
		}

		// DELETE: api/Package/5
		[HttpDelete("{id}")]
		public IActionResult DeletePackage([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Package = db.GetById(id);
			if (Package == null)
			{
				return NotFound();
			}

			db.Delete(id);
			db.Save();

			return Ok(Package);

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
        [Route("AddPhoto/{PackageId}")]
        public async Task<IActionResult> AddPhotoPackage([FromRoute]int PackageId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            //i do not understand why ???
            //not correct
            //if (AtelierId != int.Parse(Atelier.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            //correct
            //if (AtelierId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var userFromRepo = db.GetById(PackageId);
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

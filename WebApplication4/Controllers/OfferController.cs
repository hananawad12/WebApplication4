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
    [Route("api/Offer")]
    public class OfferController : ControllerBase
    {
		private readonly IRepository<Offer> db;
        private readonly IConfiguration config;
        private readonly IPhotoRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public OfferController(IRepository<Offer> _db, IConfiguration _config, IPhotoRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
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

		// GET: api/Offer
		[HttpGet]
		public IActionResult GetOffers()
		{
			List<Offer> Offers = db.GetAll();

			if (Offers.Count > 0)
				return Ok(Offers);
			else
				return NotFound();
		}

		// GET: api/Offer/5
		[HttpGet("{id}")]
		public IActionResult GetOffer([FromRoute] int id)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Offer = db.GetById(id);

			if (Offer == null)
			{
				return NotFound();
			}

			return Ok(Offer);
		}

		// PUT: api/Offer/5
		[HttpPut("{id}")]
		public IActionResult PutOffer([FromRoute] int id, [FromBody] Offer Offer)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Offer.Id)
			{
				return BadRequest();
			}

			db.Update(Offer);

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

		// POST: api/Offer
		[HttpPost]
		public IActionResult PostOffer([FromBody] Offer Offer)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Insert(Offer);
			db.Save();

			return StatusCode(201);
		}

		// DELETE: api/Offer/5
		[HttpDelete("{id}")]
		public IActionResult DeleteOffer([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Offer = db.GetById(id);
			if (Offer == null)
			{
				return NotFound();
			}

			db.Delete(id);
			db.Save();

			return Ok(Offer);

		}


        //---------------------------------------------------------------------------------------------------------------
        //for uploading images
        //-------------------------
        [HttpGet("{id}", Name = "GetPhotoOffer")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);
            return Ok(photo);
        }


        [HttpPost]
        [Route("AddPhoto/{OfferId}")]
        public async Task<IActionResult> AddPhotoAtelier([FromRoute]int OfferId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            //i do not understand why ???
            //not correct
            //if (AtelierId != int.Parse(Atelier.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            //correct
            //if (AtelierId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var userFromRepo = db.GetById(OfferId);
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
                return CreatedAtRoute("GetPhotoOffer", new { id = photo.Id }, photoToReturn);
                //return Ok();

            }
            else
                return BadRequest("could not add the photo");
        }
    }
}
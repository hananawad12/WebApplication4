﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeddingGo.Data;
using WeddingGo.Dtos;
using WeddingGo.Helpers;
using WeddingGo.Models;

namespace WeddingGo.Controllers
{
    //[Authorize]
    [Route("api/MakeupArtist/{MakeupArtistId}/Photo}")]
   
    public class PhotoController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        private readonly WeddingContext _db;


        public PhotoController(IDatingRepository repo,IMapper mapper,IOptions<CloudinarySettings> cloudinaryConfig, WeddingContext db)
        {
            _cloudinaryConfig =cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;
            _db = db;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
                );


            _cloudinary = new Cloudinary(acc);

        }

        [HttpGet("{id}",Name ="GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = _repo.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);
            return Ok(photo);
        }


        [HttpPost]
        public async Task<IActionResult> AddPhotoMakeupArtist(int MakeupArtistId,PhotoForCreationDto photoForCreationDto)
        {
            //i do not understand why ???
            //not correct
            //if (MakeupArtistId != int.Parse(MakeupArtist.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            //correct
            //if (MakeupArtistId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();

            var userFromRepo = await _repo.GetClient(MakeupArtistId);
            var file = photoForCreationDto.File;
            var uploadResult = new ImageUploadResult();

            if(file.Length>0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("Fill").Gravity("face")
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
                return CreatedAtRoute("GetPhoto",new { id=photo.Id},);
            //return Ok();
            else
                return BadRequest("could not add the photo");
        }
    }
}
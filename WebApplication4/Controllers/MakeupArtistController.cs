using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/MakeupArtist")]
    public class MakeupArtistController : Controller
    {

		IClientRepositery db;
		public MakeupArtistController (IClientRepositery _db)
		{
			db = _db;
		}

		[HttpGet]
		public List<MakeupArtist> Get()
		{

			List<MakeupArtist> makeupArtists = db.getAll();


			return makeupArtists;
		}


		[HttpGet("{id}")]
		public IActionResult  GetById( int id)
		{
			MakeupArtist makeup = db.getById(id);

			if (makeup == null)
				return NotFound();

			return Ok(makeup);
		}


	}
}
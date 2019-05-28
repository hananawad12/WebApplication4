using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/MakeupArtist")]
    public class MakeupArtistController : Controller
    {

		IClientRepositery<MakeupArtist> db;
		public MakeupArtistController (IClientRepositery<MakeupArtist> _db)
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
        [HttpPost]
        public void Add(MakeupArtist makeup)
        {
            db.Insert(makeup);
            db.Save();

        }

        public void Delete(int id)
        {
            db.Delete(id);
            db.Save();

        }
        public void Update(MakeupArtist makeup)
        {
            db.Update(makeup);
            db.Save();

        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/MakeupArtist")]
   
    public class MakeupArtistController : ControllerBase
    {

		IClientRepositery<MakeupArtist> db;
		public MakeupArtistController (IClientRepositery<MakeupArtist> _db)
		{
			db = _db;
		}

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
    }
}
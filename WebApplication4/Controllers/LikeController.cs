using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/Like")]
    public class LikeController : ControllerBase
    {
        private readonly IRepository<Like> db;
       
        public LikeController(IRepository<Like> _db)
        {
            db = _db;
            
        }

        /// GRUD Operations

        // GET: api/Like
        [HttpGet]
        public IActionResult GetLikes()
        {
            List<Like> Likes = db.GetAll();

            if (Likes.Count > 0)
                return Ok(Likes);
            else
                return NotFound();
        }

        // GET: api/Like/5
        [HttpGet("{id}")]
        public IActionResult GetLike([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Like = db.GetById(id);

            if (Like == null)
            {
                return NotFound();
            }

            return Ok(Like);
        }

        // PUT: api/Like/5
        [HttpPut("{id}")]
        public IActionResult PutLike([FromRoute] int id, [FromBody] Like Like)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Like.Id)
            {
                return BadRequest();
            }

            db.Update(Like);

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

        // POST: api/Like
        [HttpPost]
        public IActionResult PostLike([FromBody] Like Like)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(Like);
            db.Save();

            return StatusCode(201);
        }

        // DELETE: api/Like/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLike([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Like = db.GetById(id);
            if (Like == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(Like);

        }
    }
}
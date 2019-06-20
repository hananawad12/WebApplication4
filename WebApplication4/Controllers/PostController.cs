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
    [Route("api/Post")]
    public class PostController : ControllerBase
    {
        private readonly IRepository<Post> db;
        public PostController(IRepository<Post> _db)
        {
            db = _db;
        }

        /// GRUD Operations

        // GET: api/Post
        [HttpGet]
        public IActionResult GetPosts()
        {
            List<Post> Posts = db.GetAll();

            if (Posts.Count > 0)
                return Ok(Posts);
            else
                return NotFound();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult GetPost([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Post = db.GetById(id);

            if (Post == null)
            {
                return NotFound();
            }

            return Ok(Post);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult PutPost([FromRoute] int id, [FromBody] Post Post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Post.Id)
            {
                return BadRequest();
            }

            db.Update(Post);

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

        // POST: api/Post
        [HttpPost]
        public IActionResult PostPost([FromBody] Post Post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(Post);
            db.Save();

            return StatusCode(201);
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public IActionResult DeletePost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Post = db.GetById(id);
            if (Post == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(Post);

        }
    }
}
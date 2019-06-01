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
    [Route("api/Comment")]
    public class CommentController : ControllerBase
    {
        private readonly IClientRepositery<Comment> db;
        private readonly IConfiguration config;
        public CommentController(IClientRepositery<Comment> _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        /// GRUD Operations

        // GET: api/Comment
        [HttpGet]
        public IActionResult GetComments()
        {
            List<Comment> Comments = db.GetAll();

            if (Comments.Count > 0)
                return Ok(Comments);
            else
                return NotFound();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public IActionResult GetComment([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Comment = db.GetById(id);

            if (Comment == null)
            {
                return NotFound();
            }

            return Ok(Comment);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult PutComment([FromRoute] int id, [FromBody] Comment Comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Comment.Id)
            {
                return BadRequest();
            }

            db.Update(Comment);

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

        // POST: api/Comment
        [HttpPost]
        public IActionResult PostComment([FromBody] Comment Comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(Comment);
            db.Save();

            return StatusCode(201);
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Comment = db.GetById(id);
            if (Comment == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(Comment);

        }


    }
}
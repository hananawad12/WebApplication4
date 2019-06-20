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
    [Route("api/Message")]
    public class MessageController : ControllerBase
    {
        private readonly IRepository<Message> db;
       

        public MessageController(IRepository<Message> _db)
        {
            db = _db;
            
        }

        // GET: api/Message
        [HttpGet]
        public IActionResult GetMessages()
        {
            List<Message> messages = db.GetAll();

            if (messages.Count > 0)
                return Ok(messages);
            else
                return NotFound();
        }

        // GET: api/Message/5
        [HttpGet("{id}")]
        public IActionResult GetMessage([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var message = db.GetById(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/Message/5
        [HttpPut("{id}")]
        public IActionResult PutMessage([FromRoute] int id, [FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.Id)
            {
                return BadRequest();
            }

            db.Update(message);

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

        // POST: api/Message
        [HttpPost]
        public IActionResult PostMessage([FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(message);
            db.Save();

            return StatusCode(201); ;
        }

        // DELETE: api/Message/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var message = db.GetById(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(message);

        }
    }
}
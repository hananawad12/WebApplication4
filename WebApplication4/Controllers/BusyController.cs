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
    [Route("api/Busy")]
    public class BusyController : ControllerBase
    {
        private readonly IClientRepositery<Busy> db;
        private readonly IConfiguration config;

        public BusyController(IClientRepositery<Busy> _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        // GET: api/Busy
        [HttpGet]
        public IActionResult GetBusys()
        {
            List<Busy> busys = db.GetAll();

            if (busys.Count > 0)
                return Ok(busys);
            else
                return NotFound();
        }

        // GET: api/Busy/5
        [HttpGet("{id}")]
        public IActionResult GetBusy([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var busy = db.GetById(id);

            if (busy == null)
            {
                return NotFound();
            }

            return Ok(busy);
        }

        // PUT: api/Busy/5
        [HttpPut("{id}")]
        public IActionResult PutBusy([FromRoute] int id, [FromBody] Busy busy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != busy.Id)
            {
                return BadRequest();
            }

            db.Update(busy);

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

        // POST: api/Busy
        [HttpPost]
        public IActionResult PostBusy([FromBody] Busy busy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(busy);
            db.Save();

            return StatusCode(201); ;
        }

        // DELETE: api/Busy/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBusy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var busy = db.GetById(id);
            if (busy == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(busy);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingGo.Models;
using WeddingGo.Models.Repositery;

namespace WeddingGo.Controllers
{
    [Produces("application/json")]
    [Route("api/Reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IRepository<Reservation> db;
        private readonly IConfiguration config;
       

        public ReservationController(IRepository<Reservation> _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
           

        }

        // GET: api/Reservation
        [HttpGet]
        public IActionResult GetReservations()
        {
            List<Reservation> Reservations = db.GetAll();

            if (Reservations.Count > 0)
                return Ok(Reservations);
            else
                return NotFound();
        }

        // GET: api/Reservation/id
        [HttpGet("{id}")]
        public IActionResult GetReservation([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Reservation = db.GetById(id);

            if (Reservation == null)
            {
                return NotFound();
            }

            return Ok(Reservation);
        }

        [HttpPut("{id}")]
        public IActionResult PutReservation([FromRoute] int id, [FromBody] Reservation Reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Reservation.Id)
            {
                return BadRequest();
            }

            db.Update(Reservation);

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

        // POST: api/Reservation
        [HttpPost]
        public IActionResult PostReservation([FromBody] Reservation Reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insert(Reservation);
            db.Save();

            return StatusCode(201);
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Reservation = db.GetById(id);
            if (Reservation == null)
            {
                return NotFound();
            }

            db.Delete(id);
            db.Save();

            return Ok(Reservation);

        }
    }
}
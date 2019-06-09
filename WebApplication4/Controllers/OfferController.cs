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
    [Route("api/Offer")]
    public class OfferController : ControllerBase
    {
		private readonly IRepository<Offer> db;
		
		public OfferController(IRepository<Offer> _db)
		{
			db = _db;
			
		}

		/// GRUD Operations

		// GET: api/Offer
		[HttpGet]
		public IActionResult GetOffers()
		{
			List<Offer> Offers = db.GetAll();

			if (Offers.Count > 0)
				return Ok(Offers);
			else
				return NotFound();
		}

		// GET: api/Offer/5
		[HttpGet("{id}")]
		public IActionResult GetOffer([FromRoute] int id)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Offer = db.GetById(id);

			if (Offer == null)
			{
				return NotFound();
			}

			return Ok(Offer);
		}

		// PUT: api/Offer/5
		[HttpPut("{id}")]
		public IActionResult PutOffer([FromRoute] int id, [FromBody] Offer Offer)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Offer.Id)
			{
				return BadRequest();
			}

			db.Update(Offer);

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

		// POST: api/Offer
		[HttpPost]
		public IActionResult PostOffer([FromBody] Offer Offer)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Insert(Offer);
			db.Save();

			return StatusCode(201);
		}

		// DELETE: api/Offer/5
		[HttpDelete("{id}")]
		public IActionResult DeleteOffer([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Offer = db.GetById(id);
			if (Offer == null)
			{
				return NotFound();
			}

			db.Delete(id);
			db.Save();

			return Ok(Offer);

		}
	}
}
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
    [Route("api/Package")]
    public class PackageController : ControllerBase
    {
		private readonly IRepository<Package> db;
        private readonly PackageRepositery dbp;

        public PackageController(IRepository<Package> _db, PackageRepositery _dbp)
		{
			db = _db;
            dbp = _dbp;
			
		}

		/// GRUD Operations

		// GET: api/Package
		[HttpGet]
		public IActionResult GetPackages()
		{
			List<Package> Packages = db.GetAll();

			if (Packages.Count > 0)
				return Ok(Packages);
			else
				return NotFound();
		}

		// GET: api/Package/5
		[HttpGet("{id}")]
		public IActionResult GetPackage([FromRoute] int id)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Packages = dbp.GetSpecific(id);


			if (Packages == null)
			{
				return NotFound();
			}

			return Ok(Packages);
		}

		// PUT: api/Package/5
		[HttpPut("{id}")]
		public IActionResult PutPackage([FromRoute] int id, [FromBody] Package Package)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Package.Id)
			{
				return BadRequest();
			}

			db.Update(Package);

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

		// POST: api/Package
		[HttpPost]
		public IActionResult PostPackage([FromBody] Package Package)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Insert(Package);
			db.Save();

			return StatusCode(201);
		}

		// DELETE: api/Package/5
		[HttpDelete("{id}")]
		public IActionResult DeletePackage([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var Package = db.GetById(id);
			if (Package == null)
			{
				return NotFound();
			}

			db.Delete(id);
			db.Save();

			return Ok(Package);

		}
	}
}
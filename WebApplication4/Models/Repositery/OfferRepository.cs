using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public class OfferRepository : IRepository<Offer>
	{
		private bool disposed = false;
		WeddingContext db;
		public OfferRepository(WeddingContext _db)
		{
			db = _db;
		}

		public void Delete(int ID)
		{
			Offer makeup = db.Offers.Find(ID);
			db.Entry(makeup).State = EntityState.Deleted;

		}

		public List<Offer> GetAll()
		{
			return db.Offers.Include(m => m.Photos).ToList();
		}

		public Offer GetById(int id)
		{
			return db.Offers.Include(m=>m.Photos).FirstOrDefault(t => t.Id == id);
		}

		public void Insert(Offer item)
		{
			db.Offers.Add(item);

		}


		public void Save()
		{
			db.SaveChanges();
		}

		public void Update(Offer item)
		{

			db.Entry(item).State = EntityState.Modified;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
			}
			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public bool ItemExists(int id)
		{
			return db.Offers.Count(e => e.Id == id) > 0;
		}


	}
}

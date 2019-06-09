using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public class PackageRepositery:IRepository<Package>
	{
		private bool disposed = false;

		WeddingContext db;
		public PackageRepositery(WeddingContext _db)
		{
			db = _db;
		}

		public void Delete(int ID)
		{
			Package makeup = db.Packages.Find(ID);
			db.Entry(makeup).State = EntityState.Deleted;

		}

		public List<Package> GetAll()
		{
			return db.Packages.ToList();
		}

        public List<Package> GetSpecific(int ID)
        {
            return db.Packages.Where(i => i.Client.Id == ID).ToList();
        }

        public Package GetById(int id)
		{
			return db.Packages/*.Include(m=>m.Packages)*/.FirstOrDefault(t => t.Id == id);
		}

		public void Insert(Package item)
		{
			db.Packages.Add(item);

		}


		public void Save()
		{
			db.SaveChanges();
		}

		public void Update(Package item)
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
			return db.Packages.Count(e => e.Id == id) > 0;
		}

	}

	
}

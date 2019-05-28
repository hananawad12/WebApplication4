using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeddingGo.Models.Repositery
{
	public class MakeupArtistRepositery : IClientRepositery<MakeupArtist>
	{
        private bool disposed = false;

        private readonly WeddingContext db;
			public MakeupArtistRepositery(WeddingContext _db)
			{
				db = _db;
			}


        public void Delete(int ID)
        {
            MakeupArtist makeup = db.MakeupArtists.Find(ID);
            db.MakeupArtists.Remove(makeup);
           
        }

        public List<MakeupArtist> getAll()
		{

			return db.MakeupArtists.ToList();
            
        }

		public MakeupArtist getById(int id)
		{
			return db.MakeupArtists/*.Include(m=>m.Packages)*/.FirstOrDefault(t=>t.Id==id);
		}    

        public void Insert(MakeupArtist item)
        {
            db.MakeupArtists.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(MakeupArtist item)
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
            return db.MakeupArtists.Count(e => e.Id == id) > 0;
        }
    }

}

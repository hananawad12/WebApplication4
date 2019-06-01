using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class BusyRepository : IRepository<Busy>
    {
        private bool disposed = false;

        private readonly WeddingContext db;
        public BusyRepository(WeddingContext _db)
        {
            db = _db;
        }


        public void Delete(int ID)
        {
            Busy busy = db.Busies.Find(ID);
            db.Entry(busy).State = EntityState.Deleted;

        }

        public List<Busy> GetAll()
        {
            return db.Busies.ToList();
        }

        public Busy GetById(int id)
        {
            return db.Busies.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Busy item)
        {
            db.Busies.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Busy item)
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
            return db.Busies.Count(e => e.Id == id) > 0;
        }
    }
}

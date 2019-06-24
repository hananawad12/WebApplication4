using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class PackageRepository : IRepository<Reservation>
    {
        private bool disposed = false;
        WeddingContext db;
        public PackageRepository(WeddingContext _db)
        {
            db = _db;
        }

        public void Delete(int ID)
        {
            Offer makeup = db.Offers.Find(ID);
            db.Entry(makeup).State = EntityState.Deleted;

        }

        public List<Reservation> GetAll()
        {
            return db.Reservations.Include(m => m.Offers)
                                   .Include(m => m.Packages)
                       
                                   .ToList();
        }

        public Reservation GetById(int id)
        {
            return db.Reservations.Include(m => m.Offers)
                                   .Include(m => m.Packages)
                                   
                                   .FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Reservation item)
        {
            db.Reservations.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Reservation item)
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
            return db.Reservations.Count(e => e.Id == id) > 0;
        }


    }
}

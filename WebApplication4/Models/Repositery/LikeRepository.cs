using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class LikeRepository : IRepository<Like>
    {
        private bool disposed = false;

        WeddingContext db;
        public LikeRepository(WeddingContext _db)
        {
            db = _db;
        }

        public void Delete(int ID)
        {
            Like makeup = db.Likes.Find(ID);
            db.Entry(makeup).State = EntityState.Deleted;

        }

        public List<Like> GetAll()
        {
            return db.Likes.ToList();
        }

        public Like GetById(int id)
        {
            return db.Likes/*.Include(m=>m.Likes)*/.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Like item)
        {
            db.Likes.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Like item)
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
            return db.Likes.Count(e => e.Id == id) > 0;
        }

    }
}

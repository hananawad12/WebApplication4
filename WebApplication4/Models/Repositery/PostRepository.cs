using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class PostRepository : IRepository<Post>
    {
        private bool disposed = false;

        WeddingContext db;
        public PostRepository(WeddingContext _db)
        {
            db = _db;
        }

        public void Delete(int ID)
        {
            Post makeup = db.Posts.Find(ID);
            db.Entry(makeup).State = EntityState.Deleted;

        }

        public List<Post> GetAll()
        {
            return db.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return db.Posts/*.Include(m=>m.Posts)*/.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Post item)
        {
            db.Posts.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Post item)
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
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}

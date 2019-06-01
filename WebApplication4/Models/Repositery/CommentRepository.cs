using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class CommentRepository : IRepository<Comment>
    {
        private bool disposed = false;

        WeddingContext db;
        public CommentRepository(WeddingContext _db)
        {
            db = _db;
        }

        public void Delete(int ID)
        {
            Comment makeup = db.Comments.Find(ID);
            db.Entry(makeup).State = EntityState.Deleted;

        }

        public List<Comment> GetAll()
        {
            return db.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return db.Comments/*.Include(m=>m.Comments)*/.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Comment item)
        {
            db.Comments.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Comment item)
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
            return db.Comments.Count(e => e.Id == id) > 0;
        }
    }
}

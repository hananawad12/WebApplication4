using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class MessageRepository : IRepository<Message>
    {
        private bool disposed = false;

        private readonly WeddingContext db;
        public MessageRepository(WeddingContext _db)
        {
            db = _db;
        }


        public void Delete(int ID)
        {
            Message message = db.Messages.Find(ID);
            db.Entry(message).State = EntityState.Deleted;

        }

        public List<Message> GetAll()
        {
            return db.Messages.ToList();
        }

        public Message GetById(int id)
        {
            return db.Messages.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Message item)
        {
            db.Messages.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Message item)
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
            return db.Messages.Count(e => e.Id == id) > 0;
        }
    }
}

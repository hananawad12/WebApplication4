using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingGo.Models;

namespace WeddingGo.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly WeddingContext db;

        public DatingRepository(WeddingContext _db)
        {
            db = _db;
        }

        public void Add<T>(T entity) where T : class
        {
            db.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            db.Remove(entity);
        }

        public async Task<Client> GetClient(int id)
        {
            var user=await db.Clients.Include(p=>p.Photos).FirstOrDefaultAsync(a=>a.Id==id);
            return user;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
           var users=await db.Clients.Include(p=>p.Photos).ToListAsync();
            return users;
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo=await db.Photos.FirstOrDefaultAsync(p=>p.Id==id);
            return photo;
        }

        public async Task<bool> SaveAll()
        {
            return await db.SaveChangesAsync()>0;
        }

      
    }
}

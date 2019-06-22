using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly WeddingContext db;

        public PhotoRepository(WeddingContext _db)
        {
            db = _db;
        }
        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await db.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<bool> SaveAll()
        {
            return await db.SaveChangesAsync() > 0;
        }
    }
}

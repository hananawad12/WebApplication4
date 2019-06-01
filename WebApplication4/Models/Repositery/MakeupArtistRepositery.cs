using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public class MakeupArtistRepositery : IClientRepositery<MakeupArtist>,IRepository<MakeupArtist>
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
            db.Entry(makeup).State = EntityState.Deleted;

        }

        public List<MakeupArtist> GetAll()
		{
			return db.MakeupArtists.ToList();   
        }

		public MakeupArtist GetById(int id)
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

        //Token

        public async Task<MakeupArtist> Register(MakeupArtist user, string password)
        {
            byte[] PasswordHash, PasswordSalt;
            
            //passwordHash, passwordSalt pass ref not value type
            //use out for write only
            CreatePasswordHash(password, out PasswordHash, out PasswordSalt);
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;
            await db.MakeupArtists.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //anything inside here now is going to to be disposed 
            //as soon as we are finished with it
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //random generated key
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<MakeupArtist> Login(string username, string password)
        {
            //return null if user is unauthorized
            var user = await db.MakeupArtists.FirstOrDefaultAsync(u => u.Name == username);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;

                }

            }
            return true;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await db.MakeupArtists.AnyAsync(u => u.Name == username))
                return true;
            return false;
        }
    }

}

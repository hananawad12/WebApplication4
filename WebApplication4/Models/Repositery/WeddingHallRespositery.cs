﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public class WeddingHallRespositery:IClientRepositery<WeddingHall>
	{
        private bool disposed = false;

        private readonly WeddingContext db;
        public WeddingHallRespositery(WeddingContext _db)
        {
            db = _db;
        }


        public void Delete(int ID)
        {
            WeddingHall WeddingHall = db.WeddingHalls.Find(ID);
            db.Entry(WeddingHall).State = EntityState.Deleted;

        }

        public List<WeddingHall> GetAll()
        {
            return db.WeddingHalls.ToList();
        }

        public WeddingHall GetById(int id)
        {
            return db.WeddingHalls/*.Include(m=>m.Packages)*/.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(WeddingHall item)
        {
            db.WeddingHalls.Add(item);

        }


        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(WeddingHall item)
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
            return db.WeddingHalls.Count(e => e.Id == id) > 0;
        }

        //Token

        public async Task<WeddingHall> Register(WeddingHall user, string password)
        {
            byte[] PasswordHash;
            byte[] PasswordSalt;
            //passwordHash, passwordSalt pass ref not value type
            //use out for write only
            CreatePasswordHash(password, out PasswordHash, out PasswordSalt);
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;
            await db.WeddingHalls.AddAsync(user);
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

        public async Task<WeddingHall> Login(string username, string password)
        {
            //return null if user is unauthorized
            var user = await db.WeddingHalls.FirstOrDefaultAsync(u => u.Name == username);
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
            if (await db.WeddingHalls.AnyAsync(u => u.Name == username))
                return true;
            return false;
        }
    }
}

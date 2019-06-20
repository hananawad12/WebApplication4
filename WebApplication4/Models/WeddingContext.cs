using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class WeddingContext:DbContext
	{
		public WeddingContext(DbContextOptions option) : base(option)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.Entity<MakeupArtist>().ToTable("MakeupArtists");

			modelBuilder.Entity<Photographer>().ToTable("Photographers");

			modelBuilder.Entity<Atelier>().ToTable("Ateliers");
			
			modelBuilder.Entity<User>().ToTable("Users");

			modelBuilder.Entity<WeddingHall>().ToTable("WeddingHalls");

			//base.OnModelCreating(modelBuilder);
		}

		public DbSet<Client> Clients { get; set; }
		//public DbSet<Photographer> Photographers { get; set; }
		//public DbSet<Atelier> Ateliers { get; set; }
		//public DbSet<WeddingHall> WeddingHalls { get; set; }
		public DbSet<Package> Packages { get; set; }
       // public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Busy> Busies { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }









    }
}

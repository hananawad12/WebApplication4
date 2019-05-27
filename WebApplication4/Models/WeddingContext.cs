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

		public DbSet<MakeupArtist> MakeupArtists { get; set; }
		public DbSet<Photographer> Photographers { get; set; }
		public DbSet<Atelier> Ateliers { get; set; }
		public DbSet<WeddingHall> WeddingHalls { get; set; }
		public DbSet<Package> Packages { get; set; }
	}
}

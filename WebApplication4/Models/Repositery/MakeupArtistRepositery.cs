using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingGo.Models;


namespace WeddingGo.Models.Repositery
{
	public class MakeupArtistRepositery : IClientRepositery
	{
		
			WeddingContext db;
			public MakeupArtistRepositery(WeddingContext _db)
			{
				db = _db;
			}


		public List<MakeupArtist> getAll()
		{
			return db.MakeupArtists/*.Include(m=>m.Packages)*/.ToList();
		}

		public MakeupArtist getById(int id)
		{
			return db.MakeupArtists/*.Include(m=>m.Packages)*/.FirstOrDefault(t=>t.Client.Id==id);
		}
	}


	


}

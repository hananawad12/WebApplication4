using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public class OfferRepository : IRepository<Offer>
	{
		WeddingContext db;
		public OfferRepository(WeddingContext _db)
		{
			db = _db;
		}

		public void Delete(int ID)
		{
			throw new NotImplementedException();
		}

		public List<Offer> GetAll()
		{
			throw new NotImplementedException();
		}

		public Offer GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Offer item)
		{
			throw new NotImplementedException();
		}

		public bool ItemExists(int id)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public void Update(Offer item)
		{
			throw new NotImplementedException();
		}
	}
}

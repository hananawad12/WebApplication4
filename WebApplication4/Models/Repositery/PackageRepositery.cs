﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public class PackageRepositery:IRepository<Package>
	{
		WeddingContext db;
		public PackageRepositery(WeddingContext _db)
		{
			db = _db;
		}

		public void Delete(int ID)
		{
			throw new NotImplementedException();
		}

		public List<Package> GetAll()
		{
			throw new NotImplementedException();
		}

		public Package GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Package item)
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

		public void Update(Package item)
		{
			throw new NotImplementedException();
		}
	}

	
}

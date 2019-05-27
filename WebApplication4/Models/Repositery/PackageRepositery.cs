using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public class PackageRepositery:IPackageRepositery
	{
		WeddingContext db;
		public PackageRepositery(WeddingContext _db)
		{
			db = _db;
		}
		public List<Package> getAll()
		{
			return db.Packages.ToList();
		}


		public Package getById(int id)
		{

			return db.Packages.Find(id);
		}
	}

	public interface IPackageRepositery
	{
		List<Package> getAll();

		Package getById(int id);
	}
}

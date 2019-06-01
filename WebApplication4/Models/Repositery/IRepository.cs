using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public interface IRepository<T> where T : class
	
	{
		List<T> GetAll();

		T GetById(int id);
		void Insert(T item);
		void Update(T item);
		void Delete(int ID);
		void Save();
		bool ItemExists(int id);

	}
}

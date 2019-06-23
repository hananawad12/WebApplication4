using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public interface IClientRepositery<T> where T : class
    {

		List<T> GetAll();

		T GetById(int id);
        T GetByName(string name);
		void Insert(T item);
		void Update(T item);
		void Delete(int ID);
		void Save();
		bool ItemExists(int id);
		//token
		Task<T> Register(T user, string password);
        Task<T> Login(string username, string password);
        Task<bool> UserExists(string username);



    }
}

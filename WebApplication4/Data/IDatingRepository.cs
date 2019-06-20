using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingGo.Models;

namespace WeddingGo.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task<Photo> GetPhoto(int id);
    }
}

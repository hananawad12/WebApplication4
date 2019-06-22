using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public interface IPhotoRepository
    {
        Task<Photo> GetPhoto(int id);
        Task<bool> SaveAll();

    }
}

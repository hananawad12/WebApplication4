using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
    public interface IPriceRepository<T> where T : class
    {
        T SearchPrice(decimal price);
    }
}

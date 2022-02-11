using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T FindById(int id);
        void Insert(T item);
        void Update(T item, int id);
        void Delete(T item);
    }
}

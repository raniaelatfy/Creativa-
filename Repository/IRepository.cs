using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Repository
{
   public interface IRepository<T>
    {
        public  Task<List<T>> GetAll();
        public Task Update(int id, T item);
        public Task Delete(int id);
        public Task Add(T item);
        public Task<T> Find(int id);

    }
}

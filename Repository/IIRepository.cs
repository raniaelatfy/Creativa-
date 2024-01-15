using Creativa.Models;
using Creativa.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Repository
{
    public interface IIRepository<u>
    {
        public Task<List<u>> GetAll();
        public Task Update(string id, u item);
        public Task Delete(string id);
        public Task Add(u item);
        public Task<u> Find(string id);
        Task Update(string username, UserRegisterModel profile);
       
        Task Update(string username, ModelViewUser profile);
    }
}

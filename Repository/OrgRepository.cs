using Creativa.Identity;
using Creativa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Repository
{
    
   
    public class OrgRepository : IRepository<Organization>
    {
        ApplicationDbContext db;
        public OrgRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task Add(Organization item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Organization>> GetAll()
        {
            return  await db.Organizations.ToListAsync();
        }

        public Task Update(int id, Organization item)
        {
            throw new NotImplementedException();
        }
    }
}

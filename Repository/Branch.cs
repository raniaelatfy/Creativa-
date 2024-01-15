using Creativa.Identity;
using Creativa.Models;
using Creativa.ModelView;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creativa.Repository
{
    public class BranchRepository : IRepository<Branch>
    {
        public readonly ApplicationDbContext db; 
        public BranchRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task Add(Branch item)
        {
            Branch branch = new Branch() {
                Name = item.Name,
                Organizationid = item.Organizationid,
            };
            db.Add(branch);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Branch found = await db.Branches.FindAsync(id);
            db.Branches.Remove(found);
           await db.SaveChangesAsync();
        }

        public async Task<Branch> Find(int id)
        {
            return await db.Branches.FindAsync(id);
        }

        public async Task<List<Branch>> GetAll()
        {
            return await db.Branches.ToListAsync();
        }

        public async Task Update(int id, Branch item)
        {
            Branch found = await db.Branches.FindAsync(id);
            found.Name = item.Name;
            found.Organizationid = item.Organizationid;
            await db.SaveChangesAsync();
        }
    }
}

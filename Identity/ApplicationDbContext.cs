using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Creativa.Models;

namespace Creativa.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SocialAccount>()
       .HasKey(c => new { c.Id, c.GraduateUserid });
            builder.Entity<GraduateFrom>()
       .HasKey(c => new { c.Id, c.trackId });
            builder.Entity<FreeLance>()
        .HasKey(c => new { c.Id, c.BranchId });
           

         base.OnModelCreating(builder);
        }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Organization> Organizations{ get; set; }
        public virtual DbSet<Branch> Branches{ get; set; }
        public virtual DbSet<Track> Tracks{ get; set; }
        public virtual DbSet<User> User{ get; set; }
        public virtual DbSet<GraduateUser> GraduateUsers{ get; set; }
        public virtual DbSet<FreeLance> FreeLances{ get; set; }
        public virtual DbSet<ProgramTable> Programs{ get; set; }
        public virtual DbSet<SocialAccount> socialAccounts{ get; set; }
        public virtual DbSet<GraduateFrom> Graduate_Froms{ get; set; }
        public virtual DbSet<FreeLance> Freelances { get; set; }


    }
}

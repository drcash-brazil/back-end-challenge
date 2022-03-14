using System.Collections.Immutable;
using DrcashTest.Models;
using DrcashTest.Profiles.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrcashTest.Models
{
    public class DataContext : IdentityDbContext<Users>
    {
        public DataContext(DbContextOptions<DataContext> opt) :
            base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Authors> Authors { get; set; }

        public DbSet<Genero> Genero { get; set; }

        public DbSet<Books> Books { get; set; }
    }
}

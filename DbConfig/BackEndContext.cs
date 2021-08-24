using BackEnd.Mappings;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DbConfig
{
    public class BackEndContext:DbContext
    {
        public BackEndContext(DbContextOptions<BackEndContext> option):base(option)
        {}
        public DbSet<Authors> authors{get;set;}
        public DbSet<Books> books{get;set;}
        public DbSet<Generous> generous{get;set;}
         public DbSet<Users> users{get;set;}
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorMap());
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new GenreMap());
            builder.ApplyConfiguration(new UserMap());
           
        }
    }
}
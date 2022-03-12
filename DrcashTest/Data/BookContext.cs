using DrcashTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrcashTest.Data
{
    public class BookContext : DbContext
    {
        public DbSet <Book> Books  { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1;Initial Catalog=drcash;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=True;");

            /*
             * https://www.youtube.com/watch?v=ipbSwv09dDU
             * get-help entityframeworkcore
             * Add-Migration initial
             * Remove-migration
             * update-database
             * script-migration
             */
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(x => x.BookId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Author>().Property(x => x.AuthorId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Genre>().Property(x => x.GenreId).HasDefaultValueSql("NEWID()");
        }
    }
}